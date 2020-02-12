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

            // List<Transaction> transactions1=new List<Transaction>();
            // transactions1.Add(new Transaction("a","b",10,DateTime.UtcNow));
            // transactions1.Add(new Transaction("a","b",11,DateTime.UtcNow));
            
            // Block block1=new Block(chain.NextBlockIndex,DateTime.UtcNow,chain.LastBlockHash,transactions1,4,10101);
            // chain.TryAddBlock(block1);

            List<Transaction> transactions2=new List<Transaction>();
            transactions2.Add(new Transaction("a","b",12,DateTime.UtcNow));
            transactions2.Add(new Transaction("a","b",13,DateTime.UtcNow));

            int nonce=0;
            DateTime date=DateTime.UtcNow;
            do
            {
                Block block2=new Block(chain.NextBlockIndex,date,chain.LastBlockHash,transactions2,2,nonce); 
                Puzzle.Solve(block2);
                nonce++;
                
            } while (true);

            // chain.TryAddBlock(block2);



            
            // Writer.WriteChain(chain);

            // Chain chain=Reader.ReadChain();
            // chain.PrintChain();

        }
    }
}
