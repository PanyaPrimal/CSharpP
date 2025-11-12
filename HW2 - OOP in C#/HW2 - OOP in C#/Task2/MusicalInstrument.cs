namespace HW2.T2
{
    public abstract class MusicalInstrument
    {
        protected string Name { get; set; }
        protected string Description { get; set; }
        protected string HistoryInfo { get; set; }

        protected MusicalInstrument(string name, string description, string history)
        {
            Name = name;
            Description = description;
            HistoryInfo = history;
        }

        public virtual void Show()
        {
            Console.WriteLine($"Інструмент: {Name}");
        }

        public virtual void Desc()
        {
            Console.WriteLine($"Опис: {Description}");
        }

        public virtual void History()
        {
            Console.WriteLine($"Історія: {HistoryInfo}");
        }

        public void DisplayAll()
        {
            Show();
            Desc();
            History();
            Console.WriteLine();
        }
    }
}

