using System;

namespace DevelopmentChallenge.Data.Classes
{
    public class TrianguloEquilatero : FormaGeometrica
    {
        private readonly double _lado;

        public TrianguloEquilatero(double lado)
        {
            _lado = lado;
        }

        public override double CalcularArea()
        {
            return (Math.Sqrt(3) / 4) * _lado * _lado;
        }

        public override double CalcularPerimetro()
        {
            return _lado * 3;
        }
    }
}
