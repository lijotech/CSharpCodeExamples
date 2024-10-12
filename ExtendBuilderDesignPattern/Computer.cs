using System.Xml.Linq;

namespace ExtendBuilderDesignPattern
{
    public class Computer
    {
        public string CPU { get; set; }
        public string GPU { get; set; }
        public int RAM { get; set; }
        public int Storage { get; set; }

        public string City { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return $"CPU: {CPU}, GPU: {GPU}, RAM: {RAM}, Storage: {Storage}, City: {City}, Address: {Address}";
        }
    }
}
