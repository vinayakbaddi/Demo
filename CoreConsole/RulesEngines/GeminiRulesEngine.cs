using Newtonsoft.Json;
using RulesEngine.Actions;
using RulesEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreConsole.RulesEngines
{
    internal class GeminiRulesEngine
    {
    }

    public class InputData
    {
        public decimal Price { get; set; }
    }

    public class CustomActionBase
    {
        protected InputData Input { get; set; }

        public CustomActionBase(InputData input)
        {
            Input = input;
        }

        public virtual void Run() { }
    }

    public class ApplyDiscount10 : CustomActionBase
    {
        public ApplyDiscount10(InputData input) : base(input) { }

        public override void Run()
        {
            Input.Price *= 0.9m;
            Console.WriteLine("Discount 10% applied.");
        }
    }

    public class ApplyDiscount20 : CustomActionBase
    {
        public ApplyDiscount20(InputData input) : base(input) { }

        public override void Run()
        {
            Input.Price *= 0.8m;
            Console.WriteLine("Discount 20% applied.");
        }
    }

    public class RunProgram
    {
        public static void Run()
        {
            string json = File.ReadAllText(@"C:\Users\vinay\source\repos\Demo\CoreConsole\bin\Debug\net6.0\RulesEngines\grules.json");

            //var json = File.ReadAllText("rules.json");
            var workflow = JsonConvert.DeserializeObject<Workflow[]>(json);

            var input = new InputData { Price = 150 };

            var reSettings = new ReSettings
            {
                //CustomActions = new Dictionary<string, Func<ActionBase>>
                //{
                //    { "ApplyDiscount10", new ApplyDiscount10(input) },
                //    { "ApplyDiscount20", () => new ApplyDiscount20(input) }
                //}
            };

            var rulesEngine = new RulesEngine.RulesEngine(workflow, reSettings);
            rulesEngine.ExecuteAllRulesAsync(workflow.FirstOrDefault().WorkflowName, input);

            Console.WriteLine($"Final price: {input.Price}");
        }

        private static ActionBase t10()
        {
            throw new NotImplementedException();
        }
    }
}


