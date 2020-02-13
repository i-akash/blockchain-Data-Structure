using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace chain
{
    class Program
    {
        static void Main(string[] args)
        {
            Chain chain=new Chain(new GenesisBlock(DateTime.UtcNow));
            
            List<Transaction> transactions1=new List<Transaction>();
            transactions1.Add(new Transaction("a","b",12,DateTime.UtcNow));
            transactions1.Add(new Transaction("a","b",13,DateTime.UtcNow));


            Block block1=new Block(chain.NextBlockIndex,DateTime.UtcNow,chain.LastBlockHash,transactions1,4,12010); 
            chain.TryAddBlock(block1);
            
            List<Transaction> transactions2=new List<Transaction>();
            transactions2.Add(new Transaction("a","b",12,DateTime.UtcNow));
            transactions2.Add(new Transaction("a","b",13,DateTime.UtcNow));


            Block block2=new Block(chain.NextBlockIndex,DateTime.UtcNow,chain.LastBlockHash,transactions2,4,12010); 
            chain.TryAddBlock(block2);
            Writer.WriteChain(chain);
            chain.PrintChain();
        
            

            // Manager manager=new Manager();
            // manager.SyncChain();
            // UserHandler handler=new UserHandler();
            // handler.HandleUser(manager);     
                       
        }
    }
}


