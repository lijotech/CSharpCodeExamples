namespace UseOfCompositeDesignPattern.Component
{
    public abstract class Employee
    {
        protected string name;
        protected string position;

        public Employee(string name, string position)
        {
            this.name = name;
            this.position = position;
        }

        public abstract void DisplayDetails();
        public abstract int GetTotalSubordinates();
    }
}