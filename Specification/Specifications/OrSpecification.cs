﻿namespace Specification.Specifications
{
    public class OrSpecification<T> : ISpecification<T>
    {
        public ISpecification<T> Left { get; set; }
        public ISpecification<T> Right { get; set; }
        public OrSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            Left = left;
            Right = right;
        }
        public bool IsSatisfiedBy(T item) => Left.IsSatisfiedBy(item) || Right.IsSatisfiedBy(item);
    }
}