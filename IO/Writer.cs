using System;
using System.IO;

namespace chain{
    public class Writer
    {
        public static void WriteChain(Chain chain){
            var blockChain=chain.BlockChain;
            bool isGenesisBlock=true;
            foreach (IBlock block in blockChain)
            {
                WriteBlock(block,isGenesisBlock);
                isGenesisBlock=false;
            }   
        }

        public static void WriteBlock(IBlock block,bool isGenesisBlock){
            string path=$"filesystem/block{block.Index}.txt";


            using(StreamWriter writer=new StreamWriter(path)){
                
                writer.WriteLine(block.Index);
                writer.WriteLine(block.Datetime);
                
                writer.WriteLine(ConverterSuit.ByteArrayToHex(block.PrevHash));
                writer.WriteLine(ConverterSuit.ByteArrayToHex(block.BlockHash));
                writer.WriteLine(ConverterSuit.ByteArrayToHex(block.MarkleRoot));

                writer.WriteLine(block.DifficultyLevel);
                writer.WriteLine(block.Nonce);


                if (block is Block)
                {
                    var block1=block as Block;
                    var transactions=block1.Transactions;
                    foreach (var transaction in transactions)
                    {
                        writer.WriteLine(transaction.From);
                        writer.WriteLine(transaction.To);
                        writer.WriteLine(transaction.Amount);
                        writer.WriteLine(transaction.Date);
                    }
                }
                writer.Close();
            }
        }
    }
}