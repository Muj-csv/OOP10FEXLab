namespace OOP10FEXLab.Models
{
    /// <summary>A package meal loaded from Data\meals.txt.</summary>
    public class Meal
    {
        public string Code { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Inclusions { get; set; }
    }
}
