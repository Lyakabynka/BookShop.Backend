namespace BookShop.Domain
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Pages { get; set; }
        public DateOnly PublishingDate { get; set; }
        public float Price { get; set; }

        public List<Order>? Orders { get; set; }

    }
}