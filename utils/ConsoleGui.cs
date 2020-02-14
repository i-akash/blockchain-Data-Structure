using System;

namespace chain
{
    public class ConsoleGui
    {
        // INPUT
        public static string InputString(){
            return Console.ReadLine();
        }    

        public static int InputInt32(){
            return Convert.ToInt32(Console.ReadLine());
        }    


        public static Int64 InputInt64(){
            return Convert.ToInt64(Console.ReadLine());
        }    


        public static double InputDouble(){
            return Convert.ToDouble(Console.ReadLine());
        }    

        // OUTPUT
        public static bool ShowHelp(){
            Console.ForegroundColor=ConsoleColor.DarkRed;
            return true;
        }

        public static bool GetPermission(string message){
            ConsoleGui.ShowMessage(message+" No=0  Yes=1?");   
            if(ConsoleGui.InputInt32()==0)
                return false;
            return true;
        }
        public static bool ShowPointer(){
            Console.ForegroundColor=ConsoleColor.DarkRed;
            Console.Write("↳ ");
            Console.ResetColor();
            return true;
        } 
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