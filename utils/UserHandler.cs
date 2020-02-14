using System;

namespace chain
{
    public class UserHandler
    {
        
        public  void  HandleUser(Manager manager){
            while (true)
            {
                ConsoleGui.ShowPointer();
                string command=Console.ReadLine();
                var commands=command.Split(" ");
                
                if(command.Length<=0)
                    ConsoleGui.ShowMessage("Exiting");
                
                bool flag=false;
                switch (commands[0])
                {
                    case "help":break;
                    case "sync":manager.SyncChain();break;
                    case "save":manager.SaveChain();break;
                    case "show":Show(manager,commands);break;
                    case "select":Select(manager,commands);break;
                    case "add" :Add(manager,commands);break;
                    case "exit" :flag=true;break;
                    default:break;
                }

                if(flag==true)
                {
                    ConsoleGui.ShowMessage("Exiting");
                    break;
                }
            }      
        }


        public  void Show(Manager manager,string[] commands){
            
            switch (commands[1])
            {
                case "qt":manager.ShowQueueTransactions();break;
                case "st":manager.ShowSelectedTransactions();break;
                case "ch":manager.ShowChain();break;
            }
        }

        public  void Select(Manager manager,string[] commands){
            switch (commands[1])
            {
                case "t": manager.SelectTransaction();break;
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