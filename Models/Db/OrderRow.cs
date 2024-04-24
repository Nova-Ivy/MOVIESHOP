using System.ComponentModel.DataAnnotations;
namespace VanillaMovieShop.Models.Db
{
    public class OrderRow
    {
        public int Id { get; set; }
        public string OrderId { get; set; }
        public string MovieId { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        //public virtual Movie Movie { get; set; }
        //Spublic virtual Order Order { get; set; }
    }
}
