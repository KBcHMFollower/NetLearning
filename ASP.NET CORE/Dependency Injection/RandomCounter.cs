namespace Dependency_Injection
{
    public class RandomCounter : ICounter
    {
        static Random rnd = new Random();
        public int Value { get; private set; }
        public RandomCounter()
        {
            Value = rnd.Next(0, 1000000);
        }
        
    }
}
