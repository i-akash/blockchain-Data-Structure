using System;
using System.Collections.Generic;

namespace chain
{
    public interface IBlock
    {
        int Index {get;}
        byte[] PrevHash { get;set; }
        byte[] BlockHash { get;set; }
        byte[] MarkleRoot { get;set; }
        DateTime Datetime { get; }
        public List<Transaction> Transactions { get; }
        int DifficultyLevel { get; }
        int Nonce { get;set; }


        bool Sync();
        byte[] GetHash();  
        bool IsValid(byte[] prevHash);  
        void PrintBlock();
    }
}