using System;
using System.IO;
using System.Linq;

namespace Lab_2
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] stringarr = new string[2];

            using (StreamReader sr = new StreamReader("../../../Files/INPUT.txt", System.Text.Encoding.Default))
            {
                string line;
                int i = 0;

                while ((line = sr.ReadLine()) != null)
                {
                    stringarr[i] = line;
                    i++;
                }
            }

            int[] numbers = stringarr[1].Split(' ').Select(int.Parse).ToArray();
            int result = 0;
            int resultWithCheat = 0;

            for (int i = 0; i < numbers.Length - 1; i++)
            {

                if (numbers[i + 1] - numbers[i] > 0)
                {
                    result += Math.Abs(numbers[i + 1] - numbers[i]);

                }


                if ((i + 2) < numbers.Length)
                {
                    resultWithCheat += 3 * (numbers[i + 2] - numbers[i]);
                }


            }

            using (StreamWriter write = new StreamWriter("../../../Files/OUTPUT.txt", false, System.Text.Encoding.Default))
            {
                if (resultWithCheat < result)
                {
                    write.Write(resultWithCheat);
                }
                else
                {
                    write.Write(result);
                }
            }
        }
    }
}
