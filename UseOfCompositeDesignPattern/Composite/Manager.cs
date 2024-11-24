using UseOfCompositeDesignPattern.Component;
using UseOfCompositeDesignPattern.Interface;

namespace UseOfCompositeDesignPattern.Composite
{
    public class Manager : Employee, IEmployeeOperations
    {
        private List<Employee> _subordinates = new List<Employee>();

        public Manager(string name, string position) : base(name, position) { }

        public void Add(Employee employee)
        {
            _subordinates.Add(employee);
        }

        public void Remove(Employee employee)
        {
            _subordinates.Remove(employee);
        }

        public override int GetTotalSubordinates()
        {
            int totalSubordinates = _subordinates.Count;
            foreach (var subordinate in _subordinates)
            {
                totalSubordinates += subordinate.GetTotalSubordinates();
            }
            return totalSubordinates;
        }
        public override void DisplayDetails()
        {
            Console.WriteLine($"{position}: {name} (Number of subordinates: {GetTotalSubordinates()})");
            foreach (var subordinate in _subordinates)
            {
                subordinate.DisplayDetails();
            }
        }
    }
}