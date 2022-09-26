using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionSeconProject
{
    static class Brackets
    {
        public static void Run()
        {
            List<char> bracketsOpen = new() { '[', '{', '(' };
            List<char> bracketsClose = new() { ']', '}', ')' };

            Stack<char> brackets = new Stack<char>();



            while (true)
            {
                Console.WriteLine("1 - input string");
                Console.WriteLine("0 - exit");
                string choise = Console.ReadLine();
                if (choise == "0") break;

                String str;
                Console.Write("input string: ");
                str = Console.ReadLine();
                bool isError = false;

                for (int i = 0; i < str.Length; i++)
                {
                    if (!(bracketsOpen.Contains(str[i]) || bracketsClose.Contains(str[i])))
                        continue;
                    if (bracketsOpen.Contains(str[i]))
                        brackets.Push(str[i]);
                    if (bracketsClose.Contains(str[i]))
                    {
                        if (brackets.Count == 0)
                        {
                            isError = true;
                            break;
                        }

                        char bracketTop = brackets.Peek();
                        int indexClose = bracketsClose.FindIndex(0, bracketsClose.Count, b => b == str[i]);
                        int indexOpen = bracketsOpen.FindIndex(0, bracketsOpen.Count, b => b == bracketTop);
                        if (indexClose != indexOpen)
                        {
                            isError = true;
                            break;
                        }

                        brackets.Pop();
                    }
                }
                if (!isError)
                    isError = brackets.Count != 0;

                if (isError)
                    Console.WriteLine("Error!");
                else
                    Console.WriteLine("Not Error!");
            }
        }
    }
}
