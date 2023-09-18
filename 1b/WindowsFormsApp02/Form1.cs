using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp02
{
    public partial class Form1 : Form
    {
        private Random r = new Random();
        private int qNum = 10;
        private int curQuizNum = 0;
        private int score  = 0;
        private int qTime = 20;
        private int curAns = 0;
        private DateTime startTime;

        public Form1()
        {
            InitializeComponent();
        }

        private void StartNewQuiz()
        {
            curQuizNum = 0;
            score = 0;
            button1.Text = "停止";
            ContinueQuiz();
        }

        private void ContinueQuiz()
        {
            curQuizNum++;
            aBox.BackColor = Color.White;
            if (curQuizNum <= qNum)
            {
                var first = r.Next(1, 999);
                var second = r.Next(1, 999);
                var op = r.Next(0, 1);

                if (op == 0)
                    curAns = first + second;
                if (op == 1)
                    curAns = first - second;

                var oper = op == 0 ? "+" : "-";

                qBox.Text = $"{first} {oper} {second} = ?";
                label2.Text = $"{qTime} s";
                startTime = DateTime.Now;
                timer1.Start();
            }
            else
            {
                EndQuiz();
            }
        }

        private void EndQuiz()
        {
            timer1.Stop();
            button1.Text = "开始";
            MessageBox.Show($"总得分: {score}");
        }

        private void CheckAnswer()
        {
            int.TryParse(aBox.Text, out int userAnswer);

            if (userAnswer == curAns)
            {
                aBox.BackColor = Color.Green;
                score++;
                Thread.Sleep(1000);
                ContinueQuiz();
            }
            else
            {
                aBox.BackColor = Color.Red;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)//此函数是所有按键被按下时的相应函数

        {

            if (e.KeyCode == Keys.Enter)//判断回车键
            {
                this.button2_Click(sender, e);//触发按钮事件

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "开始")
                StartNewQuiz();
            else
                EndQuiz();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CheckAnswer();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            TimeSpan elapsed = DateTime.Now - startTime;
            int remainingSeconds = qTime - (int)elapsed.TotalSeconds;
            label2.Text = $"{remainingSeconds} s";

            if (remainingSeconds <= 0)
            {
                timer1.Stop();
                ContinueQuiz() ;
            }
        }
    }
}
