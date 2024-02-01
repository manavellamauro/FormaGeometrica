using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Helper;
using NUnit.Framework;
using System.Collections.Generic;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), (int)Idioma.Castellano));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), (int)Idioma.Ingles));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnItaliano()
        {
            Assert.AreEqual("<h1>Lista vacaia de formas!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), (int)Idioma.Italiano));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<FormaGeometrica> { new Cuadrado(5) };

            var resumen = FormaGeometrica.Imprimir(cuadrados, (int)Idioma.Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 Formas Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<FormaGeometrica>
            {
                new Cuadrado(5),
                new Cuadrado(1),
                new Cuadrado(3)
            };

            var resumen = FormaGeometrica.Imprimir(cuadrados, (int)Idioma.Ingles);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 Shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<FormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75),
                new TrianguloEquilatero(4.2)
            };

            var resumen = FormaGeometrica.Imprimir(formas, (int)Idioma.Ingles);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Circles | Area 13,01 | Perimeter 18,06 <br/>2 Squares | Area 29 | Perimeter 28 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 Shapes Perimeter 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<FormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75),
                new TrianguloEquilatero(4.2)
            };

            var resumen = FormaGeometrica.Imprimir(formas, (int)Idioma.Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>2 Cuadrados | Area 29 | Perimetro 28 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 Formas Perimetro 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnItaliano()
        {
            var formas = new List<FormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75),
                new Trapecio(5,2,3,3.2,3.2),
                new TrianguloEquilatero(4.2)
            };

            var resumen = FormaGeometrica.Imprimir(formas, (int)Idioma.Italiano);

            Assert.AreEqual(
                "<h1>Rapporto sulle forme</h1>2 Cerchi | La zona 13,01 | Perimetro 18,06 <br/>2 Piazze | La zona 29 | Perimetro 28 <br/>1 Trapezio | La zona 10,5 | Perimetro 13,4 <br/>3 Triangoli | La zona 49,64 | Perimetro 51,6 <br/>TOTALE:<br/>8 Forme Perimetro 111,06 La zona 102,15",
                resumen);
        }
    }
}
