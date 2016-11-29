using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleTestBed
{

    class Program
    {

        static void AlmostSorted()
        {
            int n = int.Parse(Console.ReadLine());
            string[] sArray = Console.ReadLine().Split(' ');

            int[] arr = Array.ConvertAll(sArray, s => Convert.ToInt32(s));


            int swapr = Bubble(arr, n, true);

            if (swapr == -1)
            {
                Console.WriteLine("yes");
                return;
            }

            int swapl = Bubble(arr, n, false);

            int temp = arr[swapr];
            arr[swapr] = arr[swapl];
            arr[swapl] = temp;

            int checkit = Bubble(arr, n, true);

            if (checkit == -1)
            { 
                Console.WriteLine("yes\n" + $"swap {swapr + 1} {swapl + 1}");
                return;
            }

            int swaplSave = swapl;
            int swaprSave = swapr;

            do
            {
                if (swapl - swapr <= 1)
                {
                    Console.WriteLine("no\n");
                    return;
                }

                swapr++;
                swapl--;

                temp = arr[swapr];
                arr[swapr] = arr[swapl];
                arr[swapl] = temp;

                checkit = Bubble(arr, n, true);

                if (checkit == -1)
                {
                    Console.WriteLine("yes\n" + $"reverse {swaprSave + 1} {swaplSave + 1}");
                    return;
                }
            }
            while (true);


        }

        static int Bubble(int[] arr, int n, bool direction)
        {
            if (direction) // right
            {
                for (int i = 0; i < n - 1; i++)
                {
                    if (arr[i] < arr[i + 1]) continue;
                    return i;
                }

                return -1;
            }
            else // left
            {
                for (int i = n - 1; i > 0; i--)
                {
                    if (arr[i] > arr[i - 1]) continue;
                    return i;
                }

                return -1;
            }

        }

        static void Main(string[] args)
        {
                while (true)
                {
                    AlmostSorted(); 
                }
        }

        delegate int shit (int x);
        enum yahoo { a, b, c};

        static int quip(int x)
        {
            return 5;
        }

        static bool PalindromeCheck(string pdrome)
        {
            // Remove any whitespace off ends (so we also handles palindromic phrases) and make case insensitive. 
            // In this implementation, for simplicity: a null -> empty string -> palindrome. 

            pdrome = pdrome.Trim().ToUpper() ?? "";   

            if (pdrome.Length <= 1) return true;  // Success!

            if (pdrome.EndsWith(pdrome.Substring(0, 1)))
                return PalindromeCheck(pdrome.Substring(1, pdrome.Length - 2));

            return false;
        }

        
        static void PointCounter()
        {

            string[] sAlice = Console.ReadLine().Split(' ').ToArray();
            string[] sBob = Console.ReadLine().Split(' ').ToArray();

            int[] alice = Array.ConvertAll(sAlice, (s) => Int32.Parse(s));
            int[] bob = Array.ConvertAll(sBob, (s) => Int32.Parse(s));

            
            var results = alice.Zip<int, int, string>(bob, (alicex, boby) => { if (alicex > boby) return "Alice"; if (alicex < boby) return "Bob"; return "Tie"; });


            Console.WriteLine("{0} {1}", results.Count((s)=>s == "Alice"), results.Count((s) => s == "Bob"));
        }

        static void ArraySum()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] arr_temp = Console.ReadLine().Split(' ');
            
            Int64 [] arr = Array.ConvertAll(arr_temp, Int64.Parse);
            Console.WriteLine(arr.Sum());           
        }
        
        static void MatrixDiagonals()
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int a_i = 0; a_i < n; a_i++)
            {
                string[] a_temp = Console.ReadLine().Split(' ');
                for (int i = 0; i < n; i++)
                {
                    matrix[a_i, i] = int.Parse(a_temp[i]);                    
                }
            }

            int diff = 0;
            for(int i = 0; i < n; i++)
            {
                diff += matrix[i, i] - matrix[i, n - i - 1];
            }

            int absDiff = Math.Abs(diff);

            Console.WriteLine(absDiff);
        }

        static void PlusMinus()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] arr_temp = Console.ReadLine().Split(' ');
            int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);

            decimal size = n;

            var negs = from ng in arr where ng < 0 select ng;
            var pos = from ps in arr where ps > 0 select ps;
            decimal zeros = size - negs.Count() - pos.Count();

            decimal dnegs = (decimal)negs.Count() / size;
            decimal dpos = (decimal)pos.Count() / size;
            decimal dzeros = zeros / size;

            Console.WriteLine(dpos);
            Console.WriteLine(dnegs);
            Console.WriteLine(dzeros);
        }

        static void PrintStaircase()
        {
            int n = Convert.ToInt32(Console.ReadLine());

            
            for (int i = n - 1; i >= 0 ; i--)
            {
                string step = "".PadLeft(i, ' ').PadRight(n, '#');
                Console.WriteLine(step);
            }
        }

        static void ChangeTimeFormat()
        {
            string time = Console.ReadLine();
            DateTime dt = DateTime.Parse(time);
            Console.WriteLine(dt.ToString("HH:mm:ss"));
        }

        static void CircularArray()
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int k = Convert.ToInt32(tokens_n[1]);
            int q = Convert.ToInt32(tokens_n[2]);
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] arr = Array.ConvertAll(a_temp, Int32.Parse);

            Queue<int> qur = new Queue<int>(arr.Reverse());
            for (int i = 0; i < k; i++)
            {
                qur.Enqueue(qur.Dequeue());
            }

            arr = qur.ToArray().Reverse().ToArray();

            for (int i = 0; i < q; i++)
            {
                int m =Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(arr[m]);
            }
        }

        static void Viral()
        {
            const int peopleStart = 5;
            const int peopleShared = 3;

            long numPeopleTargets = peopleStart;
            long likedCount = 0;
            long floor;
            int numDays;

            numDays = int.Parse(Console.ReadLine());

            for (int i = 0; i < numDays; i++)
            {
                floor = numPeopleTargets / 2;
                likedCount += floor;
                numPeopleTargets = floor * peopleShared;
            }

            Console.WriteLine(likedCount);
        }

        static void DivisibleSumPairs()
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int k = Convert.ToInt32(tokens_n[1]);
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] ordArr = Array.ConvertAll(a_temp, Int32.Parse);

            int count = 0;

 
            for (int i = 0; i < n-1; i++)
            {
                for (int ji = i + 1; ji < n; ji++)
                {
                    if (i < ji && (ordArr[ji] + ordArr[i]) % k == 0) count++;
                }
            }

            Console.WriteLine(count);
        }

        static void Angry()
        {
            int t = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < t; a0++)
            {
                string[] tokens_n = Console.ReadLine().Split(' ');
                int n = Convert.ToInt32(tokens_n[0]);
                int k = Convert.ToInt32(tokens_n[1]);
                string[] a_temp = Console.ReadLine().Split(' ');
                int[] a = Array.ConvertAll(a_temp, Int32.Parse);

                var lates = from lt in a where lt > 0 select lt;

                Console.WriteLine(n - lates.Count() >= k ? "NO" : "YES");
            }
        }

        static void CutSticks()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] arr_temp = Console.ReadLine().Split(' ');
            int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);



            while(arr.Length > 0)
            {
                int min = arr.Min();
                int index = 0;

                foreach (int element in arr)
                {
                    arr[index++] -= min;
                }
                arr = Array.FindAll(arr, i => i != 0);
                Console.WriteLine(index); 
            }
        }

       
    }
}
