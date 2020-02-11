using System.IO;

namespace chain{
    public class Reader
    {
        public static void ReadChain(){

        }

        public static IBlock ReadBlock(string path){
            IBlock block=new Block();
            using(StreamReader reader=new StreamReader(path)){
                
                var Index=reader.ReadLine();
                var prevHash=reader.ReadLine();
                var BlockHash=reader.ReadLine();
                var MarkleRoot=reader.ReadLine();
                var Difficulty_Level=reader.ReadLine();
                var Nonce=reader.ReadLine();
               
                reader.Close();
            }
            return block;
        }
    }
}