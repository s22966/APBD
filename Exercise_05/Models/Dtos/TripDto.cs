using Exercise_05.Models.Dtos;

namespace Exercise_05.Models.DTOs
{
    public class TripDto
    {
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public int MaxPeople { get; set; }

        public virtual IEnumerable<CountryDto> Countries { get; set; } = new List<CountryDto>();
        public virtual IEnumerable<ClientDto> Clients { get; set; } = new List<ClientDto>();
    }
}
