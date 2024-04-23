using System.ComponentModel.DataAnnotations;
namespace VanillaMovieShop.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{MM/dd/yyyy HH:mm}")]
        public DateTime OrderDate { get; set; }

        [Required]
        public int CustomerId { get; set; }

    }
}
