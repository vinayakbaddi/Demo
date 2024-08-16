using Newtonsoft.Json;
using RulesEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreConsole.RulesEngines
{


    public class Purchase
    {
        public double PurchaseAmount { get; set; }
        public static string Test {get;set;}
    }

    public class Customer
    {
        public string CustomerType { get; set; }
    }

    public class CallingMethods
    {

        public static void run()
        {
            execute().GetAwaiter().GetResult();
        }
        public static async Task execute()
        {
            // Load the JSON rules from file or directly as string
            string json = System.IO.File.ReadAllText(@"C:\Users\vinay\source\repos\Demo\CoreConsole\bin\Debug\net6.0\RulesEngines\CallingMethods.json");

            // Deserialize JSON into WorkflowRules
            var workflowRules = JsonConvert.DeserializeObject<List<Workflow>>(json);

            // Create Purchase and Customer objects as inputs
            var purchase = new Purchase { PurchaseAmount = 150 };
            Purchase.Test = "100";
            var customer = new Customer { CustomerType = "Premium" };

            // Create RuleParameter directly using object names as in JSON rule
            var ruleParams = new List<RuleParameter>
        {
            new RuleParameter("p", purchase),
            new RuleParameter("customer", customer)
        };

            var reSettingsWithCustomTypes = new ReSettings { CustomTypes = new Type[] { typeof(Testing) } };
//            var r = new RulesEngine.RulesEngine(workflowRules, reSettingsWithCustomTypes);

            // Initialize the Rules Engine with the workflow rules
            var rulesEngine = new RulesEngine.RulesEngine(workflowRules.ToArray(), reSettingsWithCustomTypes);

            // Execute the rule
            var resultList = await rulesEngine.ExecuteAllRulesAsync("OrderWorkflow", ruleParams.ToArray());

            // Check results and invoke custom action if needed
            foreach (var result in resultList)
            {
                if (result.IsSuccess)
                {
                    //Console.WriteLine(result.SuccessEvent);

                    if (result.Rule.SuccessEvent == "ApplyDiscount")
                    {
                        await ApplyDiscount(purchase, customer);
                    }
                    else if (result.Rule.SuccessEvent == "ApplyDiscountP")
                    {
                        await ApplyDiscountP(purchase, customer);
                    }
                    else
                        await ApplyDrop(purchase, customer); 
                }
                else
                {
                    Console.WriteLine(result.ExceptionMessage);
                }
            }
        }

        // Define the custom action dictionary
        private static Dictionary<string, Func<object[], Task>> AddCustomActions()
        {
            return new Dictionary<string, Func<object[], Task>>
        {
            { "ApplyDiscount", async (inputs) => await ApplyDiscount(inputs[0] as Purchase, inputs[1] as Customer) }
            ,{ "ApplyDrop", async (inputs) => await ApplyDrop(inputs[0] as Purchase, inputs[1] as Customer) }

        };
        }

        // Custom action method to be triggered on rule success
        public static async Task ApplyDiscount(Purchase purchase, Customer customer)
        {
            // Logic to apply discount
            Console.WriteLine($"Applying discount to customer: {customer.CustomerType} for purchase amount: {purchase.PurchaseAmount}");
            await Task.CompletedTask;
        }

        public static async Task ApplyDiscountP(Purchase purchase, Customer customer)
        {
            // Logic to apply discount
            Console.WriteLine($"Applying discount to customer: {customer.CustomerType} for purchase amount: {purchase.PurchaseAmount}");
            //return true;
            await Task.CompletedTask;
        }

        public static async Task ApplyDrop(Purchase purchase, Customer customer)
        {
            // Logic to apply discount
            Console.WriteLine($"Applying drop to customer: {customer.CustomerType} for purchase amount: {purchase.PurchaseAmount}");
            await Task.CompletedTask;
        }
    }


    public static class Testing
    {
        public static bool CheckContains(string check, string valList)
        {
            if (String.IsNullOrEmpty(check) || String.IsNullOrEmpty(valList))
                return false;

            var list = valList.Split(',').ToList();
            return list.Contains(check);
        }

        public static bool Drop(string cellMajor, string dropList, string action)
        {
            if (String.IsNullOrEmpty(cellMajor) || String.IsNullOrEmpty(dropList))
                return false;

            var list = dropList.Split(',').ToList();
            if (cellMajor.Equals("cellMajor") && list.Count > 0)
            {
                foreach (var item in list)
                    Console.WriteLine($"Action {item} {action}");

                return true;
            }

            return false;
        }
    }
}
