using System;
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
            PrevHash = new byte[]{};
            MarkleRoot = new byte[]{};
            Datetime = datetime;
            DifficultyLevel = 0;
            Nonce = 0;
            BlockHash=getHash();
            Index=0;
            
        }

        public byte[] PrevHash {get;set;}
        public byte[] BlockHash { get; }
        public byte[] MarkleRoot {get;set;}

        public DateTime Datetime {get;}

        public int DifficultyLevel {get;}

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

        public bool IsValid(byte[] prevHash)
        {
            return true;
        }

        public void PrintBlock(IBlock prevBlock)
        {
            Console.ForegroundColor=ConsoleColor.Blue;
                Console.WriteLine($"Block        {Index}");

            Console.ForegroundColor=ConsoleColor.Green;
                
            
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
            Console.WriteLine();
        }

        public override string ToString(){
            return Datetime.ToString()+DifficultyLevel.ToString()+Nonce.ToString()+Index.ToString();
        }
    }
}