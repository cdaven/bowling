namespace Bowling
{
    class Roll
    {
        public int Pins { get; private set; } = 0;
        public int Bonus { get; private set; } = 0;
        public int Score => Pins + Bonus;

        public bool IsStrike => Pins == 10;
        public bool IsSpare { get; set; } = false;

        public Roll(int pins)
        {
            Pins = pins;
        }

        public void AddBonus(int pins)
        {
            Bonus += pins;
        }

        public override string ToString()
        {
            var s = Pins.ToString();
            if (Bonus > 0)
                s += $"(+{Bonus})";
            return s;
        }
    }
}
