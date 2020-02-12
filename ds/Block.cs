using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace chain{
    public class Block:IBlock
    {
        public Block(int index,DateTime datetime,byte[] prevHash,byte[] blockHash,byte[] markleRoot,List<Transaction> transactions,int difficultylevel,int nonce)
        {
            // header
            Index=index;
            Datetime = datetime;
            PrevHash = prevHash;
            BlockHash= blockHash;
            
            // transactions
            Transactions = transactions;
            MarkleRoot = markleRoot;
            
            DifficultyLevel = difficultylevel;
            Nonce = nonce;
            
        }
        public Block(int index,DateTime datetime,byte[] prevHash,List<Transaction> transactions,int difficultyLevel,int nonce)
        {
            Index=index;
            Datetime = datetime;
            PrevHash = prevHash;
            
            // transactions
            Transactions = transactions;
            MarkleTree markleTree=new MarkleTree(transactions);
            MarkleRoot = markleTree.Root;
            
            
            DifficultyLevel = difficultyLevel;
            Nonce = nonce;



            BlockHash=getHash();
            
        }

        public byte[] PrevHash { get;set; }
        public List<Transaction> Transactions { get; }
        public byte[] BlockHash { get; }
        public byte[] MarkleRoot { get;set; }
        public DateTime Datetime { get; }
        public int DifficultyLevel { get; }
        public int Nonce { get;set; }

        public int Index {get;set;}

        public byte[] getHash(){
            byte[] repBytes=Encoding.UTF8.GetBytes(ToString());
            byte[] midMerged=MarkleRoot.Union(repBytes).ToArray();
            byte[] merged=PrevHash.Union(midMerged).ToArray();

            byte[] hashValue=Hash.ComputeSha256(merged);
            return hashValue;
        }

        public bool IsValid(byte[] prevHash)
        { 
            Block recentBlock=this;
            recentBlock.PrevHash=prevHash;
            recentBlock.MarkleRoot=new MarkleTree(recentBlock.Transactions).Root;

            if(recentBlock.getHash().SequenceEqual(BlockHash)){
                return true;
            }
            return false;
        }

        public void PrintBlock(IBlock prevBlock)
        {
            Console.ForegroundColor=ConsoleColor.Blue;
                Console.WriteLine($"Block        {Index}");

            if(IsValid(prevBlock.BlockHash))
                Console.ForegroundColor=ConsoleColor.Green;
            else 
                Console.ForegroundColor=ConsoleColor.Red;
                
            
            Console.WriteLine($"Date Time    {Datetime}");
            Console.Write("Prev Hash    ");
            foreach (var byteValue in PrevHash)
            {
                Console.Write(byteValue);    
            }
            Console.WriteLine();

            Console.Write("Block Hash    ");
            foreach (var byteValue in BlockHash)
            {
                Console.Write(byteValue);    
            }
            Console.WriteLine();

            Console.Write("Markle Root   ");
            foreach (var byteValue in MarkleRoot)
            {
                Console.Write(byteValue);    
            }
            Console.WriteLine();

            Console.WriteLine($"Level     {DifficultyLevel}");
            Console.WriteLine($"Nonce     {Nonce}");

            foreach (var transaction in Transactions)
            {
                Console.WriteLine($"f: {transaction.From} - t: {transaction.To} - am: {transaction.Amount} - d: {transaction.Date}");
            }

            Console.WriteLine();
            Console.ResetColor();
        }

        public override string ToString(){
            return Datetime.ToString()+DifficultyLevel.ToString()+Nonce.ToString()+Index.ToString();
        }
    }
}