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

            Console.WriteLine("Ended Task " + i);

        }

        public async Task TestBackgroundMethod(int i)
        {
            Console.WriteLine("Started TestBackgroundMethod " + i);

            await Task.Delay(2000);

            Console.WriteLine("Ended TestBackgroundMethod " + i);

        }
    }
}
