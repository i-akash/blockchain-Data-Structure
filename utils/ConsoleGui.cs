using System;

namespace chain
{
    public class ConsoleGui
    {
        
        public static bool ShowMessage(string message){
            Console.ForegroundColor=ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
            return true;
        }


        public static bool ShowBlock(IBlock block){
            Console.WriteLine($"Block        {block.Index}");
            Console.WriteLine($"Date Time    {block.Datetime}");
            Console.Write("Prev Hash    ");
            foreach (var byteValue in block.PrevHash)
            {
                Console.Write(byteValue);    
            }
            Console.WriteLine();

            Console.Write("Block Hash    ");
            foreach (var byteValue in block.BlockHash)
            {
                Console.Write(byteValue);    
            }
            Console.WriteLine();

            Console.Write("Markle Root   ");
            foreach (var byteValue in block.MarkleRoot)
            {
                Console.Write(byteValue);    
            }
            Console.WriteLine();

            Console.WriteLine($"Level     {block.DifficultyLevel}");
            Console.WriteLine($"Nonce     {block.Nonce}");


            foreach (var transaction in block.Transactions)
            {
                ShowTransaction(transaction);
            }

            Console.WriteLine();
            return true;
        }


        public static bool ShowTransaction(Transaction transaction){
            Console.WriteLine($"f: {transaction.From} - t: {transaction.To} - am: {transaction.Amount} - d: {transaction.Date}");
            return true;
        }
    }
}