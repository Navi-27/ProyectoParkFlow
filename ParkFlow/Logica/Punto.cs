namespace ParkFlow.Logica
{
    internal readonly struct Punto
    {
        public double X { get; }
        public double Y { get; }

        public Punto(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"({X:0.##}, {Y:0.##})";
        }
    }
}
