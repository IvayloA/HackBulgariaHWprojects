using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem
{
    class SystemSecurity
    {
        internal static string CreateSalt(int saltSize)
        {
            // Generate a random salt
            RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider();
            byte[] salt = new byte[saltSize];
            csprng.GetBytes(salt);
            return Convert.ToBase64String(salt);
        }

        internal static string GenerateHashedPassword(string input, string salt)
        {
            byte[] bts = Encoding.UTF8.GetBytes(input + salt);
            var sha256Hasher = new SHA256Managed();

            var hash = sha256Hasher.ComputeHash(bts);

            return Convert.ToBase64String(hash);

        }

        public static bool UserExist(TicketSystemDBEntities db, string userName, string userPassword)
        {
            var userInDB = (from user in db.Users
                            where user.UserName == userName
                            select user).SingleOrDefault();

            if (userInDB == null) return false;


            string hashedPassword = GenerateHashedPassword(userPassword, userInDB.SaltConteiner);

            if (hashedPassword == userInDB.UserPassword)
            { return true; }
            else { return false; } 
                            
        }
    }

}

