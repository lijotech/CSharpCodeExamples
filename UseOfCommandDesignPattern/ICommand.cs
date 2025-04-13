namespace UseOfCommandDesignPattern
{
    /// <summary>
    /// Command Interface
    /// </summary>
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
