namespace HW2.T2
{
    public class Program
    {
        public static void Run()
        {
            Console.WriteLine("=== Task 2: Музичні інструменти ===\n");
            
            List<MusicalInstrument> orchestra = new List<MusicalInstrument>
            {
                new Violin(),
                new Trombone(),
                new Ukulele(),
                new Cello()
            };

            foreach (var instrument in orchestra)
            {
                instrument.DisplayAll();
            }
        }
    }
}

