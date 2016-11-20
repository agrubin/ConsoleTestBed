using System;
using System.Linq;

namespace ConsoleTestBed
{

    class Program
    {
   
        static void Main(string[] args)
        {
            MatrixDiagonals();
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
    }
}
