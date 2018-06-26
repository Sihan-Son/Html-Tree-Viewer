using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HTMLBrowser
{
    class Program
    {
        static void Main(string[] args)
        {
            var bracketError = 0;

            string[] test = File.ReadAllLines(@"D:\Project\html-Browser\SummerProject\HTMLBrowser\HTMLBrowser\a.html"); // html 문서 위치
            string txt = File.ReadAllText(@"D:\Project\html-Browser\SummerProject\HTMLBrowser\HTMLBrowser\a.html");

            for (int i = 0; i < test.Length; i++)
            {
                test[i] = test[i].Replace("</ ", "</");
                test[i] = test[i].Replace("< /", "</");
                test[i] = test[i].Replace("< / ", "</");
            }

            txt = txt.Replace("    ", " ");
            txt = txt.Replace("\n", " ");

            string[] tag = txt.Split(' ');

            for(int i = 0; i<tag.Length; i++)
            {
                Console.WriteLine(tag[i]);
            }


            //Stack<string> bracket = new Stack<string>();

            //for (int i = 0; i < test.Length; i++)
            //{
            //    for (int j = 0; j < test[i].Length; j++)
            //    {
            //        if (test[i][j].ToString() == "<")
            //        {
            //            bracket.Push(test[i][j].ToString());
            //        }

            //        if (test[i][j].ToString() == ">")
            //        {

            //            try
            //            {
            //                bracket.Pop(); //stack이 비어 있으면 에러 발생
            //            }
            //            catch (Exception e)
            //            {
            //                bracketError++;
            //            }

            //        }
            //    }

            //}


            //if (bracket.Count() != 0)
            //    Console.WriteLine("닫히지 않은 괄호가 " + bracket.Count() + "개 존재합니다");


            //else if (bracketError != 0)
            //    Console.WriteLine(bracketError + "개의 괄호가 짝이 맞지 않습니다");
            //else
            //    Console.WriteLine("모든 괄호의 짝이 맞습니다\n\n");

            //Console.WriteLine();
            //for (int i = 0; i < test.Length; i++)
            //    Console.WriteLine(test[i]);
            //Console.WriteLine();

        }
    }
}
