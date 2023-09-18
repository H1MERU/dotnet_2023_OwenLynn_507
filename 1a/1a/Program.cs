using System;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("分解质因数");
        Console.WriteLine("输入数字：");
        string num = Console.ReadLine();
        if (Regex.IsMatch(num, @"^[0-9]+$"))
        {
            var n = Convert.ToInt32(num);
            Console.WriteLine(Fractorization.fraction(n));
        }
        else
        {
            Console.WriteLine("请输入正确的数字");
        }
    }

    public partial class Fractorization
    {
        public static string fraction(int num)
        {
            string str = num.ToString() + " = ";

            int n = num;
            int i = 2;

            while (i <= n)
            {
                if (n % i == 0)
                {
                    if (i == n)
                        str += i.ToString();
                    else
                        str += i.ToString() + " * ";
                    n = n / i;
                    continue;
                }

                i++;
            }

            return str;
        }
    }
}