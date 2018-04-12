using NUnit.Framework;

namespace BinarySearch.Tests
{
    [TestFixture]
    public class Tests
    {
        [TestCase(new int[] { 0, 1, 3, 4, 6, 6, 7, 7, 124, 21234, 324234 }, 21234, 9)]
        [TestCase(new int[] { 0, 1, 3, 4, 6, 7}, 4, 3)]
        [TestCase(new int[] { 0, 1, 3, 4, 6, 7 }, 0, 0)]
        [TestCase(new int[] { 0, 1, 3, 4, 6, 7 }, 7, 5)]
        public void TestsForBinarySearch(int[] array, int wantedElement, int expectedResult) 
        {
            Assert.AreEqual(expectedResult, Searcher.BinarySearch(array, wantedElement, new IntComparer()));
        }

        [TestCase(new int[] { 0, 1, 3, 4, 6, 6, 7, 7, 124, 21234, 324234 }, 21234, 9)]
        [TestCase(new int[] { 0, 1, 3, 4, 6, 7 }, 4, 3)]
        [TestCase(new int[] { 0, 1, 3, 4, 6, 7 }, 0, 0)]
        [TestCase(new int[] { 0, 1, 3, 4, 6, 7 }, 7, 5)]
        public void TestsForBinarySearchWithDelegate(int[] array, int wantedElement, int expectedResult)
        {
            IntComparer comparer = new IntComparer();
            Assert.AreEqual(expectedResult, Searcher.BinarySearch(array, wantedElement, comparer.Compare));
        }

        [TestCase(new string[] { "aaaa", "aaaaa", "ab", "bv", "vc" }, "ab", 2)]
        [TestCase(new string[] { "aaaa", "aaaaa", "ab", "bv", "vc" }, "aaaa", 0)]
        [TestCase(new string[] { "aaaa", "aaaaa", "ab", "bv", "vc" }, "aaaaa", 1)]
        [TestCase(new string[] { "aaaa", "aaaaa", "ab", "bv", "vc" }, "vc", 4)]
        public void TestsForBinarySearchWithDelegate(string[] array, string wantedElement, int expectedResult)
        {
            Assert.AreEqual(expectedResult, Searcher.BinarySearch(array, wantedElement, new StringComparer()));
        }
    }
}
