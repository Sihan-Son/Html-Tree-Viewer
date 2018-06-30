using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var bracketError = 0;


            string[] test = new string[] { richTextBox1.Text };

            if (richTextBox1.Lines.Length == 0)
            {
                richTextBox3.Text = "컴파일 할 텍스트가 없습니다.";
                return;
            }

            for (int x = 0; x >= richTextBox1.Lines.Length; x++)
            {
                test[x] = richTextBox1.Lines[x];

            }

            for (int i = 0; i < test.Length; i++)
            {
                test[i] = test[i].Replace("</ ", "</");
                test[i] = test[i].Replace("< /", "</");
                test[i] = test[i].Replace("< / ", "</");
            }

            Stack<string> bracket = new Stack<string>();
            Stack<string> ErrorLine = new Stack<string>();

            for (int i = 0; i < test.Length; i++)
            {
                for (int j = 0; j < test[i].Length; j++)
                {
                    if (test[i][j].ToString() == "<")
                    {
                        bracket.Push(test[i][j].ToString());
                    }

                    if (test[i][j].ToString() == ">")
                    {

                        try
                        {
                            bracket.Pop(); //stack이 비어 있으면 에러 발생
                            //richTextBox2.Text = "/123";
                        }
                        catch (Exception)
                        {
                            bracketError++;
                            
                        }

                    }
                }

            }


            if (bracket.Count() != 0) {
                richTextBox3.Text = "닫히지 않은 괄호가 " + bracket.Count() + "개 존재합니다";
            }
                


            else if (bracketError != 0)
            {
                richTextBox3.Text = bracketError + "개의 괄호가 짝이 맞지 않습니다";
            } else {
                richTextBox3.Text = "모든 괄호의 짝이 맞습니다\n\n";
            }
                

            Console.WriteLine();
            for (int i = 0; i < test.Length; i++)
            {
                Console.WriteLine(test[i]);
            }
                
            Console.WriteLine();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fileTextBox.Clear();
            String file_path = null;
            openFileDialog1.InitialDirectory = "C:\\";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)

            {
                file_path = openFileDialog1.FileName;
                fileTextBox.Text = file_path;
                richTextBox1.Text = File.ReadAllText(file_path,Encoding.UTF8);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string url = fileTextBox.Text;
            webBrowser1.Navigate(url);
        }
    }
}
