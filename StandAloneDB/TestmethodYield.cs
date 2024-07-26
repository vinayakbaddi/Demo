using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandAloneDB
{
    public class TestmethodYield

    {
        public static void Process()
        {
            // Example usage:
            foreach (var batch in GetValuesInBatches())
            {
                foreach (var value in batch)
                {
                    Console.WriteLine(value);
                }
            }
        }

        static IEnumerable<List<string>> GetValuesInBatches()
        {
            // Initialize an empty batch
            List<string> batch = new List<string>();

            // Loop through values obtained from GenerateData()
            foreach (var value in GenerateData())
            {
                Console.WriteLine("Received value " + value);

                // Add the value to the current batch
                batch.Add(value);

                // If the batch size reaches 10, yield return it and reset the batch
                if (batch.Count == 10)
                {
                    Console.WriteLine("Received batch of 10");
                    yield return batch;
                    batch = new List<string>();
                }
            }

            // Yield return the remaining items if any
            if (batch.Count > 0)
            {
                yield return batch;
            }
        }

        static IEnumerable<string> GenerateData()
        {
            // Dummy data generation, replace with your actual data retrieval logic
            for (int i = 1; i <= 60000; i++)
            {
                yield return $"Value {i}";
            }
        }
    }

}