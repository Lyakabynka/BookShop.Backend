﻿namespace BookShop.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public float Price { get; set; }
        public DateOnly CreatedAt { get; set; }

        public List<Book> Books { get; set; }
    }
}
