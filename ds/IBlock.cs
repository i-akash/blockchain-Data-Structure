using System;

namespace chain
{
    public interface IBlock
    {
        int Index {get;}
        byte[] PrevHash { get; }
        byte[] BlockHash { get; }
        byte[] MarkleRoot { get; }
        DateTime Datetime { get; }
        int Difficulty_Level { get; }
        int Nonce { get;set; }

        byte[] getHash();    
        string ToString();
        bool IsValid(byte[] prevHash,byte[] blockHash);  
    }
}