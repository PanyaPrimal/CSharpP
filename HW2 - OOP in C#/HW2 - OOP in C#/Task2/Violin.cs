namespace HW2.T2
{
    public class Violin : MusicalInstrument
    {
        public Violin() : base(
            "Скрипка (Violin)",
            "Струнно-смичковий інструмент з 4 струнами, діапазон від G3 до E7. Корпус з резонансної деки, гриф без ладів.",
            "Виникла в Італії на початку XVI століття. Майстри Страдіварі та Гварнері створили легендарні інструменти."
        )
        { }

        public override void Show()
        {
            Console.WriteLine($"{Name}");
        }
    }
}

