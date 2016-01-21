using System.ComponentModel.DataAnnotations;

namespace CompanyProject.Models
{
    public class ProductOption
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public int Factor { get; set; }
        public bool IsPizzaOption { get; set; }
        public bool IsSaladOption { get; set; }
    }
}
