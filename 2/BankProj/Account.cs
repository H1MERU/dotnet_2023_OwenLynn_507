using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Account
{
    private string accountNumber;
    protected double balance;

    public Account(string accountNumber)
    {
        this.accountNumber = accountNumber;
        balance = 0.0;
    }

    public double Balance
    {
        get { return balance; }
    }

    public virtual void Deposit(double amount)
    {
        try
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be greater than zero.");
            }
            else
            {
                balance += amount;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public virtual void Withdraw(double amount)
    {
        try
        {
            if (amount <= 0 || amount > balance)
            {
                throw new ArgumentException("Invalid withdrawal amount.");
            }
            else
            {
                balance -= amount;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

// 定义一个信用账号类，继承自账号类
class CreditAccount : Account
{
    private double creditLimit;

    public CreditAccount(string accountNumber, double creditLimit) : base(accountNumber)
    {
        this.creditLimit = creditLimit;
    }

    public double CreditLimit
    {
        get { return creditLimit; }
    }

    public override void Withdraw(double amount)
    {
        try
        {
            if (amount <= 0 || (balance + creditLimit) < amount)
            {
                throw new ArgumentException("Invalid withdrawal amount.");
            }
            else
            {
                balance -= amount;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

