﻿using UseOfVisitorDesignPattern;

class Program
{
    static void Main()
    {
        List<IVisitable> items = new List<IVisitable>
        {
            new Book { Title = "Design Patterns" },
            new Electronics { Model = "Smartphone" }
        };

        DiscountVisitor discountVisitor = new DiscountVisitor();
        TaxVisitor taxVisitor = new TaxVisitor();

        foreach (var item in items)
        {
            item.Accept(discountVisitor);
            item.Accept(taxVisitor);
        }
    }
}


public class Book : IVisitable
{
    public string Title { get; set; }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class Electronics : IVisitable
{
    public string Model { get; set; }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}