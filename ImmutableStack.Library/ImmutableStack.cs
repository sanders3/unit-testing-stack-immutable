using System;

namespace ImmutableStack.Library
{
    public class ImmutableStack<T>
    {
        private readonly T _item;
        private readonly int _count;
        private readonly ImmutableStack<T> _parent;

        public ImmutableStack()
        {
            _item = default;
            _count = 0;
            _parent = null;
        }

        private ImmutableStack(T item, ImmutableStack<T> parent)
        {
            _item = item;
            _count = parent._count + 1;
            _parent = parent;
        }

        public int Count 
        {
            get { return _count; }
        }
        public T Peek()
        {
            return _item;
        }

        public ImmutableStack<T> Pop()
        {
            if (_parent == null)
            {
                return this;
            }
            else {
                return _parent;
            }
        }

        public ImmutableStack<T> Push(T item)
        {
            return new ImmutableStack<T>(item, this);
        }
    }
}
