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
            DifficultyLevel = difficultyLevel;
            Nonce = nonce;


            Sync();
            
        }


        public int Index {get;set;}
        public byte[] PrevHash {get;set; }
        public byte[] BlockHash {get;set;}
        public byte[] MarkleRoot {get;set;}
        public DateTime Datetime { get; }
        public List<Transaction> Transactions { get; }
        public int DifficultyLevel { get; }
        public int Nonce { get;set; }

        public bool Sync(){
            MarkleTree markleTree=new MarkleTree(Transactions);
            MarkleRoot=markleTree.Root;

            BlockHash=GetHash();
            return true;
        }

        public bool IsValid(byte[] prevHash)
        { 
            string hexString=ConverterSuit.ByteArrayToHex(BlockHash);
            if(prevHash.SequenceEqual(PrevHash) && hexString.Substring(0,DifficultyLevel).Equals(new string('0',DifficultyLevel))){
                return true;
            }
            return false;
        }


        public byte[] GetHash(){
            string stringValue=ToString();
            byte[] repBytes=Encoding.UTF8.GetBytes(stringValue);
            IEnumerable<byte> merged=repBytes.Concat(MarkleRoot).Concat(PrevHash);
            
            byte[] hashValue=HashSuit.ComputeSha256(merged.ToArray());
            return hashValue;
        }

        public override string ToString(){
            return Index.ToString()+Datetime.ToString()+DifficultyLevel.ToString()+Nonce.ToString();
        }

        public void PrintBlock()
        {
            ConsoleGui.ShowBlock(this);
        }

       
    }
}