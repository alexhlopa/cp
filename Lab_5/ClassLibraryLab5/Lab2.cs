using System;
using System.Collections.Generic;

namespace ClassLibraryLab5
{
    public class Lab2
    {
        public string GetResult(string stringN)
        {
            var n = Shared.ConvertToInt32(stringN, "n");
            Shared.CheckCondition(n, x => n >= 1 && n <= 30, "Variable \"n\" must meet the condition: 1 <= n <= 30");
            return $"Кількість {n}-значних чисел, що можна скласти: " + GetResult(n);
        }

        private int GetResult(int n)
        {
            if (n == 1)
                return 2; //there are 2 one-digit numbers 5, 9
            if (n == 2)
                return 4; //there are 4 two-digit numbers 55, 99, 59, 95

            //there are 6 three-digit numbers 559, 995, 955, 599, 959, 595.....
            return GetResult(n - 1) + GetResult(n - 2);
        }
    }
}
