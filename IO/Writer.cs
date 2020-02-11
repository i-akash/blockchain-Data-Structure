using System.IO;

namespace chain{
    public class Writer
    {
        public static void WriteChain(Chain chain){
            var blockChain=chain.BlockChain;
            foreach (IBlock block in blockChain)
            {
                WriteBlock(block);
            }   
        }

        public static void WriteBlock(IBlock block){
            string path=$"filesystem/block{block.Index}.txt";

            using(StreamWriter writer=new StreamWriter(path)){
                
                writer.WriteLine(block.Index);
                foreach (var byteValue in block.PrevHash)
                    writer.Write(byteValue);    
                writer.WriteLine();

                foreach (var byteValue in block.BlockHash)
                {
                    writer.Write(byteValue);    
                }
                writer.WriteLine();
                foreach (var byteValue in block.MarkleRoot)
                {
                    writer.Write(byteValue);    
                }
                writer.WriteLine();

                writer.WriteLine(block.Difficulty_Level);
                writer.WriteLine(block.Nonce);
                writer.Close();
            }
        }
    }
}