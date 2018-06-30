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
        static Stack<string> bracket = new Stack<string>(); // <> 짝 확인
        static Stack<string> tagName = new Stack<string>(); // tag 짝 확인

        static ArrayList lines = new ArrayList(); // error 발생 줄 > 가 많을 때
        static ArrayList linesNo = new ArrayList(); // stack에 들어간 줄수 정방향으로 바꾸기용
        static ArrayList errorTag = new ArrayList(); // 짝이 맞지 않는 태그 목록

        static void TagChcek(string tags)
        {
            string closeTag = ""; //
            string tempTagName;

            string[] temp = tags.Split(' ');
            Console.WriteLine("{0} is  tmep",temp[0]);
            if (temp[0].ToString() == "/")
            {
                for (int i = 1; i < tags.Length; i++)
                {
                    if (temp[i].ToString() == " ")
                        break;
                    closeTag += tags[i];
                }

                tempTagName = tagName.Pop();
                Console.WriteLine("{0} pop tag name",tempTagName);

                if (closeTag != tempTagName)
                {
                    errorTag.Add(tempTagName);
                }
            }

            else
            {
                Console.WriteLine(temp[0]);
                tagName.Push(temp[0].Trim());
            }


        }


        static void Main(string[] args)
        {
            //에러 개수 count
            var bracketError = 0;
            bool errorFlag = false;
            int errorFlagCount = 1;
           
            //중복 줄 1번만 출력
            lines.Add(0);
            linesNo.Add(0);

            //html 문서 읽어오기
            string[] test = File.ReadAllLines(@"D:\Project\html-Browser\SummerProject\HTMLBrowser\HTMLBrowser\a.html"); // html 문서 위치
            string txt = File.ReadAllText(@"D:\Project\html-Browser\SummerProject\HTMLBrowser\HTMLBrowser\a.html");
            

            //포맷 수정 html 코딩 스타일 때문에
            for (int i = 0; i < test.Length; i++)
            {
                test[i] = test[i].Replace("</ ", "</");
                test[i] = test[i].Replace("< /", "</");
                test[i] = test[i].Replace("< / ", "</");
                test[i] = test[i].ToLower();
            }


            //tag만 따오기 쉽게 하기 위헤서
            txt = txt.Replace(">", " >");
            txt = txt.ToLower();

            //<로 시작하는 문장들은 모두 태그라 태그 비교를 위해
            Regex regex = new Regex("<");
            string[] tag = regex.Split(txt);

            //for (int i = 0; i < tag.Length; i++)
            //{
            //    Console.WriteLine("{0} {1}", i, tag[i]);
            //}

            //tag pattern
            //V
            string pVideo = @"^video\s";
            string pVar = @"^var\s";
            //U
            string pUl = @"^ul\s";
            string pU = @"^u\s";
            //T
            string pTt = @"^tt\s";
            string pTr = @"^tr\s";
            string pTitle = @"^title\s";
            string pTime = @"^time\s";
            string pThead = @"^thead\s";
            string pTh = @"^th\s";
            string pTfoot = @"^tfoot\s";
            string pTextarea = @"^textarea\s";
            string pTd = @"^td\s";
            string pTbody = @"^tbody\s";
            string pTable = @"^table\s";
            //S
            string pSup = @"^sup\s";
            string pSummary = @"^summary\s";
            string pSub = @"^sub\s";
            string pStyle = @"^style\s";
            string pStrong = @"^strong\s";
            string pStrike = @"^strike\s";
            string pSpan = @"^span\s";
            string pSmall = @"^small\s";
            string pSelect = @"^select\s";
            string pSection = @"^section\s";
            string pScript = @"^script\s";
            string pSamp = @"^samp\s";
            string pS = @"^s\s";
            //R
            string pRuby = @"^ruby\s";
            string pRt = @"^rt\s";
            string pRp = @"^rp\s";
            //Q
            string pQ = @"^q\s";
            //P
            string pProgress = @"^progress\s";
            string pPre = @"^pre\s";
            string pParam = @"^param\s";
            string pP = @"^p\s";
            //O
            string pOutput = @"^output\s";
            string pOption = @"^option\s";
            string pOptgroup = @"^optgroup\s";
            string pOl = @"^ol\s";
            string pObject = @"^object\s";
            //N
            string pNoscript = @"^noscript\s";
            string pNoframes = @"^noframes\s";
            string pNay = @"^nay\s";
            //M
            string pMeter = @"^meter\s";
            string pMeta = @"^meta\s";
            string pMenu = @"^menu\s";
            string pMark = @"^mark\s";
            string pMap = @"^map\s";
            //L
            string pLi = @"^li\s";
            string pLegend = @"^legend\s";
            string pLabel = @"^label\s";
            //K
            string pKbd = @"^kbd\s";
            //I
            string pIns = @"^ins\s";
            string pInput = @"^input\s";
            string pIframe = @"^iframe\s";
            string pI = @"^i\s";
            //H
            string pHtml = @"^html\s";
            string pHgroup = @"^hgroup\s";
            string pHeader = @"^header\s";
            string pHead = @"^head\s";
            string pH1 = @"^h1\s";
            string pH2 = @"^h2\s";
            string pH3 = @"^h3\s";
            string pH4 = @"^h4\s";
            string pH5 = @"^h5\s";
            string pH6 = @"^h6\s";
            //F
            string pFrameset = @"^frameset\s";
            string pFrame = @"^frame\s";
            string pForm = @"^form\s";
            string pFooter = @"^footer\s";
            string pFont = @"^font\s";
            string pFigure = @"^figure\s";
            string pFigcaption = @"^figcaption\s";
            string pFieldset = @"^fieldset\s";
            //E
            string pEmbed = @"^embed\s";
            string pEm = @"^em\s";
            //D
            string pDt = @"^dt\s";
            string pDl = @"^dl\s";
            string pDiv = @"^div\s";
            string pDir = @"^dir\s";
            string pDialog = @"^dialog\s";
            string pDfn = @"^dfn\s";
            string pDetalis = @"^detalis\s";
            string pDel = @"^del\s";
            string pDd = @"^dd\s";
            string pDetalist = @"^detalist\s";
            //C
            string pCommand = @"^command\s";
            string pColgroup = @"^colgroup\s";
            string pCol = @"^col\s";
            string pCode = @"^code\s";
            string pCite = @"^cite\s";
            string pCenter = @"^center\s";
            string pCaption = @"^caption\s";
            string pCanvas = @"^canvas\s";
            //B
            string pBody = @"^body\s";
            string pBlockquote = @"^blockquote\s";
            string pBig = @"^big\s";
            string pBdo = @"^bdo\s";
            string pBdi = @"^bdi\s";
            //A
            string pAudio = @"^audio\s";
            string pAside = @"^aside\s";
            string pArticle = @"^article\s";
            string pApplet = @"^applet\s";
            string pAddress = @"^address\s";
            string pAcronym = @"^acronym\s";
            string pAbbr = @"^abbr\s";
            string pA = @"^a\s";


            //태그를 스택에 넣고 pop된 태그와 /tag의 일치 비교
            foreach (string tags in tag)
            {
                //A로 시작 태그
                if (System.Text.RegularExpressions.Regex.IsMatch(tags, pA) ||
                    System.Text.RegularExpressions.Regex.IsMatch(tags, pAbbr) ||
                    System.Text.RegularExpressions.Regex.IsMatch(tags, pAcronym) ||
                    System.Text.RegularExpressions.Regex.IsMatch(tags, pAddress) ||
                    System.Text.RegularExpressions.Regex.IsMatch(tags, pApplet) ||
                    System.Text.RegularExpressions.Regex.IsMatch(tags, pArticle) ||
                    System.Text.RegularExpressions.Regex.IsMatch(tags, pAside) ||
                    System.Text.RegularExpressions.Regex.IsMatch(tags, pAudio))
                {
                    TagChcek(tags);
                }

                //B로 시작 태그
                else if (System.Text.RegularExpressions.Regex.IsMatch(tags, pBdi) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pBdo) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pBig) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pBlockquote) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pBody))
                {
                    TagChcek(tags);
                }

                //C로 시작 태그
                else if (System.Text.RegularExpressions.Regex.IsMatch(tags, pCanvas) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pCaption) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pCenter) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pCite) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pCode) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pCol) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pColgroup) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pCommand))
                { 
                    TagChcek(tags);
                }

                //D로 시작 태그
                else if (System.Text.RegularExpressions.Regex.IsMatch(tags, pDd) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pDel) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pDetalis) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pDetalist) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pDfn) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pDialog) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pDir) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pDiv) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pDl) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pDt))
                {
                    TagChcek(tags);
                }

                //E & K로 시작 태그
                else if (System.Text.RegularExpressions.Regex.IsMatch(tags, pEm) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pEmbed) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pKbd))

                {
                    TagChcek(tags);
                }

                //F & L 로 시작 태그
                else if (System.Text.RegularExpressions.Regex.IsMatch(tags, pFieldset) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pFigcaption) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pFigure) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pFont) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pFooter) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pForm) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pFrame) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pFrameset) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pLabel) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pLegend) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pLi))
                {
                    TagChcek(tags);
                }

                //H로 시작 태그
                else if (System.Text.RegularExpressions.Regex.IsMatch(tags, pHtml) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pHgroup) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pHeader) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pHead) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pH1) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pH2) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pH3) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pH4) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pH5) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pH6))
                { 
                    TagChcek(tags);
                }

                //I & M 로 시작 태그
                else if (System.Text.RegularExpressions.Regex.IsMatch(tags, pI) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pIframe) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pInput) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pIns) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pMap) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pMark) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pMenu) ||
                         //System.Text.RegularExpressions.Regex.IsMatch(tags, pMeta) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pMeter))
                {
                    TagChcek(tags);
                }

                //N으로 시작 태그
                else if (System.Text.RegularExpressions.Regex.IsMatch(tags, pNay) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pNoframes) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pNoscript))
                {
                    TagChcek(tags);
                }

                //O로 시작 태그
                else if (System.Text.RegularExpressions.Regex.IsMatch(tags, pObject) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pOl) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pOptgroup) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pOption) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pOutput))
                { 
                    TagChcek(tags);
                }

                //P & Q로 시작 태그
                else if (System.Text.RegularExpressions.Regex.IsMatch(tags, pQ) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pP) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pParam) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pPre) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pProgress))
                {
                    TagChcek(tags);
                }

                //R & U & V 로 시작 태그
                else if (System.Text.RegularExpressions.Regex.IsMatch(tags, pRp) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pRt) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pRuby) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pU) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pUl) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pVar) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pVideo))
                {
                    TagChcek(tags);
                }

                //S로 시작 태그
                else if (System.Text.RegularExpressions.Regex.IsMatch(tags, pS) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pSamp) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pScript) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pSection) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pSelect) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pSmall) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pSpan) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pStrike) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pStrong) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pStyle) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pSub) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pSummary) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pSub) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pSup))
                {
                    TagChcek(tags);
                }

                //T로 시작 태그
                else if (System.Text.RegularExpressions.Regex.IsMatch(tags, pTable) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pTbody) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pTd) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pTextarea) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pTfoot) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pTh) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pThead) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pTime) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pTitle) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pTr) ||
                         System.Text.RegularExpressions.Regex.IsMatch(tags, pTt))
                {
                    TagChcek(tags);
                }


                else if (System.Text.RegularExpressions.Regex.IsMatch(tags, pMeta))
                {
                    Console.WriteLine();
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

                        /*
                        if (bracket.Count >= 2)
                        {
                            errorFlagCount = bracket.Count;

                            if (errorFlagCount <= bracket.Count)
                            {
                                errorFlag = false;
                                Console.WriteLine(i + " false");

                            }

                            else
                            {
                                errorFlag = true;
                                Console.WriteLine("true");
                            }
                        }
                        */
                        if (errorFlag)
                        {
                            linesNo.Add(i);
                            Console.WriteLine(bracket.Count);
                        }
                    }

                    if (test[i][j].ToString() == ">")
                    {

                        try
                        {
                            bracket.Pop(); //stack이 비어 있으면 에러 발생
                        }
                        catch (Exception)
                        {
                            bracketError++;
                            lines.Add(i);
                        }
                    }
                }
            }


            //오류사항 알림
            if (bracket.Count() != 0)
            {
                Console.WriteLine("닫히지 않은 괄호가 " + bracket.Count() + "개 존재합니다");

                for (int i = 1; i < linesNo.Count; i++)
                {
                    if (Convert.ToInt32(linesNo[i]) == Convert.ToInt32(linesNo[i - 1]))
                        continue;
                    Console.WriteLine((Convert.ToInt32(linesNo[i]) + 1) + "번째 라인에서 문제 발생");
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

            if (errorTag.Count != 0)
            {
                Console.WriteLine("a짝이 맞지 않는 태그가 발생");

                for (int i = 0; i < errorTag.Count; i++)
                    Console.WriteLine("{0} {1}", i + 1, errorTag[i]);
            }

            if (tagName.Count != 0)
            {
                Console.WriteLine("b짝이 맞지 않는 태그가 발생");

                for (int i = 0; i < tagName.Count; i++)
                    Console.WriteLine("{0} {1}", i + 1, tagName.Pop());
            }

            Console.WriteLine("errorTag Count {0}",errorTag.Count);
            /*
            for (int i = 0; i < tag.Length; i++)
                Console.WriteLine(tag[i]);
            Console.WriteLine();
            Console.WriteLine(); Console.WriteLine();
            Console.WriteLine(txt);
            */
        }   
    }
}
