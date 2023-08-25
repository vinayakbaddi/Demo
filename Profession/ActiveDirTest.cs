//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Profession
//{
//    public class ActiveDirTest
//    {
//        static void run()
//        {
//            string domain = "yourdomain.local"; // Replace with your domain name
//            string username = "username"; // Replace with the AD username
//            string password = "password"; // Replace with the AD password

//            bool isValid = ValidateCredentials(domain, username, password);

//            if (isValid)
//            {
//                Console.WriteLine("Credentials are valid.");
//            }
//            else
//            {
//                Console.WriteLine("Invalid credentials.");
//            }
//        }

//        static bool ValidateCredentials(string domain, string username, string password)
//        {
//            using (PrincipalContext context = new PrincipalContext(ContextType.Domain, domain))
//            {
//                return context.ValidateCredentials(username, password);
//            }
//        }
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        string domainName = "yourdomain.com"; // Replace with your actual domain name
//        string userName = "yourusername"; // Replace with the username to check

//        bool isValid = IsUserValid(domainName, userName);

//        if (isValid)
//        {
//            Console.WriteLine("User is valid.");
//        }
//        else
//        {
//            Console.WriteLine("User is not valid.");
//        }
//    }

//    static bool IsUserValid(string domainName, string userName)
//    {
//        try
//        {
//            using (PrincipalContext context = new PrincipalContext(ContextType.Domain, domainName))
//            {
//                UserPrincipal user = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, userName);

//                if (user != null)
//                {
//                    // Additional checks can be performed here to validate GSMA account details
//                    // For example, you might want to check certain attributes or group membership.
//                    return true;
//                }
//                else
//                {
//                    return false;
//                }
//            }
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine("An error occurred: " + ex.Message);
//            return false;
//        }
//    }
//    static bool IsGMSAValid(string gmsaName)
//    {
//        using (PrincipalContext context = new PrincipalContext(ContextType.Domain))
//        {
//            // Search for the GMSA by its SAMAccountName (Account Name)
//            using (ComputerPrincipal gmsa = ComputerPrincipal.FindByIdentity(context, IdentityType.SamAccountName, gmsaName))
//            {
//                if (gmsa != null)
//                {
//                    // Check if the found principal is a GMSA
//                    if (gmsa.ServicePrincipalNames != null && gmsa.ServicePrincipalNames.Contains("GMSA"))
//                    {
//                        return true;
//                    }
//                }
//            }
//        }

//        return false;
//    }
//}
