using System;

namespace chain
{
    public interface IBlock
    {
        int Index {get;}
        byte[] PrevHash { get;set; }
        byte[] BlockHash { get; }
        byte[] MarkleRoot { get;set; }
        DateTime Datetime { get; }
        int DifficultyLevel { get; }
        int Nonce { get;set; }

        byte[] getHash();    
        string ToString();
        bool IsValid(byte[] prevHash);  
        void PrintBlock(IBlock prevBlock);
    }
}