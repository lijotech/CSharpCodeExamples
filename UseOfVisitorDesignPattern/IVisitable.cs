﻿namespace UseOfVisitorDesignPattern
{
    public interface IVisitable
    {
        void Accept(IVisitor visitor);
    }
}
