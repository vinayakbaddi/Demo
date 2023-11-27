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
    }
}
