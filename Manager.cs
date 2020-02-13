using System;
using System.Collections.Generic;

namespace chain
{
    public class Manager
    {
        public Chain chain=null;
        public TransactionQueue transactionQueue=null;

        public Manager()
        {
            transactionQueue=new TransactionQueue();
        }


        public bool SyncChain(){
            chain=Reader.ReadChain();
            return true;
        } 

        public bool ShowChain(){
            chain.PrintChain();
            return true;
        }

        public bool TryAddTransaction(){
            if(transactionQueue.AddTransaction())
                {
                    ConsoleGui.ShowMessage("Transaction Added");
                    return true;
                }
            return false;
        }

        public bool TryAddBlock(){
            List<Transaction> transactions=new List<Transaction>();
            transactions.Add(new Transaction("a","b",10,DateTime.UtcNow));
            transactions.Add(new Transaction("a","b",11,DateTime.UtcNow));
            Block block=new Block(chain.NextBlockIndex,DateTime.UtcNow,chain.LastBlockHash,transactions,4,10101);

            if(SolvePuzzle(block)){
                chain.TryAddBlock(block);
            }
            return true;
        }


        public bool SolvePuzzle(IBlock block){
            int nonce=100;
            while (Puzzle.Solve(block)==false)
            {
                block.Nonce=nonce;
                nonce++;    
            }
            return true;
        }
    }
}