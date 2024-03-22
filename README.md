# DelegatesInCSharp
Explains the use of different delgates in c#
`
using System;

class Program
{
    // Named delegate
    delegate void MyDelegate(string msg);

    // Method that matches the signature of the named delegate
    static void MyMethod(string message)
    {
        Console.WriteLine("Named Delegate: " + message);
    }

    // Event delegate
    public delegate void MyEventDelegate();

    public class MyClass
    {
        public event MyEventDelegate MyEvent;

        public void RaiseEvent()
        {
            MyEvent?.Invoke();
        }
    }

    static void Main(string[] args)
    {
        // Named delegate example
        MyDelegate del = MyMethod;
        del("Hello, World!");

        // Action delegate example
        Action<string> myAction = (message) =>
        {
            Console.WriteLine("Action Delegate: " + message);
        };
        myAction("Hello, World!");

        // Func delegate example
        Func<int, int, int> add = (a, b) =>
        {
            return a + b;
        };
        int result = add(1, 2);
        Console.WriteLine("Func Delegate: " + result);

        // Multicast delegate example
        MyDelegate del1 = MyMethod;
        MyDelegate del2 = MyMethod;
        MyDelegate del3 = del1 + del2;
        del3("From Multicast, Hello, World!");

        // Predicate delegate example
        Predicate<string> isUpperCase = IsUpperCase;
        bool isUpper = isUpperCase("Hello World");
        Console.WriteLine("Predicate Delegate: " + isUpper);

        // Event delegate example
        MyClass obj = new MyClass();
        obj.MyEvent += () => Console.WriteLine("Event Delegate: Event Raised");
        obj.RaiseEvent();
    }

    static bool IsUpperCase(string str)
    {
        return str.Equals(str.ToUpper());
    }
}
`
