using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace PowerCollections.Tests
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void Constructor_CreatesEmptyStack()
        {
            var stack = new Stack<int>(5);

            Assert.AreEqual(0, stack.Count);
            Assert.AreEqual(5, stack.Capacity);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_Throws_ArgumentOutOfRangeExceptions_When_CapacityIsZeroOrLess(int capatity)
        {
            var stack = new Stack<int>(capatity);
        }

        [TestMethod]
        public void Push_InsertElement_OnTheEnd()
        {
            var stack = new Stack<int>(5);

            stack.Push(1);
            stack.Push(1);
            stack.Push(1);

            Assert.AreEqual(3, stack.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Push_DoesntInsertElement_OnTheEnd_And_Thows_InvalidException_When_StackIsFull()
        {
            var stack = new Stack<int>(1);

            stack.Push(1);
            stack.Push(1);
        }

        [TestMethod]
        public void Pop_ReturnsTopElement_And_RemovesIt()
        {
            var stack = new Stack<int>(5);

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.AreEqual(3, stack.Pop());
            Assert.AreEqual(2, stack.Pop());

            Assert.AreEqual(1, stack.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_ThrowsInvalidOperationException_When_StackIsEmpty()
        {
            var stack = new Stack<int>(5);

            var element = stack.Pop();
        }

        public void Top_ReturnsTopElement()
        {
            var stack = new Stack<int>(5);

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.AreEqual(3, stack.Top());

            Assert.AreEqual(3, stack.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Top_ThrowsInvalidOperationException_When_StackIsEmpty()
        {
            var stack = new Stack<int>(5);

            var element = stack.Top();
        }

        [TestMethod]
        public void Enumerator_IteratesStack_FromTopToBottom()
        {
            var stack = new Stack<int>(3);
            var array = new int[] { 3, 2, 1 };

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            CollectionAssert.AreEqual(array, stack.ToArray());
        }
    }
}
