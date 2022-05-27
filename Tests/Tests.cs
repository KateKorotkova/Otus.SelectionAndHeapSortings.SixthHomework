using NUnit.Framework;
using Otus.SelectionAndHeapSortings.SixthHomework.Logic;

namespace Tests
{
    public class Tests
    {
        //private int[] _initialArray = { 32, 95, 16, 82, 24, 66, 35, 19, 75, 54, 40, 43, 93, 68 };
        //private int[] _sortedArray = { 16, 19, 24, 32, 35, 40, 43, 54, 66, 68, 75, 82, 93, 95 };

        private int[] _initialArray = { 8, 2, 3, 5 };
        private int[] _sortedArray = { 2, 3, 5, 8 };


        [Test]
        public void Can_Sort_Via_Selection_Sorting()
        {
            var sorter = new SelectionSort();

            var sortedArray = sorter.Run(GetInitialArray());

            CollectionAssert.AreEqual(_sortedArray, sortedArray);
        }

        #region Helpers

        private int[] GetInitialArray()
        {
            var tmpArray = new int[_initialArray.Length];

            _initialArray.CopyTo(tmpArray, 0);

            return tmpArray;
        }

        #endregion
    }
}