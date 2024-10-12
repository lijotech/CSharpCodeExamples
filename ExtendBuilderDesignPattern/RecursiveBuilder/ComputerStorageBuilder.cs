namespace ExtendBuilderDesignPattern.RecursiveBuilder
{
    public class ComputerStorageBuilder<T> : ComputerRAMBuilder<ComputerStorageBuilder<T>> where T : ComputerStorageBuilder<T>
    {
        public T SetStorage(int storage)
        {
            computer.Storage = storage;
            return (T)this;
        }
        public T InCity(string city)
        {
            computer.City = city;
            return (T)this;
        }

        public T AtAddress(string address)
        {
            computer.Address = address;
            return (T)this;
        }
    }

}
