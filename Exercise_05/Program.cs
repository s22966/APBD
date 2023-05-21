using Exercise_05.Data;
using Exercise_05.Services;

namespace Exercise_05
{
    class Program
    {
        static void Main(string[] args)
        {
            var webApplicationBuilder = WebApplication.CreateBuilder(args);

            webApplicationBuilder.Services.AddControllers();
            webApplicationBuilder.Services.AddEndpointsApiExplorer();
            webApplicationBuilder.Services.AddSwaggerGen();
            webApplicationBuilder.Services.AddDbContext<ApbdContext>();
            webApplicationBuilder.Services.AddScoped<IClientService, ClientService>();
            webApplicationBuilder.Services.AddScoped<ITripsService, TripsService>();

            var webApplication = webApplicationBuilder.Build();

            if (webApplication.Environment.IsDevelopment())
            {
                webApplication.UseSwagger();
                webApplication.UseSwaggerUI();
            }

            webApplication.UseAuthorization();
            webApplication.MapControllers();
            webApplication.Run();
        }
    }
}

