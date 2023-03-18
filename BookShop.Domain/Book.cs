namespace BookShop.Domain
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Pages { get; set; }
        public DateTime PublishingDate { get; set; }


        public Author Author { get; set; }

        public Order? Order { get; set; }

    }
}