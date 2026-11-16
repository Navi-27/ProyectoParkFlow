namespace ParkFlow.Logica
{
    // Módulo de Cálculo Multivariable de ParkFlow
    internal static class Geometria
    {
        // Supuestos del modelo de capacidad (se reemplazan con las medidas de la observación)
        public const double PorcentajeUtil = 0.60;   // 40 % del área se va en pasillos
        public const double AreaPlaza = 12.5;        // plaza de carro de 2,5 m x 5 m

        // RAA 1: norma del vector que va de un punto a otro
        // d = √[(x₂ − x₁)² + (y₂ − y₁)²]
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

        // RAA 3: integral doble de una zona rectangular
        // A = ∫₀^largo ∫₀^ancho dx dy = ancho · largo
        public static double AreaRectangulo(double ancho, double largo)
        {
            return ancho * largo;
        }

        // RAA 3: teorema de Green. Área de un polígono a partir de sus vértices
        // A = ½ · | Σ (xᵢ · yᵢ₊₁ − xᵢ₊₁ · yᵢ) |
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

        // RAA 3: integral doble de una zona limitada por y = 0 y y = f(x):
        // A = ∫ₐᵇ ∫₀^f(x) dy dx = ∫ₐᵇ f(x) dx, resuelta con la regla de Simpson
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

        // Capacidad: área útil dividida por el área de una plaza
        public static int Capacidad(double area, double porcentajeUtil = PorcentajeUtil, double areaPlaza = AreaPlaza)
        {
            if (areaPlaza <= 0) return 0;
            // Se redondea a 6 decimales para que errores de punto flotante no quiten una plaza
            return (int)Math.Floor(Math.Round(area * porcentajeUtil / areaPlaza, 6));
        }

        // RAA 2: Lagrange. Maximizar A(x, y) = x · y sujeto a g(x, y) = x + 2y = L
        // (un lado va contra el muro). ∇A = λ∇g → (y, x) = λ(1, 2) → x = 2λ, y = λ
        // Reemplazando en la restricción: 4λ = L → λ = L/4, x = L/2, y = L/4
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
        public double Largo { get; }   // lado paralelo al muro (x)
        public double Ancho { get; }   // lados perpendiculares al muro (y)
        public double Area { get; }
        public double Lambda { get; }  // multiplicador de Lagrange

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
