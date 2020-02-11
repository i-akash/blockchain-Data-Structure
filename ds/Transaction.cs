using System.Text;
using System;
namespace chain
{
    public class Transaction
    {
        public Transaction(string from,string to,float amount, DateTime date)
        {
            From = from;
            To = to;
            Amount = amount;
            Date = date;
        }

        public string From { get; }
        public string To { get; }
        public float Amount { get; }
        public DateTime Date { get; }

        public byte[] GetHash(){
            byte[] repBytes=Encoding.UTF8.GetBytes(ToString());
            byte[] hashValue=Hash.ComputeSha256(repBytes);
            return hashValue;
        }

        public override string  ToString(){
            return From+To+Date.ToString()+Amount.ToString();
        }
    }
}