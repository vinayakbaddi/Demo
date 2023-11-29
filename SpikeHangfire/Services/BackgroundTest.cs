namespace SpikeHangfire.Services
{
    public class BackgroundTest : IBackgroundTest
    {
        public BackgroundTest() { }

        public async Task Task1(int i)
        {
            Console.WriteLine("Started Task " + i);

            await Task.Delay(10000);

            await TestBackgroundMethod(i);

            if (i == 5)
                throw new InvalidOperationException();

            Console.WriteLine("Ended Task " + i);

        }



        public async Task TestBackgroundMethod(int i)
        {
            Console.WriteLine("Started TestBackgroundMethod " + i);

            await Task.Delay(2000);
            if (i == 7)
                throw new InvalidOperationException();

            Console.WriteLine("Ended TestBackgroundMethod " + i);

        }

        public async Task MemoryIntensive(int v=1)
        {
            // Adjust the values and loop iterations as needed to increase the CPU load
            int iterations = 100000000;
            double result = 0;
            Console.WriteLine("MemoryIntensive Started...." + v);

            for (int i = 0; i < iterations; i++)
            {
                result += Math.Sqrt(i); // Perform some mathematical operation
            }
            if (v < 100)
                await MemoryIntensive(++v);

            Console.WriteLine("MemoryIntensive completed");
        }
    }
}
