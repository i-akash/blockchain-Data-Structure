using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace chain{
    public class GenesisBlock:IBlock
    {
        public GenesisBlock()
        {
        }

        public GenesisBlock(DateTime datetime)
        {
            Index=0;
            PrevHash = new byte[]{};
            MarkleRoot = new byte[]{};
            Datetime = datetime;
            DifficultyLevel = 0;
            Nonce = 0;
            Transactions=new List<Transaction>();
            Sync();
        }


        public int Index {get;set;}
        public byte[] PrevHash {get;set;}
        public byte[] BlockHash { get;set; }
        public byte[] MarkleRoot {get;set;}

        public DateTime Datetime {get;}

        public int DifficultyLevel {get;}

        public int Nonce { get;set;}

        public List<Transaction> Transactions {get;}

        public bool Sync(){
            BlockHash=GetHash();
            return true;
        }
        public byte[] GetHash()
        {
            string stringValue=ToString();
            byte[] repBytes=Encoding.UTF8.GetBytes(stringValue);
            IEnumerable<byte> merged=repBytes.Concat(MarkleRoot).Concat(PrevHash);
            
            byte[] hashValue=HashSuit.ComputeSha256(merged.ToArray());
            return hashValue;
        }

        public override string ToString(){
            return Index.ToString()+Datetime.ToString()+DifficultyLevel.ToString()+Nonce.ToString();
        }

        public bool IsValid(byte[] prevHash)
        {
            return true;
        }

        public void PrintBlock()
        {
           ConsoleGui.ShowBlock(this);
        }
    }
}