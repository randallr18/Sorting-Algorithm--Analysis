//using System;
//namespace Sorting
//{
//    public class Unused_code
//    {
//        public Unused_code()
//        {
//        }
//    }
//}




//WriteLine(Sort.check_for_correctness(Sort.quick_sort));
//WriteLine(Sort.check_for_correctness(Sort.merge_sort));
//WriteLine(Sort.check_for_correctness(Sort.insertion_sort));
//WriteLine(Sort.check_for_correctness(Sort.bubble_sort));
//WriteLine(Sort.check_for_correctness(Sort.radix_sort));
//WriteLine(Sort.check_for_correctness(bogus_sort));



//for (int i = 1; i <= tests; i++)
//{
//    int[] data1 = seed_data(i * 10);
//    int[] data2 = copy_data(data1);
//    int[] data3 = copy_data(data1);
//    int[] data4 = copy_data(data1);
//    int[] data5 = copy_data(data1);
//    int index = i - 1;
//    sorting_data[0, index] = Sort.test(Sort.quick_sort, data1);
//    sorting_data[1, index] = Sort.test(Sort.merge_sort, data2);
//    sorting_data[2, index] = Sort.test(Sort.insertion_sort, data3);
//    sorting_data[3, index] = Sort.test(Sort.bubble_sort, data4);
//    sorting_data[4, index] = Sort.test(Sort.radix_sort, data5);
//}


//static void HandleSortImplemntation(int[] data, int n, int p)
//{
//}
//static void HandleSortImplemntation1(int[] data, int n, int p)
//{
//}


//    public static void quick_sort(int[] data, int start, int end)
//    {
//        int i;
//        if (start < end)
//        {
//            i = Partition(data, start, end);
//            quick_sort(data, start, i - 1);
//            quick_sort(data, i + 1, end);
//        }
//    }
//    private static int Partition(int[] data, int start, int end)
//    {
//        int temp;
//        int p = data[end];
//        int i = start - 1;
//        for (int j = start; j <= end - 1; j++)
//        {
//            if (data[j] <= p)
//            {
//                i++;
//                temp = data[i];
//                data[i] = data[j];
//                data[j] = temp;
//            }
//        }
//        temp = data[i + 1];
//        data[i + 1] = data[end];
//        data[end] = temp;
//        return i + 1;
//    }

//string[] sorting_algorithms = { "Quick Sort", "Merge Sort", "Insertion Sort", "Bubble Sort", "Radix Sort" };





//for(int i = 0; i < 5; i ++)
//{
//    Console.WriteLine(sorting_algorithms[i]);
//    for(int k = 0; k < tests; k++)
//    {
//        Console.WriteLine(sorting_data[i, k]);
//    }
//    Console.WriteLine("");

//}




//public static void bogus_sort(int[] data, int n, int m)
//{
//    for (int i = 0; i < data.Length - 1; ++i)
//        data[i] = 0;
//}