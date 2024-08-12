using Newtonsoft.Json;
using RulesEngine;
using RulesEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreConsole.RulesEngines
{
    public class RulesWiki
    {

        public static void run()
        {
            exe().GetAwaiter().GetResult();
        }

        private static async Task exe()
        {
            string jsonRules = File.ReadAllText(@"C:\Users\vinay\source\repos\Demo\CoreConsole\bin\Debug\net6.0\RulesEngines\ruleswiki.json");
            var workflowRules = JsonConvert.DeserializeObject<Workflow[]>(jsonRules);
            var reSettingsWithCustomTypes = new ReSettings { CustomTypes = new Type[] { typeof(Utils) } };
            var  r =new RulesEngine.RulesEngine(workflowRules,  reSettingsWithCustomTypes);

            //// Define input
            var input1 = new
            {
                country = "kuch",
                loyaltyFactor = 3,
                totalPurchasesToDate = 12000
            };

            // Execute rules
            var resultList = await r.ExecuteAllRulesAsync("Discount", input1);

            // Display results
            foreach (var result in resultList)
            {
                Console.WriteLine($"Rule: {result.Rule.RuleName}, Success: {result.IsSuccess}");
            }

        }
    }

    public static class Utils
    {
        public static bool CheckContains(string check, string valList)
        {
            if (String.IsNullOrEmpty(check) || String.IsNullOrEmpty(valList))
                return false;

            var list = valList.Split(',').ToList();
            return list.Contains(check);
        }

        public static bool Drop(string cellMajor, string dropList,string action)
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
