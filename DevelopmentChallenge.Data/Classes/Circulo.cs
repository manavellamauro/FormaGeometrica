using System;

namespace DevelopmentChallenge.Data.Classes
{
    public class Circulo : FormaGeometrica
    {
        private readonly double _radio;

        public Circulo(double diametro)
        {
            _radio = diametro / 2;
        }

        public override double CalcularArea()
        {
            return Math.PI * _radio * _radio;
        }

        public override double CalcularPerimetro()
        {
            return Math.PI * _radio * 2;
        }
    }
}
