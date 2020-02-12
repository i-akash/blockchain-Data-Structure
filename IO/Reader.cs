using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace chain{
    public class Reader
    {
        public static Chain ReadChain(){
            string path="filesystem";
            string[] blockFiles=Directory.GetFiles(path);
            Chain chain=null;
            Array.Sort(blockFiles,0,blockFiles.Length);
            foreach (var blockFilePath in blockFiles)
            { 
                IBlock block=ReadBlock(blockFilePath);
                if(chain==null){
                    chain=new Chain(block);
                    continue;
                }   

                chain.TryAddBlock(block);
            }
            return chain;
        }

        public static IBlock ReadBlock(string path){
            IBlock block=null;
            using(StreamReader reader=new StreamReader(path)){
            
                var index=Int32.Parse(reader.ReadLine());
                DateTime dateTime=DateTime.Parse(reader.ReadLine());
                var prevHash=ConverterSuit.HexToByteArray(reader.ReadLine());
                var blockHash=ConverterSuit.HexToByteArray(reader.ReadLine());
                var markleRoot=ConverterSuit.HexToByteArray(reader.ReadLine());
                var difficultyLevel=Int32.Parse(reader.ReadLine());
                var nonce=Int32.Parse(reader.ReadLine());
                List<Transaction> transactions=new List<Transaction>();

                if(index>0){
                    
                    while (!reader.EndOfStream)
                    {
                        string from=reader.ReadLine();
                        string to=reader.ReadLine();
                        int amount=Int32.Parse(reader.ReadLine());
                        DateTime date=DateTime.Parse(reader.ReadLine());
                        Transaction transaction=new Transaction(from,to,amount,date);
                        transactions.Add(transaction);
                    }
                    block=new Block(index,dateTime,prevHash,blockHash,markleRoot,transactions,difficultyLevel,nonce);
                }else{
                    block=new GenesisBlock(dateTime);
                }
                reader.Close();
            }
            return block;
        }
    }
}