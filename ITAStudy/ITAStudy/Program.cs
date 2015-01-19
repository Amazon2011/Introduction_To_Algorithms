using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITAStudy
{
    class Program
    {
        static void Print(string value)
        {
            Console.Write(value);
            Console.Read();
        }
        static void PrintIntArray(int[] intArray)
        {
            foreach (int i in intArray)
            {
                Console.Write(i + ", ");
            }

            Console.Read();
        }

        static void InsertionSort(ref int[] intArray)
        {
            for (int i = 1; i < intArray.Length; i++)
            {
                int key = intArray[i];
                int j = i - 1;
                while (j >= 0 && intArray[j] > key)
                {
                    intArray[j + 1] = intArray[j];
                    j--;
                }
                intArray[j + 1] = key;
            }
        }


        static void MergeSort(ref int[] intArray)
        {
            int n = intArray.Length;
            if (n >= 2)
            {
                int middle = (int)Math.Ceiling((double)n / 2);
                int[] array1 = new int[middle];
                int[] array2 = new int[n - middle];

                for (int i = 0; i < intArray.Length; i++)
                {
                    if (i <= middle - 1)
                    {
                        array1[i] = intArray[i];
                    }
                    else
                    {
                        array2[i - middle] = intArray[i];
                    }
                }
                MergeSort(ref array1);
                MergeSort(ref array2);
                intArray = MergeSortedIntArray(array1, array2);
            }
        }

        static int T(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            else
            {
                return T(n / 2) + n;
            }
        }

        static int[] MergeSortedIntArray(int[] array1, int[] array2)
        {
            int[] sortedIntArray = new int[array1.Length + array2.Length];
            int array1Begin = 0;
            int array2Begin = 0;

            for (int i = 0; i < sortedIntArray.Length; i++)
            {
                if (array1Begin > array1.Length - 1)
                {
                    sortedIntArray[i] = array2[array2Begin];
                    array2Begin++;
                }
                else if (array2Begin > array2.Length - 1)
                {
                    sortedIntArray[i] = array1[array1Begin];
                    array1Begin++;
                }
                else if (array1[array1Begin] < array2[array2Begin])
                {
                    sortedIntArray[i] = array1[array1Begin];
                    array1Begin++;
                }
                else
                {
                    sortedIntArray[i] = array2[array2Begin];
                    array2Begin++;
                }
            }
            return sortedIntArray;
        }

        static int BinarySearch(int x, int[] sortedArray)
        {
            int n = sortedArray.Length;
            if (n == 0)
            {
                return -1;
            }
            else if (n == 1)
            {
                if (sortedArray[0] == x)
                {
                    return sortedArray[0];
                }
                return -1;
            }
            else
            {
                int middle = (int)Math.Ceiling((double)n / 2);

                if (sortedArray[middle] == x)
                {
                    return sortedArray[middle];
                }
                else if (sortedArray[middle] > x)
                {
                    return BinarySearch(x, SubArray(sortedArray, 0, middle - 1));
                }
                else
                {
                    return BinarySearch(x, SubArray(sortedArray, middle + 1, sortedArray.Length - 1));
                }
            }
        }

        static int[] SubArray(int[] intArray, int startIndex, int endIndex)
        {
            if (startIndex > endIndex || startIndex < 0 || endIndex > intArray.Length - 1)
            {
                return new int[0];
            }
            int[] subArray = new int[endIndex - startIndex + 1];

            for (int i = startIndex; i <= endIndex; i++ )
            {
                subArray[i - startIndex] = intArray[i];
            }

            return subArray;
        }


        static void Main(string[] args)
        {
            int[] intArray = { 9, 7, 3, 1, 2, 4, 5, 0, 8, 6 };
            //InsertionSort(ref intArray);
            MergeSort(ref intArray);

            Print(BinarySearch(11, intArray) + "");

            PrintIntArray(intArray);
            //Print(T(11) + " ");

        }
    }
}
