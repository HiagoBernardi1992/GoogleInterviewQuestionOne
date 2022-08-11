using System;
using System.Text;

namespace GoogleInterviewQuestionOne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //In this exercise, you're going to decompress a compressed string.
            //Your input is a compressed string of the format number[string] and the decompressed output form should be the string written number times. For example:
            //The input
            //3[abc]4[ab]c
            //Would be output as
            //abcabcabcababababc
            //Other rules
            //Number can have more than one digit.For example, 10[a] is allowed, and just means aaaaaaaaaa
            //One repetition can occur inside another. For example, 2[3[a]b] decompresses into aaabaaab
            //Characters allowed as input include digits, small English letters and brackets[].
            //Digits are only to represent amount of repetitions.
            //Letters are just letters.
            //Brackets are only part of syntax of writing repeated substring.
            //Input is always valid, so no need to check its validity.
            //Learning objectives
            //This question gives you the chance to practice with strings, recursion, algorithm, compilers, automata, and loops.It’s also an opportunity to work on coding with better efficiency.
            string test1 = "3[abc]4[ab]c";
            string test2 = "2[3[a]b]";

            var comparable1 = GetFullString(test1);
            var comparable2 = GetFullString(test2);

            Console.WriteLine("Experado :" + "abcabcabcababababc");
            Console.WriteLine("Resultado :" + comparable1);
            Console.WriteLine("Experado :" + "aaabaaab");
            Console.WriteLine("Resultado :" + comparable2);

            string GetFullString(string input)
            {
                StringBuilder sb = new StringBuilder();
                decompress(input, 0, sb);
                return sb.ToString();
            }

            int decompress(String input, int start, StringBuilder sb)
            {
                StringBuilder times = new StringBuilder();
                StringBuilder current = new StringBuilder();

                int i = start;
                while (i < input.Length)
                {
                    while (Char.IsDigit(input[i]))
                    {
                        times.Append(input[i]);
                        i++;
                    }

                    if (input[i] == '[' && times.Length > 0)
                    {
                        if (current.Length > 0)
                        {
                            sb.Append(current);
                            current = new StringBuilder();
                        }

                        i = decompress(input, i + 1, current);

                        int repeatTimes = int.Parse(times.ToString());
                        for (int j = 0; j < repeatTimes; j++)
                        {
                            sb.Append(current);
                        }

                        current = new StringBuilder();
                        times = new StringBuilder();
                    }
                    else if (input[i] == ']')
                    {
                        return i + 1;
                    }
                    else
                    {
                        sb.Append(input[i]);
                        i++;
                    }
                }

                return i;
            }
        }
    }
}
