using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace dotnet_03
{
    public partial class Form1 : Form
    {
        public string fileName;

        public Form1()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            Console.WriteLine(fileName);
        }

        private void SelectFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;//该值确定是否可以选择多个文件
            dialog.Title = "请选择文件夹";
            dialog.Filter = "C#文件(*.cs)|*.cs";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileName = dialog.FileName;
                label1.Text = dialog.FileName;
            }
        }

        private void FirstSummerize()
        {
            using StreamReader sr = File.OpenText(fileName);
            using StreamWriter sw = File.CreateText(fileName + "_formulated.cs") ;
            int lineCount = 0;
            int wordCount = 0;
            for(string s = sr.ReadLine(); s!=null; s = sr.ReadLine())
            {
                lineCount++;
                s = DeleteComment(s);
                if(s != "")
                {
                    sw.WriteLine(s);
                }
                wordCount += CountWords(s);
            }
            label2.Text = "格式化前有" + lineCount + "行，" + wordCount + "字。";
            sw.Dispose();
            SecondSummerize();
        }

        private void SecondSummerize()
        {
            using StreamReader srw = File.OpenText(fileName + "_formulated.cs");
            int lineCount = 0;
            int wordCount = 0;
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();
            for (string s = srw.ReadLine(); s != null; s = srw.ReadLine())
            {
                lineCount++;
                wordCount += CountWords(s);
                string[] words = s.Split(new char[] { ' ', '\t', '\r', '\n', '.', ',', ';', ':', '(', ')', '{', '}', '[', ']', '=', '+', '-', '*', '/', '<', '>', '&', '|', '!', '?', '\"', '\'', '\\' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string word in words)
                {
                    string cleanedWord = word.Trim();
                    if (!string.IsNullOrWhiteSpace(cleanedWord))
                    {
                        if (wordCounts.ContainsKey(cleanedWord))
                        {
                            wordCounts[cleanedWord]++;
                        }
                        else
                        {
                            wordCounts.Add(cleanedWord, 1);
                        }
                    }
                }
            }
            dataGridView1.Columns.Add("Word", "单词");
            dataGridView1.Columns.Add("Count", "出现次数");
            foreach (var kvp in wordCounts.OrderByDescending(kv => kv.Value))
                {
                    dataGridView1.Rows.Add(kvp.Key, kvp.Value);
                }
            label3.Text = "格式化后有" + lineCount + "行，" + wordCount + "字。";
        }


        private static int CountWords(string text)
        {
            string pattern = @"\b\w+\b";
            MatchCollection matches = Regex.Matches(text, pattern);
            return matches.Count;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        public string DeleteComment(string s)
        {
            int i;
            for(i = 0; i < s.Length; i++)
            {
                if (s[i] == '/')
                {
                    break;
                }
            }
            return s.Substring(0, i);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FirstSummerize();
        }
    }
}
