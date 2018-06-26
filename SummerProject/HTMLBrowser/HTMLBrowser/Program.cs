using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;

namespace HTMLBrowser
{
    class Program
    {
        static void Main(string[] args)
        {
            //에러 개수 count
            var bracketError = 0;
            
            //html 문서 읽어오기
            string[] test = File.ReadAllLines(@"D:\Project\html-Browser\SummerProject\HTMLBrowser\HTMLBrowser\a.html"); // html 문서 위치
            string txt = File.ReadAllText(@"D:\Project\html-Browser\SummerProject\HTMLBrowser\HTMLBrowser\a.html");


            Stack<string> bracket = new Stack<string>(); // <> 짝 확인
            Stack<int> lineNo = new Stack<int>(); // error 발생 줄 <가 많을 때
            ArrayList lines = new ArrayList(); // error 발생 줄 > 가 많을 때
            ArrayList linesNo = new ArrayList(); // stack에 들어간 줄수 정방향으로 바꾸기용
            //중복 줄 1번만 출력
            lines.Add(0); 
            lineNo.Push(0);

            //포맷 수정 html 코딩 스타일 때문에
            for (int i = 0; i < test.Length; i++)
            {
                test[i] = test[i].Replace("</ ", "</");
                test[i] = test[i].Replace("< /", "</");
                test[i] = test[i].Replace("< / ", "</");
            }

           
            //tag만 따오기 쉬게 하기 위헤서
            txt = txt.Replace(">", " >");

            //<로 시작하는 문장들은 모두 태그라 태그 비교를 위해
            Regex regex = new Regex("<");
            string[] tag = regex.Split(txt);

            string pattern = @"p\s";
            string s = @"div\s";



            //태그를 스택에 넣고 pop된 태그와 /tag의 일치 비교
            foreach (string tags in tag)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(tags, pattern) || System.Text.RegularExpressions.Regex.IsMatch(tags, s))
                {
                    string[] temp = tags.Split(' ');
                    //Console.WriteLine(temp[0]);
                    if(tags[0].ToString() == "/")
                    {
                        string a="";
                        for (int i = 1; i < tags.Length; i++)
                        {
                            a += tags[i];
                            if (tags[i].ToString() == " ")
                                break;
                        }
                        Console.WriteLine(a);
                    }
                }
            }



            
            // <> 스택으로 짝 맞추기
            for (int i = 0; i < test.Length; i++)
            {
                for (int j = 0; j < test[i].Length; j++)
                {
                    if (test[i][j].ToString() == "<")
                    {
                        bracket.Push(test[i][j].ToString());

                        if (bracket.Count >= 2)
                            lineNo.Push(i);
                    }

                    if (test[i][j].ToString() == ">")
                    {

                        try
                        {
                            bracket.Pop(); //stack이 비어 있으면 에러 발생
                            lineNo.Pop();
                        }
                        catch (Exception e)
                        {
                            bracketError++;
                            lines.Add(i);
                            //lineNo.Push(i);
                        }
                    }
                }
            }


            //오류사항 알림

            for(int i = lineNo.Count; i>=1; i--)
            {
                linesNo.Add(lineNo.Pop());
            }


            if (bracket.Count() != 0)
            {
                Console.WriteLine("닫히지 않은 괄호가 " + bracket.Count() + "개 존재합니다");

                for (int i = 1; i < linesNo.Count; i++)
                {
                    if (Convert.ToInt32(linesNo[i]) == Convert.ToInt32(linesNo[i - 1])) 
                        continue;
                    Console.WriteLine((Convert.ToInt32(linesNo[i])+1) + "번째 라인에서 문제 발생");
                }
            }


            else if (bracketError != 0)
            {
                Console.WriteLine(bracketError + "개의 괄호가 짝이 맞지 않습니다");

                for (int i = 1; i < lines.Count; i++)
                {
                    if (Convert.ToInt32(lines[i]) == Convert.ToInt32(lines[i - 1])) 
                        continue;
                    Console.WriteLine(lines[i] + "번째 라인에서 문제 발생");
                }
            }
            else
                Console.WriteLine("모든 괄호의 짝이 맞습니다\n\n");

            Console.WriteLine();
            for (int i = 0; i < test.Length; i++)
                Console.WriteLine(test[i]);
            Console.WriteLine();

        }
    }
}
