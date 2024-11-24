using UseOfCompositeDesignPattern.Component;

namespace UseOfCompositeDesignPattern.Leaf
{
    public class IndividualContributor : Employee
    {
        public IndividualContributor(string name, string position) : base(name, position) { }

        public override void DisplayDetails()
        {
            Console.WriteLine($"{position}: {name}");
        }
        public override int GetTotalSubordinates()
        {
            return 0; // Individual contributors have no subordinates }
        }
    }
}