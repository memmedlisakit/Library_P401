using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
     static class Extensions
    {
        public static bool checkAllValues( string[] values, string checkValue)
        {
            foreach(string value in values)
            {
                if(string.Equals(value, checkValue))
                {
                    return false;
                }
            }
            return true;
        }

        public static string getHashCode(string password)
        {
            byte[] data = new System.Text.ASCIIEncoding().GetBytes(password);
            var dataEncrypted = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            string hashResult = new System.Text.ASCIIEncoding().GetString(dataEncrypted);

            return hashResult;
        }
    }
}
