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

        public bool ValidateChain(){
            IBlock prevBlock=null;
            List<IBlock> validBlockChain=new List<IBlock>();
            foreach (var block in BlockChain)
            {
                block.Sync();
                if(prevBlock==null)
                    validBlockChain.Add(block);
                else if(block.IsValid(prevBlock.BlockHash))
                    validBlockChain.Add(block);
                else 
                    break;

                prevBlock=block;
            }
            BlockChain=validBlockChain;
            return true;
        }
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
                block.PrintBlock();
                prevBlock=block;
            }
        }
    }
}