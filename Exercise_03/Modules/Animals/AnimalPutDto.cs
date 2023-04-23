using System.ComponentModel.DataAnnotations;

namespace Exercise_03.Modules.Animals
{
    public class AnimalPutDto
    {
        [Required]
        [StringLength(200, MinimumLength = 5)]
        public string Name { get; set; } = string.Empty;
        [StringLength(200, MinimumLength = 5)]
        public string? Description { get; set; } = null;
        [Required]
        [StringLength(200, MinimumLength = 5)]
        public string Category { get; set; } = string.Empty;
        [Required]
        [StringLength(200, MinimumLength = 5)]
        public string Area { get; set; } = string.Empty;
    }
}
