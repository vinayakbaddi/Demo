using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profession
{
    public class ActiveDirTest
    {
        static void run()
        {
            string domain = "yourdomain.local"; // Replace with your domain name
            string username = "username"; // Replace with the AD username
            string password = "password"; // Replace with the AD password

            bool isValid = ValidateCredentials(domain, username, password);

            if (isValid)
            {
                Console.WriteLine("Credentials are valid.");
            }
            else
            {
                Console.WriteLine("Invalid credentials.");
            }
        }

        static bool ValidateCredentials(string domain, string username, string password)
        {
            using (PrincipalContext context = new PrincipalContext(ContextType.Domain, domain))
            {
                return context.ValidateCredentials(username, password);
            }
        }
    }
}
