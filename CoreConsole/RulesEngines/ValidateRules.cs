using Newtonsoft.Json;
using RulesEngine.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Profession.RulesEngines
{
    public class TestRules
    {
        public static void run()
        {
            //ex().GetAwaiter().GetResult();
            micro().GetAwaiter().GetResult();
        }

        static async Task micro()
        {
            string jsonRules = File.ReadAllText(@"C:\Users\vinay\source\repos\Demo\CoreConsole\bin\Debug\net6.0\RulesEngines\micro.json");
            var workflowRules = JsonConvert.DeserializeObject<Workflow[]>(jsonRules);
            //var workflow = Newtonsoft.Json.JsonConvert.DeserializeObject<Workflow[]>(workflowJson);

            // Initialize RulesEngine
            var rulesEngine = new RulesEngine.RulesEngine(workflowRules, null);

            // Define input
            var input1 = new
            {
                country = "india",
                loyaltyFactor = 3,
                totalPurchasesToDate = 12000
            };

            // Execute rules
            var resultList = await rulesEngine.ExecuteAllRulesAsync("Discount", input1);

            // Display results
            foreach (var result in resultList)
            {
                Console.WriteLine($"Rule: {result.Rule.RuleName}, Success: {result.IsSuccess}");
            }
        }


        static async Task ex()
        {
            // Load rules from JSON file
            string jsonRules = File.ReadAllText(@"C:\Users\vinay\source\repos\Demo\CoreConsole\bin\Debug\net6.0\RulesEngines\rules.json");
            var workflowRules = JsonConvert.DeserializeObject<List<Workflow>>(jsonRules);

            // Create an instance of the RulesEngine
            var reSettings = new ReSettings { CustomTypes = new[] { typeof(CustomActions) } };
            var re = new RulesEngine.RulesEngine(workflowRules?.ToArray(), reSettings);

            // Define the input object
            var person = new Person { Name = "John", Age = 20 };
            var ruleParams = new List<RuleParameter> { new RuleParameter("input1", person) };

            // Evaluate rules
            var resultList = await re.ExecuteAllRulesAsync("SimpleWorkflow", ruleParams.ToArray());

            foreach (var result in resultList)
            {
                if (result.IsSuccess)
                {
                    Console.WriteLine($"Rule '{result.Rule.RuleName}' passed: {result.Rule.SuccessEvent}");
                }
                else
                {
                    Console.WriteLine($"Rule '{result.Rule.RuleName}' failed: {result.ExceptionMessage}");
                }
            }
        }
    }


    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public class CustomActions
    {
        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        //public void PrintMessage(string messageTemplate, object input1)
        //{
        //    // Assuming input1 is a dynamic object or use reflection to access properties
        //    var person = input1 as Person;
        //    if (person != null)
        //    {
        //        string message = messageTemplate.Replace("{input1.Name}", person.Name);
        //        Console.WriteLine(message);
        //    }
        //}
    }
    internal class ValidateRules
    {
    }
}