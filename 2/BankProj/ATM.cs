using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 定义一个自定义异常类
class BadCashException : Exception
{
    public BadCashException(string message) : base(message)
    {
    }
}

// 定义事件参数类
class BigMoneyArgs : EventArgs
{
    public Account Account { get; }
    public double WithdrawnAmount { get; }
    public BigMoneyArgs(Account account, double withdrawnAmount)
    {
        Account = account;
        WithdrawnAmount = withdrawnAmount;
    }
}

class ATM
{
    public event EventHandler<BigMoneyArgs> BigMoneyFetched;

    public void WithdrawMoney(Account account, double amount)
    {
        if (amount > 10000)
        {
            OnBigMoneyFetched(account, amount);
        }

        if (new Random().NextDouble() < 0.3)
        {
            throw new BadCashException("Bad cash detected.");
        }

        account.Withdraw(amount);
    }

    public void DepositMoney(Account account, double amount)
    {
        account.Deposit(amount);
    }

    public void TransferMoney(Account from, Account to, double amount){
        try
        {
            from.Withdraw(amount);
            to.Deposit(amount);
        }
        catch(Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }


    protected virtual void OnBigMoneyFetched(Account account, double amount)
    {
        BigMoneyArgs args = new BigMoneyArgs(account, amount);
        BigMoneyFetched?.Invoke(this, args);
    }


}

