namespace Units
{
    abstract public class Unit
    {
        static int globalId = 0;

        public int Id { get; }
        public string? Name { get; set; }
        public int Attack { get; set; }
        public int Defends { get; set; }

        public Unit(string name, int attack, int defends)
        {
            Name = name;
            Attack = attack; 
            Defends = defends;
        }

        abstract public void Fight();
    }

    abstract public class UnitFactory
    {
        abstract public Unit Create();
    }



    public class Infantry : Unit
    {
        public Infantry(string name, int attack, int defends) : base(name, attack, defends) { }
        
        public override void Fight()
        {
            Console.WriteLine("Infantry fight!");
        }
    }

    public class InfantryFactory : UnitFactory
    {
        public override Unit Create()
        {
            return new Infantry("Infantry", 10, 5);
        }
    }
}
