using Newtonsoft.Json;
using RulesEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreConsole.RulesEngines
{
    public class RunExample
    {

        public static void ex()
        {
            //ruleE().GetAwaiter().GetResult();
            runCode();
        }

        static void runCode()
        {
            List<Rule> rules = new List<Rule>();

            Rule rule = new Rule();
            rule.RuleName = "Test Rule";
            rule.SuccessEvent = "Count is within tolerance.";
            rule.ErrorMessage = "Over expected.";
            rule.Expression = "count < 3";
            rule.RuleExpressionType = RuleExpressionType.LambdaExpression;
            rules.Add(rule);

            var workflows = new List<Workflow>();

            Workflow exampleWorkflow = new Workflow();
            exampleWorkflow.WorkflowName = "Example Workflow";
            exampleWorkflow.Rules = rules;

            workflows.Add(exampleWorkflow);

            var bre = new RulesEngine.RulesEngine(workflows.ToArray());
        }
        //static async Task ruleE()
        //{
        //    // Load rules from JSON file
        //    //string jsonRules = File.ReadAllText("rules.json");
        //    string jsonRules = File.ReadAllText(@"C:\Users\vinay\source\repos\Demo\CoreConsole\bin\Debug\net6.0\RulesEngines\rules.json");

        //    var workflowRules = JsonConvert.DeserializeObject<List<Workflow>>(jsonRules);

        //    // Create an instance of the RulesEngine with custom actions registered
        //    var reSettings = new ReSettings { CustomTypes = new[] { typeof(CustomActions) } };
        //    var re = new RulesEngine.RulesEngine(workflowRules?.ToArray(), reSettings);

        //    // Define the input object
        //    var person = new Person { Name = "John", Age = 20 };
        //    var ruleParams = new List<RuleParameter> { new RuleParameter("input1", person) };

        //    // Evaluate rules
        //    var resultList = await re.ExecuteAllRulesAsync("SimpleWorkflow", ruleParams.ToArray());
        //    //var resultList = await re.ExecuteAllRulesAsync("SimpleWorkflow");

        //    foreach (var result in resultList)
        //    {
        //        if (result.IsSuccess)
        //        {
        //            Console.WriteLine($"Rule '{result.Rule.RuleName}' passed: {result.Rule.SuccessEvent}");
        //        }
        //        else
        //        {
        //            Console.WriteLine($"Rule '{result.Rule.RuleName}' failed: {result.ExceptionMessage}");
        //        }
        //    }
        //}
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    //public class CustomActions
    //{
    //    // Ensure this method is public and matches the method name in JSON
    //    public void PrintMessage(string message)
    //    {
    //        Console.WriteLine(message);
    //    }
    //}
}
