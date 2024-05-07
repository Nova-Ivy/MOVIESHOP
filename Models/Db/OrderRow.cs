using System.ComponentModel.DataAnnotations;
namespace VanillaMovieShop.Models.Db
{
    public class OrderRow
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int MovieId { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual Order Order { get; set; }

    }
}
