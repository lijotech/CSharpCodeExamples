namespace ExtendBuilderDesignPattern
{
    public class ComputerStorageBuilder<T> : ComputerRAMBuilder<ComputerStorageBuilder<T>> where T : ComputerStorageBuilder<T>
    {
        public T SetStorage(int storage)
        {
            computer.Storage = storage;
            return (T)this;
        }
    }

}
