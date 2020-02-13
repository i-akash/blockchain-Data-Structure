using System;

namespace chain
{
    public class UserHandler
    {
        
        public  void  HandleUser(Manager manager){
            while (true)
            {
                string command=Console.ReadLine();
                var commands=command.Split(" ");
                if(command.Length<=0)
                    ConsoleGui.ShowMessage("Exiting");
                switch (commands[0])
                {
                    case "show":Show(manager,commands);break;
                    case "select":Select(manager,commands);break;
                    case "add" :manager.TryAddTransaction();break;
                    default:break;
                }
            }      
        }


        public  void Show(Manager manager,string[] commands){
            
            switch (commands[1])
            {
                case "qt":manager.transactionQueue.ShowTransactions();break;
                case "chain":manager.chain.PrintChain();break;
            }
        }

        public  void Select(Manager manager,string[] commands){
            switch (commands[1])
            {
                case "t":manager.transactionQueue.SelectTransaction(manager.transactionQueue.PopTransactionListRange(0,1));break;
            }
        }
        public  void Add(Manager manager,string[] commands){
            switch (commands[1])
            {
                case "t":manager.TryAddTransaction();break;
                case "b":manager.TryAddBlock();break;
            }
        }

    }
}