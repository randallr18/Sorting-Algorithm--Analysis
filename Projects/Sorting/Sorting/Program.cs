using System;
using System.Diagnostics;
using static System.Console;
using System.IO;
using System.Linq;

namespace Sorting
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            SortImplementation[] sorters = {Sort.quick_sort, Sort.merge_sort, Sort.insertion_sort, Sort.bubble_sort, Sort.radix_sort};

            foreach (SortImplementation sorter in sorters)
                WriteLine(Sort.check_for_correctness(sorter));



            StreamWriter w = new StreamWriter("sorting_data.txt");

            w.WriteLine("N\t\tQS\tMS\tIS\tBS\tRS");

            //Amount of tests per algorithms by increasing by increments of 100
            int tests = 10;

            TimeSpan[,] sorting_data = new TimeSpan[5, tests];

            for (int i = 1; i <= tests; i++)
            {
                int[] data1 = seed_data(i * 1000);

                for (int j = 0; j < sorters.Length ; j++)
                  sorting_data[j, i - 1] = Sort.test(sorters[j], copy_data(data1));
            }

            for (int i = 0; i < tests; i++)
            {
                string data = "";
                data += ((i + 1) * 1000);
                data += "\t\t";
                for (int k = 0; k < 5; k++)
                {
                    data += (sorting_data[k, i].TotalMilliseconds);
                    data += "\t";
                }
                w.WriteLine(data);
            }

            w.Close();

        }





        public static int[] copy_data(int[] data)
        {
            int[] copy = new int[data.Length];
            for(int i = 0; i < copy.Length; i ++)
            {
                copy[i] = data[i];
            }
            return copy;
        }

        public static int[] seed_data(int amount)
        {
            int[] data = new int[amount];
            Random rnd = new Random();

            for (int i = 0; i < data.Length; i++)
            {
                int num = rnd.Next(1, 500000);
                data[i] = num;
            }

            return data;
        }




        public delegate void SortImplementation(int[] data, int n, int p);

        class Sort
        {

            public static TimeSpan test(SortImplementation s, int[] data)
            {
                //Uncomment the print lines for a view of the data before or after the sort 

                Stopwatch sw = new Stopwatch();
                sw.Start();
                //PrintIntegerArray(data);
                s(data, 0, data.Length - 1);
                //PrintIntegerArray(data);
                sw.Stop();
                return sw.Elapsed;
            }

            public static bool check_for_correctness(SortImplementation s)
            {
                int[] data = seed_data(1000);
                int[] data_copy = copy_data(data);
                s(data, 0, data.Length - 1);

                for(int i = 0; i < data.Length - 1; i++)
                {
                    if (!data.Contains(data_copy[i]) || data[i + 1] < data[i]) return false;
                }

                if (!data.Contains(data_copy[data.Length - 1]) || data[data.Length - 1] < data[data.Length - 2]) return false;

                return true;
            }


            public static void PrintIntegerArray(int[] array)
            {
                foreach (int i in array)
                {
                    Console.Write(i.ToString() + "  ");
                }
            }

            //BUBBLE SORT

            public static void bubble_sort(int[] data, int n, int m)
            {
                for (int i = 0; i < data.Length - 1; i++)
                {
                    for (int k = 0; k < data.Length - 1; k++)
                    {
                        if (data[k] > data[k + 1])
                        {
                            int temp = data[k];
                            data[k] = data[k + 1];
                            data[k + 1] = temp;
                        }
                    }
                }

            }


            //INSERTION SORT

            public static void insertion_sort(int[] data, int n, int m)
            {
                for (int i = 0; i < data.Length - 1; i++)
                {
                    for (int j = i + 1; j > 0; j--)
                    {
                        if (data[j] < data[j - 1])
                        {
                            int temp = data[j - 1];
                            data[j - 1] = data[j];
                            data[j] = temp;
                        }
                    }
                }
            }


            //MERGE SORT

            public static void merge_sort(int[] data, int p, int r)
            {
                if (p < r)
                {
                    int q = (p + r) / 2;
                    merge_sort(data, p, q);
                    merge_sort(data, q + 1, r);
                    merge(data, p, q, r);
                }

            }

            private static void merge(int[] data, int p, int q, int r)
            {
                int i, j, k;
                int n1 = q - p + 1;
                int n2 = r - q;
                int[] L = new int[n1];
                int[] R = new int[n2];
                for (int l = 0; l < n1; l++)
                {
                    L[l] = data[p + l];
                }
                for (int m = 0; m < n2; m++)
                {
                    R[m] = data[q + 1 + m];
                }
                i = 0;
                j = 0;
                k = p;
                while (i < n1 && j < n2)
                {
                    if (L[i] <= R[j])
                    {
                        data[k] = L[i];
                        i++;
                    }
                    else
                    {
                        data[k] = R[j];
                        j++;
                    }
                    k++;
                }
                while (i < n1)
                {
                    data[k] = L[i];
                    i++;
                    k++;
                }
                while (j < n2)
                {
                    data[k] = R[j];
                    j++;
                    k++;
                }
            }



            //RADIX SORT

            public static void radix_sort(int[] data, int o, int n)
            {
                n++;
                int m = get_max(data, n);

                for (int exp = 1; m / exp > 0; exp *= 10)
                {
                    count_sort(data, n, exp);
                }

            }

            private static void count_sort(int[] data, int n, int exp)
            {
                int[] output = new int[n];
                int[] count = new int[10];

                for (int i = 0; i < 10; i++)
                {
                    count[i] = 0;
                }

                for (int i = 0; i < n; i++)
                {
                    count[(data[i] / exp) % 10]++;
                }

                for (int i = 1; i < 10; i++)
                {
                    count[i] += count[i - 1];
                }


                for (int i = n - 1; i >= 0; i--)
                {
                    output[count[(data[i] / exp) % 10] - 1] = data[i];
                    count[(data[i] / exp) % 10]--;
                }

                for (int i = 0; i < n; i++)
                {
                    data[i] = output[i];
                }
            }

            private static int get_max(int[] data, int n)
            {
                int mx = data[0];
                for(int i = 1; i < n; i++)
                {
                    if(data[i] > mx)
                    {
                        mx = data[i];
                    }
                }
                return mx;
            }


            //QUICK SORT

            public static void quick_sort(int[] A, int left, int right)
            {
                if (left > right || left < 0 || right < 0) return;

                int index = partition(A, left, right);

                if (index != -1)
                {
                    quick_sort(A, left, index - 1);
                    quick_sort(A, index + 1, right);
                }
            }

            private static int partition(int[] A, int left, int right)
            {
                if (left > right) return -1;

                int end = left;

                int pivot = A[right];    // choose last one to pivot, easy to code
                for (int i = left; i < right; i++)
                {
                    if (A[i] < pivot)
                    {
                        swap(A, i, end);
                        end++;
                    }
                }

                swap(A, end, right);

                return end;
            }

            private static void swap(int[] A, int left, int right)
            {
                int tmp = A[left];
                A[left] = A[right];
                A[right] = tmp;
            }


        }



        }
    }



