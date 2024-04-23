using System.ComponentModel.DataAnnotations;

namespace VanillaMovieShop.Models.Db
{
    public class Movie
    {
        public int Id { get; set; }
        
        [Required]
        [Data]
        public string Title { get; set; }

        [Required] 
        public string Director { get; set; }
        
        [Required]
        [DataType(DataType.DateTime)]
        [Display()]
        public int ReleaseYear { get; set; }
        
        [Required]
        [DataType(DataType.Currency)]
        public int Price { get; set; }
        
        [Required]
        public string? Genre { get; set; }
        
        [Required] 
        public string? Actors { get; set; }

    }
}
