using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLBrowser
{
    class Program
    {
        static void Main(string[] args)
        {
            string test = "<p> < /p>";
            var bracketError = 0;

            test = test.Replace("</ ","</");
            test = test.Replace("< /", "</");

            Stack<string> bracket = new Stack<string>();

            for (int i =0; i<test.Length;i++)
            {
                if(test[i].ToString() == "<" )
                {
                    bracket.Push(test[i].ToString());
                }

                if (test[i].ToString() == ">")
                {
                 
                    try
                    {
                        bracket.Pop();
                    }
                    catch (Exception e)
                    {
                        bracketError++;
                    }

                }

            }



            if (bracketError != 0)
                Console.WriteLine(bracketError + "개의 괄호가 짝이 맞지 않습니다");
            else
                Console.WriteLine("모든 괄호의 짝이 맞습니다");

            Console.WriteLine(test);

        }
    }
}
