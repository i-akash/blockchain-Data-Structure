using System;
using System.Collections.Generic;

namespace chain
{
    public class TransactionQueue
    {
        List<Transaction> transactions=null;
        List<Transaction> selectedTransactions=null;
        public TransactionQueue()
        {
            transactions=new List<Transaction>();
            selectedTransactions=new List<Transaction>();
        }

        public bool AddTransaction(){
            ConsoleGui.ShowMessage("From");
            string from=Console.ReadLine();
            ConsoleGui.ShowMessage("To");
            string to=Console.ReadLine();
            ConsoleGui.ShowMessage("Amount");
            double amount=Convert.ToDouble(Console.ReadLine());

            transactions.Add(new Transaction(from,to,amount,DateTime.UtcNow));
            return true;
        }

        public bool TryPopTransactionAt(int index,out Transaction transaction){
            transaction=null;
            transaction=transactions[index];
            if(transaction==null)
                return false;
            transactions.RemoveAt(index);
            return true;
        }

        public List<Transaction> PopTransactionListAt(int[] indexes){
            List<Transaction> transactionList=new List<Transaction>();
            foreach (var index in indexes)
            {
                Transaction transaction=null;
                if(TryPopTransactionAt(index,out transaction)){
                    transactionList.Add(transaction);
                }
            }
            return transactionList;
        }

        public List<Transaction> PopTransactionListRange(int start,int count){
            List<Transaction> transactionList=new List<Transaction>();
            transactionList.AddRange(transactions.GetRange(start,count));
            transactions.RemoveRange(start,count);

            return transactionList;
        }

        public bool SelectTransaction(List<Transaction> selected){
            selectedTransactions=selected;
            return true;
        }   

        public bool ShowTransactions(){
            foreach (var transaction in transactions)
            {
                ConsoleGui.ShowTransaction(transaction);
            }
            return true;
        }

        public bool ShowTransactions(Transaction transaction){
            ConsoleGui.ShowTransaction(transaction);
            return true;
        }


    }
}