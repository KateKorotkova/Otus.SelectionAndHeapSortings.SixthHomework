namespace Otus.SelectionAndHeapSortings.SixthHomework.Logic
{
    public class HeapSort
    {
        private int[] _array;


        public HeapSort(int[] array)
        {
            _array = array;
        }


        public int[] Run()
        {
            //начальное становление пирамиды
            for (var root = _array.Length / 2 - 1; root >= 0; root--)
            {
                Heapify(root, _array.Length);
            }

            for (var i = _array.Length - 1; i >= 0; i--)
            {
                //переносим МАХ (который оказался на вершине кучи - [0]) в конец массива
                Swap(0, i);

                //перестраиваем кучу, с учетом исключения MAX (обрезали длину массива)
                Heapify(0, i);
            }

            return _array;
        }


        #region Support methods

        /// <summary>
        /// Перестраиваем дерево так, чтобы максимальный элемент был наверху
        /// </summary>
        private void Heapify(int rootIndex, int size)
        {
            var leftIndex = 2 * rootIndex + 1;
            var rightIndex = 2 * rootIndex + 2;

            var maxIndexInSubTree = GetIndexOfMaxElementInSubTree(rootIndex, leftIndex, rightIndex, size);
            if (maxIndexInSubTree == rootIndex)
                return;
            
            //поднимаем левого/правого чайлда на место парента
            //бывший парент спускается на уровень левого/правого чайлда
            Swap(maxIndexInSubTree, rootIndex);

            //после того, как бывший парент опустился на место чайлда
            //нужно проверить/перестроить "внуков"
            Heapify(maxIndexInSubTree, size);
        }

        private int GetIndexOfMaxElementInSubTree(int rootIndex, int leftIndex, int rightIndex, int size)
        {
            bool ExceedLeftBorder() => leftIndex >= size;
            bool ExceedRightBorder() => rightIndex >= size;

            int maxIndex = rootIndex;
            
            if (!ExceedLeftBorder())
            {
                if (_array[leftIndex] > _array[rootIndex])
                {
                    if (ExceedRightBorder() || _array[leftIndex] > _array[rightIndex])
                        maxIndex = leftIndex;
                }
            }

            if (!ExceedRightBorder())
            {
                if (_array[rightIndex] > _array[rootIndex])
                {
                    if (ExceedLeftBorder() || _array[rightIndex] > _array[leftIndex])
                        maxIndex = rightIndex;
                }
            }

            return maxIndex;
        }

        private void Swap(int x, int y)
        {
            var tmp = _array[x];
            _array[x] = _array[y];
            _array[y] = tmp;
        }

        #endregion
    }
}
