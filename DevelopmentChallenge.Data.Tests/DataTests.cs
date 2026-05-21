using System;
using System.Collections.Generic;
using DevelopmentChallenge.Data.Classes;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        private readonly Traductor _traductor = new Traductor();
        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                Reporte.Imprimir(new List<FormaGeometrica>(), 0));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                Reporte.Imprimir(new List<FormaGeometrica>(), 1));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<FormaGeometrica> {new Cuadrado(5) };

            var resumen = Reporte.Imprimir(cuadrados, 0);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<FormaGeometrica>
            {
                new Cuadrado (5),
                new Cuadrado (1),
                new Cuadrado (3)
            };

            var resumen = Reporte.Imprimir(cuadrados, 1);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<FormaGeometrica>
            {
                new Cuadrado (5),
                new Circulo (3),
                new TrianguloEquilatero (4),
                new Cuadrado (2),
                new TrianguloEquilatero (9),
                new Circulo (2.75m),
                new TrianguloEquilatero (4.2m)
            };

            var resumen = Reporte.Imprimir(formas, 1);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<FormaGeometrica>
            {
                new Cuadrado (5),
                new Circulo (3),
                new TrianguloEquilatero (4),
                new Cuadrado (2),
                new TrianguloEquilatero (9),
                new Circulo (2.75m),
                new TrianguloEquilatero (4.2m)
            };

            var resumen = Reporte.Imprimir(formas, 0);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
                resumen);
        }

        [Test]
        public void ObtenerIdiomas_DeberiaRetornarLosTresIdiomasConfigurados()
        {
            var idiomas = _traductor.ObtenerIdiomas();

            CollectionAssert.AreEquivalent(new[] { "Castellano", "Ingles", "Italiano" }, idiomas);
            Assert.AreEqual(3, idiomas.Length);
        }

        [Test]
        public void Traducir_Castellano_DeberiaRetornarTextoEnEspanol()
        {
            var traduccion = _traductor.Traducir("reporte_titulo", "Castellano");

            Assert.AreEqual("Reporte de Formas", traduccion);
        }

        [Test]
        public void Traducir_Ingles_DeberiaRetornarTextoEnIngles()
        {
            var traduccion = _traductor.Traducir("rectangulo_plural", "Ingles");

            Assert.AreEqual("Rectangles", traduccion);
        }

        [Test]
        public void Traducir_Italiano_DeberiaRetornarTextoEnItaliano()
        {
            var traduccion = _traductor.Traducir("cuadrado_singular", "Italiano");

            Assert.AreEqual("Piazza", traduccion);
        }

        [Test]
        public void Traducir_ClaveInexistente_DeberiaRetornarLaClaveOriginal()
        {
            var traduccion = _traductor.Traducir("clave_inexistente", "Castellano");

            Assert.AreEqual("clave_inexistente", traduccion);
        }
    }
}
