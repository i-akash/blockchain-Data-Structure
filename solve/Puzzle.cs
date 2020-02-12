using System;

namespace chain
{
    public class Puzzle
    {
       public static bool Solve(IBlock block){
           string hexString=ConverterSuit.ByteArrayToHex(block.BlockHash);
           string difficultyString=hexString.Substring(0,block.DifficultyLevel);
           Console.WriteLine(hexString);
           if(difficultyString.Equals("00"))
                return true;
           return false;
       }
    }
}