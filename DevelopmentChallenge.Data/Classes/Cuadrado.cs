namespace DevelopmentChallenge.Data.Classes
{
    public class Cuadrado : FormaGeometrica
    {
        private readonly double _lado;

        public Cuadrado(double lado)
        {
            _lado = lado;
        }

        public override double CalcularArea()
        {
            return _lado * _lado;
        }

        public override double CalcularPerimetro()
        {
            return _lado * 4;
        }
    }
}
