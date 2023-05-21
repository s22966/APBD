using System.ComponentModel.DataAnnotations;

namespace Exercise_05.Models.Dtos
{
    public class TripClientPostDto
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Telephone { get; set; } = string.Empty;
        [Required]
        public string Pesel { get; set; } = string.Empty;
        [Required]
        public string TripName { get; set; } = string.Empty;
        [Required]
        public DateTime PaymentDate { get; set; }
    }
}
