using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using marketplace.Data.Models;
using marketplace.Data.Seed;

namespace marketplace.Domain.Repsositories
{
    public class CheckingForInputs
    {
        public static bool DoesEmailAlreadyExisist(string email)
        {
            if (Seed.Buyers.Count <= 0)
            {
                return false;
            }
            else
            {
                if (Seed.Buyers.Any(x => x.Email == email))
                {
                    return true;
                }
                else if (Seed.Sellers.Any(x => x.Email == email))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public static string CheckRoleOfUser( string emailOfInputedUser)
        {
            if(Seed.Buyers.Any(x => x.Email == emailOfInputedUser))
            {
                return "buyer";
            }
            else 
            {
                return "seller";
            }
        }

        public static bool CheckIfUserExists( string emailOfInputedUser)
        {
            if (Seed.Buyers.Any(x => x.Email == emailOfInputedUser))
            {
                return true;
            }
            else if (Seed.Sellers.Any(x => x.Email == emailOfInputedUser))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
