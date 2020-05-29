using System.Collections.Generic;

namespace SoftTestLab2Yamanko
{
    class ArrayProcessor
    {
        public int[] SortAndFilter(int[] a)
        {
            List<int> array = new List<int>();

            for(int i = 0; i<a.Length; i++)
            {
                if (a[i] >= 1000)
                {
                    array.Add(a[i]);
                }
            }
            return array.ToArray();
        }
    }
}
