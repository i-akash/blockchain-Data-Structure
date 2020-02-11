using System;
using System.Linq;
using System.Text;

namespace chain{
    public class GenesisBlock:IBlock
    {
        public GenesisBlock(DateTime datetime)
        {
            PrevHash = new byte[]{};
            MarkleRoot = new byte[]{};
            Datetime = datetime;
            Difficulty_Level = 0;
            Nonce = 0;
            BlockHash=getHash();
            Index=0;
            
        }

        public byte[] PrevHash {get;}
        public byte[] BlockHash { get; }
        public byte[] MarkleRoot {get;}

        public DateTime Datetime {get;}

        public int Difficulty_Level {get;}

        public int Nonce { get;set;}

        public int Index {get;set;}

        public byte[] getHash()
        {
            byte[] repBytes=Encoding.UTF8.GetBytes(ToString());
            byte[] midMerged=MarkleRoot.Union(repBytes).ToArray();
            byte[] merged=PrevHash.Union(midMerged).ToArray();

            byte[] hashValue=Hash.ComputeSha256(merged);
            return hashValue;
        }

        public bool IsValid(byte[] prevHash, byte[] blockHash)
        {
            return true;
        }

        public override string ToString(){
            return Datetime.ToString()+Difficulty_Level.ToString()+Nonce.ToString()+Index.ToString();
        }
    }
}