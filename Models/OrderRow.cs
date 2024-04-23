namespace VanillaMovieShop.Models
{
    public class OrderRow
    {
        public int Id { get; set; }
        public string OrderId { get; set; }
        public string MovieId { get; set; }
        public decimal Price { get; set; }

        //public virtual Movie Movie { get; set; }
        //Spublic virtual Order Order { get; set; }
    }
}
