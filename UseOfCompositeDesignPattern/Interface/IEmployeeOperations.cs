using UseOfCompositeDesignPattern.Component;

namespace UseOfCompositeDesignPattern.Interface
{
    public interface IEmployeeOperations
    {
        void Add(Employee employee);
        void Remove(Employee employee);
    }
}