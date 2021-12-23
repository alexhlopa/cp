using System;

namespace ClassLibraryLab5
{
    public class Lab1
    {
        public string GetResult(string stringN, string stringK)
        {
            var x = Shared.ConvertToInt32(stringN, "x");
            var k = Shared.ConvertToInt32(stringK, "k");
            var n = Convert.ToInt32(Math.Pow(x, 2)); //amount of squares
            int SUA = (x - 1) * 2; //squares under attack with one rook
            int[] rook_permutations = new int[k]; //amount of permutations for each rook
            int sum = 1;

            for (int i = 0; i < k; i++)
            {
                rook_permutations[i] = (n - i) - (SUA * i - (i * (i - 1)));
                sum *= rook_permutations[i];

            }

           

            return $"Результат: {sum / GetFactorial(k)}";
        }

       
        private int GetFactorial(int value)
        {
            if (value >= 0 && value <= 12)
            {
                int result = 1;
                for (int i = value; i > 1; i--)
                    result *= i;
                return result;
            }
            throw new ArgumentException("Finding the factorial for a number impossible due to violation of the condition.");
        }
    }
}
