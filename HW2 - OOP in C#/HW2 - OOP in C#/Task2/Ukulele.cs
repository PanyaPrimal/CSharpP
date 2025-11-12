namespace HW2.T2
{
    public class Ukulele : MusicalInstrument
    {
        public Ukulele() : base(
            "Укулеле (Ukulele)",
            "Гавайська 4-струнна щипкова гітара. Компактний розмір, м'який звук. Стандартний стрій: G-C-E-A.",
            "Створена на Гаваях у 1880-х на основі португальської кавакіньо. Назва означає 'стрибаюча блоха' гавайською."
        )
        { }

        public override void Show()
        {
            Console.WriteLine($"{Name}");
        }
    }
}

