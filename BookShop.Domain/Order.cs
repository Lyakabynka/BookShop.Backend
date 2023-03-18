namespace BookShop.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public float Price { get; set; }

        public IEnumerable<Book> Books { get; set; }
    }
}
