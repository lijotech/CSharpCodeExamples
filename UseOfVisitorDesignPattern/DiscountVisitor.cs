namespace UseOfVisitorDesignPattern
{
    public class DiscountVisitor : IVisitor
    {
        public void Visit(Book book)
        {
            Console.WriteLine($"Applying 10% discount on book: {book.Title}");
        }

        public void Visit(Electronics electronics)
        {
            Console.WriteLine($"Applying 5% discount on electronic: {electronics.Model}");
        }
    }
}
