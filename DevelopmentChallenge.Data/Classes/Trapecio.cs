namespace DevelopmentChallenge.Data.Classes
{
    public class Trapecio : FormaGeometrica
    {
        private readonly double _baseMayor;
        private readonly double _baseMenor;
        private readonly double _altura;
        private readonly double _diagonal1;
        private readonly double _diagonal2;

        public Trapecio(double baseMayor, double baseMenor, double altura, double diagonal1, double diagonal2)
        {
            _baseMayor = baseMayor;
            _baseMenor = baseMenor;
            _altura = altura;
            _diagonal1 = diagonal1;
            _diagonal2 = diagonal2;
        }

        public override double CalcularArea()
        {
            return (_baseMayor + _baseMenor) * _altura / 2;
        }

        public override double CalcularPerimetro()
        {
            return _baseMenor + _baseMayor + _diagonal1 + _diagonal2;
        }
    }
}
