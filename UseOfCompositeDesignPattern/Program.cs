using UseOfCompositeDesignPattern.Composite;
using UseOfCompositeDesignPattern.Leaf;

namespace UseOfCompositeDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var developer = new IndividualContributor("Alice", "Developer");
            var designer = new IndividualContributor("Bob", "Designer");
            developer.DisplayDetails();
            Console.WriteLine();
         
            var manager = new Manager("Charlie", "Manager");
            manager.Add(developer);
            manager.Add(designer);

            //manger without any reporting person
            var managerAlone = new Manager("Dona", "Manager");

            var ceo = new Manager("Diana", "CEO");
            ceo.Add(manager);
            ceo.Add(managerAlone);

            ceo.DisplayDetails();
        }
    }
}