using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnesCenter.BusinessModels
{
    public static class PasswordGenerator
    {
        public static string Get8CharactersPassword()
        {
            string pass = "";
            var r = new Random();
            while (pass.Length < 8)
            {
                Char c = (char)r.Next(33, 125);
                if (Char.IsLetterOrDigit(c))
                    pass += c;
            }
            return pass;
        }
    }
}
