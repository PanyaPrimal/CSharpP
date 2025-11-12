namespace HW2.T2
{
    public class Trombone : MusicalInstrument
    {
        public Trombone() : base(
            "Тромбон (Trombone)",
            "Мідний духовий інструмент з висувною кулісою замість вентилів. Діапазон від E2 до F5.",
            "Походить від середньовічної сакбути (XV ст.). Назва від італійського 'tromba' (труба) + суфікс 'one' (великий)."
        )
        { }

        public override void Show()
        {
            Console.WriteLine($"{Name}");
        }
    }
}

