using System;
using System.Collections.Generic;

namespace chain
{
    public class TransactionStates
    {
        List<Transaction> transactionsQueue=null;
        public List<Transaction> selectedTransactions=null;
        public TransactionStates()
        {
            transactionsQueue=new List<Transaction>();
            selectedTransactions=new List<Transaction>();
        }

        public bool AddTransaction(){
            ConsoleGui.ShowMessage("From");
            string from=Console.ReadLine();
            ConsoleGui.ShowMessage("To");
            string to=Console.ReadLine();
            ConsoleGui.ShowMessage("Amount");
            double amount=Convert.ToDouble(Console.ReadLine());

            transactionsQueue.Add(new Transaction(from,to,amount,DateTime.UtcNow));
            return true;
        }

        public bool TryPopTransactionAt(int index,out Transaction transaction){
            transaction=null;
            transaction=transactionsQueue[index];
            if(transaction==null)
                return false;
            transactionsQueue.RemoveAt(index);
            return true;
        }

        // public List<Transaction> PopTransactionListAt(int[] indexes){
        //     List<Transaction> transactionList=new List<Transaction>();
        //     foreach (var index in indexes)
        //     {
        //         Transaction transaction=null;
        //         if(TryPopTransactionAt(index,out transaction)){
        //             transactionList.Add(transaction);
        //         }
        //     }
        //     return transactionList;
        // }

        // public List<Transaction> PopTransactionListRange(int start,int count){
        //     List<Transaction> transactionList=new List<Transaction>();
        //     transactionList.AddRange(transactionsQueue.GetRange(start,count));
        //     transactionsQueue.RemoveRange(start,count);

        //     return transactionList;
        // }

        public bool SelectTransaction(Transaction selected){
            selectedTransactions.Add(selected);
            return true;
        }
           

        public bool ShowQueueTransactions(){
            foreach (var transaction in transactionsQueue)
            {
                ConsoleGui.ShowTransaction(transaction);
            }
            return true;
        }

        public bool ShowSelectedTransactions(){
            foreach (var transaction in selectedTransactions)
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