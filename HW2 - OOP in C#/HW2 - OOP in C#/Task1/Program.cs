using System.Text;

namespace HW2.T1
{
    public class Program
    {
        private static List<Product> products = new List<Product>();

        public static void Run()
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Task 1: Гроші та товар ===");

            bool running = true;
            while (running)
            {
                ShowMenu();
                string choice = Console.ReadLine()?.Trim() ?? "";

                switch (choice)
                {
                    case "1":
                        DemonstrateMoney();
                        break;
                    case "2":
                        CreateProduct();
                        break;
                    case "3":
                        ChangeProductPrice();
                        break;
                    case "4":
                        ShowAllProducts();
                        break;
                    case "5":
                        ComparePrices();
                        break;
                    case "0":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }

                if (running)
                {
                    Console.WriteLine("\nНатисніть Enter для продовження...");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }

        private static void ShowMenu()
        {
            Console.WriteLine("Меню демонстрації:");
            Console.WriteLine("1. Демонстрація класу Money");
            Console.WriteLine("2. Створити новий товар");
            Console.WriteLine("3. Змінити ціну товару");
            Console.WriteLine("4. Показати всі товари");
            Console.WriteLine("5. Порівняти ціни товарів");
            Console.WriteLine("0. Вихід");
            Console.Write("Ваш вибір: ");
        }

        private static void DemonstrateMoney()
        {
            Console.WriteLine("\n--- Демонстрація класу Money ---");

            try
            {
                Money money1 = new Money(125, 90, "грн");
                Money money2 = new Money(50, 25, "грн");

                Console.WriteLine($"Створено Money 1: {money1.DisplayAmount()}");
                Console.WriteLine($"Створено Money 2: {money2.DisplayAmount()}");

                Console.WriteLine("\nТестування властивостей:");
                money1.Hryvnias = 150;
                money1.Kopiyky = 75;
                Console.WriteLine($"Після зміни: {money1.DisplayAmount()}");

                money2.SetAmount(75, 50);
                Console.WriteLine($"Після SetAmount: {money2.DisplayAmount()}");

                Console.WriteLine("\nТестування валідації:");
                try
                {
                    money1.Kopiyky = 150;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Помилка валідації: {ex.Message}");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }

        private static void CreateProduct()
        {
            Console.WriteLine("\n--- Створення нового товару ---");

            try
            {
                Console.Write("Введіть назву товару: ");
                string name = Console.ReadLine()?.Trim() ?? "";
                if (string.IsNullOrWhiteSpace(name)) return;

                Console.Write("Введіть ціну (гривні): ");
                if (!int.TryParse(Console.ReadLine(), out int hryvnias)) return;

                Console.Write("Введіть ціну (копійки): ");
                if (!int.TryParse(Console.ReadLine(), out int kopiyky)) return;

                Console.Write("Введіть опис товару (необов'язково): ");
                string description = Console.ReadLine()?.Trim() ?? "";

                Money price = new Money(hryvnias, kopiyky);
                Product product = new Product(name, price, description);

                products.Add(product);
                Console.WriteLine($"Товар успішно створено: {product}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка створення товару: {ex.Message}");
            }
        }

        private static void ChangeProductPrice()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("Немає товарів для зміни ціни.");
                return;
            }

            Console.WriteLine("\n--- Зміна ціни товару ---");
            ShowAllProducts();

            Console.Write("Введіть номер товару: ");
            if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > products.Count)
            {
                Console.WriteLine("Невірний номер товару.");
                return;
            }

            Product product = products[index - 1];

            Console.WriteLine($"Поточна ціна товару '{product.Name}': {product.Price.DisplayAmount()}");
            Console.Write("Введіть операцію (+ для збільшення, - для зменшення): ");
            string operation = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Введіть суму (гривні): ");
            if (!int.TryParse(Console.ReadLine(), out int hryvnias)) return;

            Console.Write("Введіть суму (копійки): ");
            if (!int.TryParse(Console.ReadLine(), out int kopiyky)) return;

            try
            {
                if (operation == "+")
                {
                    product.IncreasePrice(hryvnias, kopiyky);
                    Console.WriteLine("Ціну успішно збільшено.");
                }
                else if (operation == "-")
                {
                    product.DecreasePrice(hryvnias, kopiyky);
                    Console.WriteLine("Ціну успішно зменшено.");
                }
                else
                {
                    Console.WriteLine("Невірна операція.");
                    return;
                }

                Console.WriteLine($"Нова ціна: {product.Price.DisplayAmount()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка зміни ціни: {ex.Message}");
            }
        }

        private static void ShowAllProducts()
        {
            Console.WriteLine("\n--- Список товарів ---");

            if (products.Count == 0)
            {
                Console.WriteLine("Немає товарів.");
                return;
            }

            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {products[i]}");
            }
        }

        private static void ComparePrices()
        {
            if (products.Count < 2)
            {
                Console.WriteLine("Потрібно принаймні 2 товари для порівняння.");
                return;
            }

            Console.WriteLine("\n--- Порівняння цін товарів ---");
            ShowAllProducts();

            Console.Write("Введіть номер першого товару: ");
            if (!int.TryParse(Console.ReadLine(), out int index1) || index1 < 1 || index1 > products.Count)
            {
                Console.WriteLine("Невірний номер товару.");
                return;
            }

            Console.Write("Введіть номер другого товару: ");
            if (!int.TryParse(Console.ReadLine(), out int index2) || index2 < 1 || index2 > products.Count)
            {
                Console.WriteLine("Невірний номер товару.");
                return;
            }

            Product product1 = products[index1 - 1];
            Product product2 = products[index2 - 1];

            Console.WriteLine($"\nТовар 1: {product1.Name} - {product1.Price.DisplayAmount()}");
            Console.WriteLine($"Товар 2: {product2.Name} - {product2.Price.DisplayAmount()}");

            // Compare prices using overridden Equals
            if (product1.Price.Equals(product2.Price))
            {
                Console.WriteLine("Ціни товарів рівні.");
            }
            else
            {
                // Simple comparison logic
                int price1Total = product1.Price.Hryvnias * 100 + product1.Price.Kopiyky;
                int price2Total = product2.Price.Hryvnias * 100 + product2.Price.Kopiyky;

                if (price1Total > price2Total)
                {
                    Console.WriteLine($"Товар '{product1.Name}' дорожчий за '{product2.Name}'.");
                }
                else
                {
                    Console.WriteLine($"Товар '{product2.Name}' дорожчий за '{product1.Name}'.");
                }
            }
        }
    }
}

