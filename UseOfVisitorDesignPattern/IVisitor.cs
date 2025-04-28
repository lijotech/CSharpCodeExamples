namespace UseOfVisitorDesignPattern
{
    public interface IVisitor
    {
        void Visit(Book book);
        void Visit(Electronics electronics);
    }
}
