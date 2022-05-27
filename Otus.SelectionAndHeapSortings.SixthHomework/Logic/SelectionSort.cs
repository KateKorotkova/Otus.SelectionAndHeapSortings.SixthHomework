namespace Otus.SelectionAndHeapSortings.SixthHomework.Logic
{
    public class SelectionSort
    {
        public int[] Run(int[] array)
        {
            for (var i = 1; i < array.Length; i++)
            {
                var maxIndex = GetMaxIndex(array, array.Length - i);

                var lastElement = array[^i];
                array[^i] = array[maxIndex];
                array[maxIndex] = lastElement;
            }

            return array;
        }


        private int GetMaxIndex(int[] array, int rightBorder)
        {
            var maxIndex = 0;

            for (var i = 0; i <= rightBorder; i++)
            {
                if (array[i] > array[maxIndex])
                {
                    maxIndex = i;
                }
            }

            return maxIndex;
        }
    }
}
