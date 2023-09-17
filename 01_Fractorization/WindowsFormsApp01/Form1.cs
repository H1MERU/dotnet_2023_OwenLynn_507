using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num = 0;
            if (Regex.IsMatch(textBox1.Text, @"^[0-9]+$"))
            {
                label3.Visible = false;
                num = Convert.ToInt32(textBox1.Text);
                textBox2.Text = fraction(num);
            }
            else{
                label3.Visible = true; 
            }
        }

        private string fraction(int num)
        {


            string str = num.ToString() + " = ";

            int n = num;
            int i = 2;
            
            while(i <= n)
            {
                if(n % i == 0)
                {
                    if(i == n)
                        str += i.ToString();
                    else
                        str += i.ToString() + " * ";
                   n= n / i;    
                    continue;
                }

                i++;
            }

            return str;
        }
    }
}
