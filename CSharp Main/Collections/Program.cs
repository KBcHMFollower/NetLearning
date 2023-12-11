namespace Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CitizenCollection citizenCollection = new();
            citizenCollection.Add(new Student("123", "Daniel", "G", 18, 'M'));
            citizenCollection.Add(new Student("456", "G", "Z", 20, 'M'));
            citizenCollection.Add(new Worker("2149", "L", "P ", 20, 'M'));
            citizenCollection.Add(new Pensioner("789", "B", "K", 70, 'F'));
            citizenCollection.Add(new Pensioner("71351", "Q", "K", 70, 'F'));
            citizenCollection.Remove(new Pensioner("71351", "Q", "K", 70, 'F'));
            foreach(Citizen item in citizenCollection)
            {
                Console.WriteLine(item.FullName);
            }
        }
    }
}