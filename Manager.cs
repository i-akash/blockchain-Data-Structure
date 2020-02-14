using System;
using System.Collections.Generic;
using System.Linq;

namespace chain
{
    public class Manager
    {
        private Chain chain=null;
        private TransactionStates transactionStates=null;

        public Manager()
        {
            transactionStates=new TransactionStates();
        }

        // 
        // CHAIN
        // 
        public bool SyncChain(){
            chain=Reader.ReadChain();
            chain.ValidateChain();
            return true;
        } 

        public bool ShowChain(){
            chain.ValidateChain();
            chain.PrintChain();
            return true;
        }

        public bool SaveChain(){
            chain.ValidateChain();
            Writer.WriteChain(chain);
            return true;
        }

        // 
        // TRANSACTION
        // 
        public bool TryAddTransaction(){
            if(transactionStates.AddTransaction())
                {
                    ConsoleGui.ShowMessage("Transaction Added");
                    return true;
                }
            return false;
        }

        public bool ShowQueueTransactions(){
            transactionStates.ShowQueueTransactions();
            return true;
        }

        public bool ShowSelectedTransactions(){
            ConsoleGui.ShowMessage("Your Selected Transactions.");
            transactionStates.ShowSelectedTransactions();
            return true;
        }

        public bool SelectTransaction(){
            ConsoleGui.ShowMessage("pos: ");
            int pos=ConsoleGui.InputInt32();
            Transaction transaction=null;
            
            if(transactionStates.TryPopTransactionAt(pos,out transaction))
                {
                    ConsoleGui.ShowTransaction(transaction);
                    transactionStates.SelectTransaction(transaction);
                    return true;
                }

            ConsoleGui.ShowMessage("Failed");
            return false;
        }
        // 
        // Block
        // 
        public bool TryAddBlock(){
            chain.ValidateChain();
            List<Transaction> transactions=transactionStates.selectedTransactions.OrderBy(t=>t.Date).ToList();
            Block block=new Block(chain.NextBlockIndex,DateTime.UtcNow,chain.LastBlockHash,transactions,4,10101);
            
            ConsoleGui.ShowBlock(block);
            if(ConsoleGui.GetPermission("Trying Solving Puzzle for Block.")==false)
                return false;

            if(SolvePuzzle(block)){
                ConsoleGui.ShowBlock(block);
                if(ConsoleGui.GetPermission("Puzzle Solved.Will Add.")==false)
                    return false;
                    
                chain.TryAddBlock(block);
            }
            transactionStates.selectedTransactions=new List<Transaction>();
            ConsoleGui.ShowMessage("Block Addded");
            return true;
        }


        public bool SolvePuzzle(IBlock block){
            int nonce=100;
            while (Puzzle.Solve(block)==false)
            {
                block.Nonce=nonce;
                block.Sync();
                nonce++;    
            }
            return true;
        }
    }
}