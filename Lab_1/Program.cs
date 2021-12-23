using System;
using System.IO;


namespace Lab_1
{
    class Program
    {

        static int Factorial(int x)
        {
            if (x == 0)
            {
                return 1;
            }
            else
            {
                return x * Factorial(x - 1);
            }
        }

        // file checking
        static void FileChecking(string input_file)
        {

            if (input_file.Length == 0)
            {
                throw new Exception("File is empty");
            }

            try
            {
                string[] input_line = input_file.Split();
                if (input_line.Length != 2)
                {
                    throw new Exception("Amount of arguments should be equal 2");
                }
                int n = Convert.ToInt32(input_line[0]);
                int k = Convert.ToInt32(input_line[1]);

                if (k > 8)
                {
                    throw new Exception("Amount of rooks should not be greater 8");
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("Overflow Exception");
                return;
            }
            catch (FormatException)
            {
                Console.WriteLine("Format Exception");
                return;
            }
        }

        static void Main(string[] args)
        {

            StreamReader read = new StreamReader("../../../Files/INPUT.txt");
            string input_file = read.ReadLine();
            FileChecking(input_file);
            string[] input_line = input_file.Split();



            int x = Convert.ToInt32(input_line[0]); //desk size
            int n = Convert.ToInt32(Math.Pow(x, 2)); //amount of squares 
            int k = Convert.ToInt32(input_line[1]); //amount of rooks
            int SUA = (x - 1) * 2; //squares under attack with one rook
            int[] rook_permutations = new int[k]; //amount of permutations for each rook
            int sum = 1;

            for (int i = 0; i < k; i++)
            {
                rook_permutations[i] = (n - i) - (SUA * i - (i * (i - 1)));
                sum *= rook_permutations[i];

            }

            using (StreamWriter write = new StreamWriter("../../../Files/OUTPUT.txt", false, System.Text.Encoding.Default))
            {
                write.Write(sum / Factorial(k));
            }
            Console.WriteLine(sum / Factorial(k));


        }
    }
}