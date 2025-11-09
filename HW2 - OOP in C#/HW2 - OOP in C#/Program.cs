using System.Text;
using HW2.T1;
using HW2.T2;
using HW2.T3;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        
        while (true)
        {
            Console.WriteLine("HW2 - OOP in C# Demonstration");
            Console.WriteLine("================================\n");
            Console.WriteLine("Task 1: Гроші та товар (Money and Product)");
            Console.WriteLine("Task 2: Музичні інструменти (Musical Instruments)");
            Console.WriteLine("Task 3: Десяткове число (Decimal Number)");
            Console.WriteLine("0: Exit");
            Console.WriteLine("\nEnter your choice (0-3):");
            
            var key = Console.ReadLine();
            Console.WriteLine();

            switch (key)
            {
                case "1":
                    HW2.T1.Program.Run();
                    break;
                case "2":
                    HW2.T2.Program.Run();
                    break;
                case "3":
                    HW2.T3.Program.Run();
                    break;
                case "0":
                    Console.WriteLine("До побачення!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine("\nНатисніть Enter, щоб продовжити...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}