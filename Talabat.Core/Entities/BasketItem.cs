﻿namespace Talabat.Core.Entities
{
    public class BasketItem
    {
        public int Id { get; set; }
        public string ProductName { get; set; }

        public string PictureURL { get; set; }

        public decimal Price { get; set; }

        public string Brand { get; set; }

        public string Category { get; set; }

        public int Quantity { get; set; }
    }
}