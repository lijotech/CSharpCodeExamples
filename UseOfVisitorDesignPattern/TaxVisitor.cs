namespace UseOfVisitorDesignPattern
{
    public class TaxVisitor : IVisitor
    {
        public void Visit(Book book)
        {
            Console.WriteLine($"Calculating 5% tax for book: {book.Title}");
        }

        public void Visit(Electronics electronics)
        {
            Console.WriteLine($"Calculating 18% tax for electronic: {electronics.Model}");
        }
    }
}
