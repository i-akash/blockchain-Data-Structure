using System.Security.Cryptography;

namespace chain{
    public class HashSuit 
    {
        public static byte[] ComputeSha256(byte[] plainBytes){
            SHA256 sha256=SHA256.Create();
            byte[] hashValue=sha256.ComputeHash(plainBytes);
            return hashValue;
        }
    }

}