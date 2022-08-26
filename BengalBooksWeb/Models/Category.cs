using System.ComponentModel.DataAnnotations;

namespace BengalBooksWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string DisplayOrder { get; set; }
        public DateTime CreatedDateTime = DateTime.Now;
    }
}
