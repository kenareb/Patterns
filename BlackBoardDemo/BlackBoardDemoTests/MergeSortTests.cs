using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BlackBoardDemo.Tests
{
    [TestClass()]
    public class MergeSortTests
    {
        [TestMethod()]
        public void SortTest1()
        {
            var input = new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            var expected = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var mergeSort = new MergeSort();
            var actual = mergeSort.Sort(input);

            for (int i = 0; i < input.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod()]
        public void SortTest2()
        {
            var input = new[] { 5, 9, 1, 3, 7, 10, 8, 4, 2, 6 };
            var expected = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var mergeSort = new MergeSort();
            var actual = mergeSort.Sort(input);

            for (int i = 0; i < input.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod()]
        public void SortTest3()
        {
            var input = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var expected = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var mergeSort = new MergeSort();
            var actual = mergeSort.Sort(input);

            for (int i = 0; i < input.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }
    }
}