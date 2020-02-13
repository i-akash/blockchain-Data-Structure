using System;

namespace chain
{
    public class Puzzle
    {
       public static bool Solve(IBlock block){
           string hexString=ConverterSuit.ByteArrayToHex(block.BlockHash);
           string difficultyString=hexString.Substring(0,block.DifficultyLevel);
           string masterString=new string('0',block.DifficultyLevel);

           Console.WriteLine($"{block.Nonce} {hexString}");
           if(difficultyString.Equals(masterString)){
               return true;
           }
           return false;
       }
    }
}