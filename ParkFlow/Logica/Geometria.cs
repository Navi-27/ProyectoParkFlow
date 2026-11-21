namespace ParkFlow.Logica
{
    internal static class Geometria
    {
        public const double PorcentajeUtil = 0.60;   
        public const double AreaPlaza = 12.5;  

        public static double Distancia(double x1, double y1, double x2, double y2)
        {
            double dx = x2 - x1;
            double dy = y2 - y1;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public static double Distancia(Punto a, Punto b)
        {
            return Distancia(a.X, a.Y, b.X, b.Y);
        }

        public static double AreaRectangulo(double ancho, double largo)
        {
            return ancho * largo;
        }

        public static double AreaPoligono(IList<Punto> vertices)
        {
            if (vertices.Count < 3) return 0;

            double suma = 0;
            for (int i = 0; i < vertices.Count; i++)
            {
                Punto a = vertices[i];
                Punto b = vertices[(i + 1) % vertices.Count];
                suma += a.X * b.Y - b.X * a.Y;
            }
            return Math.Abs(suma) / 2;
        }

        public static double AreaBajoCurva(Func<double, double> f, double a, double b, int n = 100)
        {
            if (n % 2 != 0) n++;
            double h = (b - a) / n;
            double suma = f(a) + f(b);
            for (int i = 1; i < n; i++)
            {
                suma += f(a + i * h) * (i % 2 == 0 ? 2 : 4);
            }
            return suma * h / 3;
        }

        public static int Capacidad(double area, double porcentajeUtil = PorcentajeUtil, double areaPlaza = AreaPlaza)
        {
            if (areaPlaza <= 0) return 0;
            return (int)Math.Floor(Math.Round(area * porcentajeUtil / areaPlaza, 6));
        }

        public static ZonaOptima ZonaOptima(double demarcacion)
        {
            double lambda = demarcacion / 4;
            double largo = 2 * lambda;
            double ancho = lambda;
            return new ZonaOptima(largo, ancho, largo * ancho, lambda);
        }
    }

    internal readonly struct ZonaOptima
    {
        public double Largo { get; }  
        public double Ancho { get; }  
        public double Area { get; }
        public double Lambda { get; }  

        public ZonaOptima(double largo, double ancho, double area, double lambda)
        {
            Largo = largo;
            Ancho = ancho;
            Area = area;
            Lambda = lambda;
        }

        public int Capacidad
        {
            get { return Geometria.Capacidad(Area); }
        }
    }
}
