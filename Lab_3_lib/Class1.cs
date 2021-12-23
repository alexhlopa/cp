using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Lab_3_lib
{
    public class Class1
    {
        public string alph = "ABCDEFGHI";
        public string even = "ACEGI";
        public string odd = "BDFH";
        public string input_path;
        public string output_path;

        public string check_state(string pos)
        {
            var letter = pos[0];
            var number = Convert.ToInt32(pos[1].ToString());

            if (number % 2 == 0)
            {
                if (even.Contains(letter))
                {
                    return "horse";
                }
                else
                {
                    return "elephant";
                }
            }
            else if (odd.Contains(letter))
            {
                return "horse";
            }
            else
            {
                return "elephant";
            }
        }

        public List<String> estimate_elph_moves(string pos)
        {

            var letter = alph.IndexOf(pos[0]);
            var number = Convert.ToInt32(pos[1].ToString());


            int[][] moves =
            {
                new int[] {-1, 2},
                new int[] { 1, 2 },
                new int[] { 2, 1 },
                new int[] { 2, -1 },
                new int[] { 1, -2 },
                new int[] { 1, -2 },
                new int[] { -2, -1 },
                new int[] { -2, 1 }
            };


            var new_moves = new List<int[]>();
            var new_moves_filtered = new List<int[]>();
            var result_moves = new List<string>();

            for (int i = 0; i < 8; i++)
            {
                new_moves.Add(new int[2] { letter + moves[i][0], number + moves[i][1] });
            }


            foreach (var x in new_moves)
            {
                if (0 <= x[0] && x[0] <= 8 && 0 < x[1] && x[1] <= 9)
                {
                    new_moves_filtered.Add(new int[2] { x[0], x[1] });
                }
            }

            foreach (var x in new_moves_filtered)
            {
                result_moves.Add(alph[x[0]].ToString() + x[1].ToString());
            }

            return result_moves;

        }

        public int estimate_distance(string a, string b)
        {
            var a_letter = alph.IndexOf(a[0]);
            var a_number = Convert.ToInt32(a[1].ToString());
            var b_letter = alph.IndexOf(b[0]);
            var b_number = Convert.ToInt32(b[1].ToString());

            return (Math.Abs(b_number - a_number) + Math.Abs(b_letter - a_letter));

        }

        public List<String> check_diagonal(string b)
        {
            var letter = alph.IndexOf(b[0]);
            var number = Convert.ToInt32(b[1].ToString());

            int[][] moves_0 =
            {
                new int[] { -1, 1 },
                new int[] { 1, 1 },
                new int[] { 1, -1 },
                new int[] { -1, -1 }
            };


            var moves_1 = new List<int[]>();
            var moves_1_filtered = new List<int[]>();
            var result_moves = new List<string>();

            foreach (var item in moves_0)
            {
                moves_1.Add(new int[2] { item[0] + letter, item[1] + number });
                for (int i = 0; i < 10; i++)
                {
                    moves_1.Add(new int[2] { item[0] + moves_1.Last()[0], item[1] + moves_1.Last()[1] });
                }
            }

            foreach (var x in moves_1)
            {
                if (0 <= x[0] && x[0] <= 8 && 0 < x[1] && x[1] <= 9)
                {
                    moves_1_filtered.Add(new int[2] { x[0], x[1] });
                }
            }

            moves_1_filtered.Insert(0, (new int[2] { letter, number }));

            foreach (var x in moves_1_filtered)
            {
                result_moves.Add(alph[x[0]].ToString() + x[1].ToString());
            }

            return result_moves;


        }

        public void check_possibility(string a, string b)
        {
            if (a == b)
            {
                using (StreamWriter write = new StreamWriter(this.output_path, false, System.Text.Encoding.Default))
                {
                    write.Write("0");
                }
                System.Environment.Exit(0);
            }

            if ((check_state(a) == "elephant" && check_state(b) == "horse") || (check_state(a) == "horse" && check_state(b) == "horse"))
            {
                using (StreamWriter write = new StreamWriter(this.output_path, false, System.Text.Encoding.Default))
                {
                    write.Write("-1");
                }
                System.Environment.Exit(0);
            }
        }

        public void main_code()
        {
            string a;
            string b;

            using (StreamReader sr = new StreamReader(this.input_path))
            {
                var str = sr.ReadToEnd();
                a = str[0] + str[1].ToString();
                b = str[3] + str[4].ToString();
                
            }

            check_possibility(a, b);

            if (check_state(a) == "horse")
            {
                var moves = estimate_elph_moves(a);
                var diagonals = check_diagonal(b);
                var crossing = moves.Intersect(diagonals);

                if (crossing.Count() > 0)
                {
                    if (crossing.Contains(diagonals[0]))
                    {
                        using (StreamWriter write = new StreamWriter(this.output_path, false, System.Text.Encoding.Default))
                        {
                            write.Write("1");
                        }
                    }

                    else
                    {
                        using (StreamWriter write = new StreamWriter(this.output_path, false, System.Text.Encoding.Default))
                        {
                            write.Write("2");
                        }
                    }
                }

                else
                {
                    using (StreamWriter write = new StreamWriter(this.output_path, false, System.Text.Encoding.Default))
                    {
                        write.Write("3");
                    }
                }
            }

            else
            {
                var diagonals = check_diagonal(b);
                if (diagonals.Contains(b))
                {
                    using (StreamWriter write = new StreamWriter(this.output_path, false, System.Text.Encoding.Default))
                    {
                        write.Write("1");
                    }
                }

                else
                {
                    using (StreamWriter write = new StreamWriter(this.output_path, false, System.Text.Encoding.Default))
                    {
                        write.Write("2");
                    }
                }
            }
        }

        public Class1(string path)
        {

            if (!path.Contains(".txt"))
            {
                this.input_path = path + "/INPUT.txt";
                this.output_path = path + "/OUTPUT.txt";
            }

            if (path.Contains("|"))
            {
                this.input_path = path.Substring(0, path.IndexOf("|"));
                this.output_path = path.Substring(path.IndexOf("|") + 1, path.Length);
            }


        }
    }
}

