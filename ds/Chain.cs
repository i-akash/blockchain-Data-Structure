using System;
using System.Collections.Generic;

namespace chain
{
    public class Chain
    {
        public Chain(IBlock block)
        {
            BlockChain=new List<IBlock>();
            BlockChain.Add(block);
        }
        public List<IBlock> BlockChain {get;set;}

        public byte[] LastBlockHash=>BlockChain[BlockChain.Count-1].BlockHash;
        public int NextBlockIndex=>BlockChain.Count;

        public bool TryAddBlock(IBlock block){
            byte[] prevBlockHash=LastBlockHash;
            if(block.IsValid(prevBlockHash,block.BlockHash))
            {
                BlockChain.Add(block);
                return true;
            }
            return false;
        }



        public void PrintChain(){
            int blockNo=1;
            IBlock prevBlock=null;

            foreach (var block in BlockChain)
            {

                Console.ForegroundColor=ConsoleColor.Blue;
                Console.WriteLine($"Block        {blockNo}");

                if(blockNo>1 && block.IsValid(prevBlock.BlockHash,block.BlockHash))
                    Console.ForegroundColor=ConsoleColor.Green;
                else if(blockNo>1) 
                    Console.ForegroundColor=ConsoleColor.Red;
                    
                
                Console.WriteLine($"Date Time    {block.Datetime}");
                Console.Write("Prev Hash    ");
                foreach (var byteValue in block.PrevHash)
                {
                    Console.Write(byteValue);    
                }
                Console.WriteLine();

                Console.Write("Block Hash    ");
                foreach (var byteValue in block.BlockHash)
                {
                    Console.Write(byteValue);    
                }
                Console.WriteLine();

                Console.Write("Markle Root   ");
                foreach (var byteValue in block.MarkleRoot)
                {
                    Console.Write(byteValue);    
                }
                Console.WriteLine();

                Console.WriteLine($"Level     {block.Difficulty_Level}");
                Console.WriteLine($"Nonce     {block.Nonce}");
                Console.WriteLine();
                
                blockNo++;
                prevBlock=block;
            }
        }
    }
}