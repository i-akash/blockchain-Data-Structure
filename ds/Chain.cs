using System;
using System.Collections.Generic;

namespace chain
{
    public class Chain
    {
        public Chain()
        {
            BlockChain=new List<IBlock>();
        }
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
            if(block.IsValid(prevBlockHash))
            {
                BlockChain.Add(block);
                return true;
            }
            return false;
        }



        public void PrintChain(){
            IBlock prevBlock=null;
            Console.WriteLine(BlockChain.Count);
            foreach (var block in BlockChain)
            {
                // if(block.IsValid(prevBlock.BlockHash))
                
                block.PrintBlock();
                prevBlock=block;
            }
        }
    }
}