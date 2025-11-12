namespace HW2.T3
{
    public class Program
    {
        public static void Run()
        {
            Console.WriteLine("=== Task 3: Десяткове число ===\n");

            while (true)
            {
                Console.Write("Enter a decimal number (or 'exit' to quit): ");
                string? input = Console.ReadLine();

                if (input?.ToLower() == "exit") break;

                if (int.TryParse(input, out int value))
                {
                    var number = new DecimalNumber(value);

                    Console.WriteLine($"\nDecimal: {number.Value}");
                    Console.WriteLine($"Binary:  {number.ToBinary()}");
                    Console.WriteLine($"Octal:   {number.ToOctal()}");
                    Console.WriteLine($"Hex:     {number.ToHex()}");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.\n");
                }
            }
        }
    }
}

