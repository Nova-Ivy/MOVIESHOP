using System.ComponentModel.DataAnnotations;

namespace VanillaMovieShop.Models.Db
{
    public class Movie
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(50)]
        public string Director { get; set; }
        
        [Required]
      
        [Display(Name = "Release Year")]  
        public int ReleaseYear { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

       
        public string? Genre { get; set; }
        
        
        public string? Actors { get; set; }

        [DataType(DataType.ImageUrl)]

        public string? Image {  get; set; }

        public virtual ICollection<OrderRow> OrderRows { get; set; } = new List<OrderRow>();

    }
}
