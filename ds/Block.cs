using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace chain{
    public class Block:IBlock
    {
        public MarkleRoot markleTree;

        public Block()
        {
        }

        public Block(byte[] prevHash,List<Transaction> transactions,DateTime datetime,int difficulty_level,int nonce,int index)
        {
            PrevHash = prevHash;

            // transactions
            Transactions = transactions;
            markleTree=new MarkleRoot(transactions);
            MarkleRoot = markleTree.root;
            
            
            Datetime = datetime;
            Difficulty_Level = difficulty_level;
            Nonce = nonce;
            BlockHash=getHash();
            Index=index;
        }

        public byte[] PrevHash { get; }
        public List<Transaction> Transactions { get; }
        public byte[] BlockHash { get; }
        public byte[] MarkleRoot { get; }
        public DateTime Datetime { get; }
        public int Difficulty_Level { get; }
        public int Nonce { get;set; }

        public int Index {get;set;}

        public byte[] getHash(){
            byte[] repBytes=Encoding.UTF8.GetBytes(ToString());
            byte[] midMerged=MarkleRoot.Union(repBytes).ToArray();
            byte[] merged=PrevHash.Union(midMerged).ToArray();

            byte[] hashValue=Hash.ComputeSha256(merged);
            return hashValue;
        }

        public bool IsValid(byte[] prevHash,byte[] blockhash)
        {
            if(prevHash.SequenceEqual(PrevHash)==true && blockhash.SequenceEqual(BlockHash)){
                return true;
            }
            return false;
        }

        public override string ToString(){
            return Datetime.ToString()+Difficulty_Level.ToString()+Nonce.ToString()+Index.ToString();
        }
    }
}