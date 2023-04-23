using System.Data;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace Exercise_03.Modules.Animals
{
    public interface IAnimalsRepository
    {
        Task<AnimalModel?> GetAnimal(int ID);
        Task<ICollection<AnimalModel>> GetAnimals(string? orderBy);
        Task<AnimalModel?> PostAnimal(AnimalPostDto animalPostDto);
        Task<AnimalModel?> PutAnimal(int ID, AnimalPutDto animalPutDto);
        Task DeleteAnimal(int ID);
        Task<bool> DoesAnimalExists(int ID);
        string[] GetValidOrderByValues();
    }

    public class AnimalsRepository : IAnimalsRepository
    {
        private readonly string _connectionString;

        public AnimalsRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default")
                ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<AnimalModel?> GetAnimal(int ID)
        {
            AnimalModel? animalModel = null;
            var query = "SELECT * FROM dbo.Animals WHERE ID = @ID";

            using var sqlConnection = new SqlConnection(_connectionString);
            using var sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@ID", ID);

            await sqlConnection.OpenAsync();

            using var sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            if(await sqlDataReader.ReadAsync()) {
                animalModel = ReadAnimal(sqlDataReader);
            }

            return animalModel;
        }

        public async Task<ICollection<AnimalModel>> GetAnimals(string? orderBy)
        {
            orderBy ??= "name";

            var query = $"SELECT * FROM dbo.Animals ORDER BY {orderBy}";
            var animalModels = new List<AnimalModel>();

            using var sqlConnection = new SqlConnection(_connectionString);
            using var sqlCommand = new SqlCommand(query, sqlConnection);

            await sqlConnection.OpenAsync();

            using var sqlDataReader = await sqlCommand.ExecuteReaderAsync();
            while (await sqlDataReader.ReadAsync())
            {
                animalModels.Add(ReadAnimal(sqlDataReader));
            }

            return animalModels;
        }

        public async Task<AnimalModel?> PostAnimal(AnimalPostDto animalPostDto)
        {
            string query = $@"
                INSERT INTO
                    dbo.Animals (ID, Name, Description, Category, Area)
                VALUES (                     
                    @ID, @Name, @Description, @Category, @Area
                )";

            using var sqlConnection = new SqlConnection(_connectionString);
            using var sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@ID", animalPostDto.ID);
            sqlCommand.Parameters.AddWithValue("@Name", animalPostDto.Name);
            sqlCommand.Parameters.AddWithValue("@Description", animalPostDto.Description);
            sqlCommand.Parameters.AddWithValue("@Category", animalPostDto.Category);
            sqlCommand.Parameters.AddWithValue("@Area", animalPostDto.Area);

            await sqlConnection.OpenAsync();
            await sqlCommand.ExecuteNonQueryAsync();

            return await GetAnimal(animalPostDto.ID);
        }

        public async Task<AnimalModel?> PutAnimal(int ID, AnimalPutDto animalPutDto)
        {
            string query =
                @$"
                UPDATE
                    dbo.Animals
                SET
                    Name = @Name,
                    Description = @Description,
                    Category = @Category,
                    Area = @Area
                WHERE
                    ID = @ID
                ";

            using var sqlConnection = new SqlConnection(_connectionString);
            using var sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@ID", ID);
            sqlCommand.Parameters.AddWithValue("@Name", animalPutDto.Name);
            sqlCommand.Parameters.AddWithValue("@Description", animalPutDto.Description is null ? DBNull.Value : animalPutDto.Description);
            sqlCommand.Parameters.AddWithValue("@Category", animalPutDto.Category);
            sqlCommand.Parameters.AddWithValue("@Area", animalPutDto.Area);

            await sqlConnection.OpenAsync();
            await sqlCommand.ExecuteNonQueryAsync();

            return await GetAnimal(ID);
        }

        public async Task DeleteAnimal(int ID)
        {
            string query = $"DELETE FROM dbo.Animals WHERE ID = {ID}";
            using var sqlConnection = new SqlConnection(_connectionString);
            using var sqlCommand = new SqlCommand(query, sqlConnection);

            await sqlConnection.OpenAsync();
            await sqlCommand.ExecuteNonQueryAsync();
        }

        public async Task<bool> DoesAnimalExists(int ID)
        {
            return (await GetAnimal(ID)) is not null;
        }

        private static AnimalModel ReadAnimal(SqlDataReader sqlDataReader)
        {
            var idOrdinal = sqlDataReader.GetOrdinal("ID");
            var nameOrdinal = sqlDataReader.GetOrdinal("Name");
            var descriptionOrdinal = sqlDataReader.GetOrdinal("Description");
            var categoryOrdinal = sqlDataReader.GetOrdinal("Category");
            var areaOrdinal = sqlDataReader.GetOrdinal("Area");

            var animalModel = new AnimalModel
            {
                ID = sqlDataReader.GetInt32(idOrdinal),
                Name = sqlDataReader.GetString(nameOrdinal),
                Description = !sqlDataReader.IsDBNull(descriptionOrdinal) ? sqlDataReader.GetString(descriptionOrdinal) : null,
                Category = sqlDataReader.GetString(categoryOrdinal),
                Area = sqlDataReader.GetString(areaOrdinal)
            };

            return animalModel;
        }

        public string[] GetValidOrderByValues()
        {
            return new string[] { "ID", "Name", "Description", "Category", "Area" };
        }
    }
}
