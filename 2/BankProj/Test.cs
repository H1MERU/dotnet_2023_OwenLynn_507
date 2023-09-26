class Test
{
    static void Main()
    {
        Account savingsAccount = new Account("12345");
        CreditAccount creditAccount = new CreditAccount("54321", 5000);
        ATM atm = new ATM();

        atm.BigMoneyFetched += (sender, args) =>
        {
            Console.WriteLine($"Alert: Big money fetched from {args.Account.GetType().Name} {args.Account.Balance:C}");
        };

        try
        {
            atm.WithdrawMoney(savingsAccount, 2000);
            atm.WithdrawMoney(creditAccount, 12000);
            atm.DepositMoney(savingsAccount, 1000);
            atm.DepositMoney(creditAccount, 12000);
            atm.TransferMoney(creditAccount, savingsAccount, 100);
            atm.WithdrawMoney(creditAccount, 12000);
        }catch(Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }

        Console.WriteLine($"Savings Account Balance: {savingsAccount.Balance:C}");
        Console.WriteLine($"Credit Account Balance: {creditAccount.Balance:C}");
    }
}