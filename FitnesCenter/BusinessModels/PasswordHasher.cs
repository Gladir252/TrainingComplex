using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnesCenter.BusinessModels
{
    internal class PasswordHasher
    {
        private readonly string _password;
        private readonly byte[] _salt = new byte[128 / 8];

        public PasswordHasher(string pass)
        {
            _password = pass;
        }

        public string GetHash()
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: _password,
                salt: _salt,
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed;
        }
    }
}
