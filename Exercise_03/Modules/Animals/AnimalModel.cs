namespace Exercise_03.Modules.Animals
{
    public class AnimalModel
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = null;
        public string Category { get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;
    }
}
