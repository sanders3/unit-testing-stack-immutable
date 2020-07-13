using System;
using Xunit;
using ImmutableStack.Library;

namespace ImmutableStack.Tests
{
    public class ImmutableStackTests
    {
        [Fact]
        public void CanPopOffItem()
        {
            var stack = new ImmutableStack<string>();
            Assert.Null(stack.Peek());

            var fooStack = stack.Push("foo");
            Assert.Equal("foo", fooStack.Peek());

            Assert.Null(stack.Peek());

            var emptyStack = fooStack.Pop();
            Assert.Null(emptyStack.Peek());

            Assert.Equal("foo", fooStack.Peek());

            Assert.Null(stack.Peek());
        }
        [Fact]
        public void CanPopOffMultipleItems()
        {
            var original = new ImmutableStack<string>();
            Assert.Null(original.Peek());
            Assert.Equal(0, original.Count);

            var stack = original.Push("foo").Push("bar");
            Assert.Equal(2, stack.Count);            
            Assert.Equal("bar", stack.Peek());

            stack = stack.Pop();
            Assert.Equal("foo", stack.Peek());
            Assert.Equal(1, stack.Count);

            stack = stack.Pop();
            Assert.Null(stack.Peek());
            Assert.Equal(0, original.Count);

            Assert.Same(stack, original);
        }

        [Fact]
        public void CanPopFromEmptyStringStack()
        {
            var stack = new ImmutableStack<string>();
            Assert.Null(stack.Peek());
            Assert.Same(stack, stack.Pop());
        }

        [Fact]
        public void CanPopFromEmptyIntStack()
        {
            var stack = new ImmutableStack<int>();
            Assert.Equal(0, stack.Peek());
            Assert.Same(stack, stack.Pop());
        }

    }
}
