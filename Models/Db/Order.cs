﻿using System.ComponentModel.DataAnnotations;
namespace VanillaMovieShop.Models.Db
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{MM/dd/yyyy HH:mm}")]
        public DateTime OrderDate { get; set; }

        [Required]
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<OrderRow> OrderRows { get; set; } = new List<OrderRow>();
    }
}
