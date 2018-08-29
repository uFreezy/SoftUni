using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using ATM.Data;
using ATM.Models;

namespace ATM.Client
{
    class Program
    {
        static void Main()
        {
            var context =  new ATMContext();

            var acc = context.CardAccounts.Find(1);
            using (TransactionScope tran = new TransactionScope(TransactionScopeOption.Required))
            {
                if (context.CardAccounts.Any(c => c.CardNumber == acc.CardNumber && c.CardPIN == acc.CardPIN))
                {
                    if (context.CardAccounts.First(c => c.CardNumber == acc.CardNumber).CardCash >= acc.CardCash && 
                        context.CardAccounts.First(c => c.CardNumber == acc.CardNumber).CardCash > 0)
                    {
                        context.TransactionHistories.Add(new TransactionHistory
                        {
                            CardNumber = context.CardAccounts.First(c => c.CardNumber == acc.CardNumber).CardNumber,
                            Amount = acc.CardCash,
                            TransactionDate = DateTime.Now
                        });

                        context.CardAccounts.First(c => c.CardNumber == acc.CardNumber).CardCash -= acc.CardCash;
                        Console.WriteLine("Transaction complete!");
                        context.SaveChanges();
                        tran.Complete();
                        
                    }
                    else
                    {
                        throw new ArgumentException("You cannot request more money than you have in your account.");
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid credit card number and / or card PIN.");
                }           
            }
             
        }
    }
}
