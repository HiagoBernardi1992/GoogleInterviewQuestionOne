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
                //variable to know how many times I have to iterate the string who comes
                StringBuilder times = new StringBuilder();
                //variable to storage the string that I have to print by the times
                StringBuilder current = new StringBuilder();

                int i = start;
                while (i < input.Length)
                {
                    //if the digir of the string is a number
                    while (Char.IsDigit(input[i]))
                    {
                        //I will concat it untilI get all the characters of the number
                        times.Append(input[i]);
                        i++;
                    }

                    //given the interation
                    //if is [ is becausa I know that I previous storage the number
                    //I also check the length for string inptu like that "["
                    if (input[i] == '[' && times.Length > 0)
                    {
                        //I check if the string that I want to print has already something
                        if (current.Length > 0)
                        {
                            //is is the case I will storage that and begin another to interate
                            sb.Append(current);
                            current = new StringBuilder();
                        }

                        //I call the same function I finish the interator and the cald from inside to out
                        i = decompress(input, i + 1, current);

                        //Now I know the times I do a loop to concat that
                        int repeatTimes = int.Parse(times.ToString());
                        for (int j = 0; j < repeatTimes; j++)
                        {
                            sb.Append(current);
                        }

                        //here I just clean the variables to a new interation
                        current = new StringBuilder();
                        times = new StringBuilder();
                    }
                    //Here a check when is close to begin another one or close the while
                    else if (input[i] == ']')
                    {
                        return i + 1;
                    }
                    //Here I just know that i have to concat.
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
