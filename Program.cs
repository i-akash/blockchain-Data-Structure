using System;
using System.Collections.Generic;

namespace chain
{
    class Program
    {
        static void Main(string[] args)
        {
            Chain chain=new Chain(new GenesisBlock(DateTime.UtcNow));

            List<Transaction> transactions1=new List<Transaction>();
            transactions1.Add(new Transaction("a","b",10,DateTime.UtcNow));
            transactions1.Add(new Transaction("a","b",11,DateTime.UtcNow));
            
            Block block1=new Block(chain.LastBlockHash,transactions1,DateTime.UtcNow,4,10101,chain.NextBlockIndex);
            chain.TryAddBlock(block1);

            List<Transaction> transactions2=new List<Transaction>();
            transactions2.Add(new Transaction("a","b",12,DateTime.UtcNow));
            transactions2.Add(new Transaction("a","b",13,DateTime.UtcNow));

            Block block2=new Block(chain.LastBlockHash,transactions2,DateTime.UtcNow,4,10101,chain.NextBlockIndex);  
            chain.TryAddBlock(block2);


            // chain.PrintChain();
            Writer.WriteChain(chain);

        }
    }
}
