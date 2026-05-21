using System;
using System.Collections.Generic;
using DevelopmentChallenge.Data.Classes;

namespace DevelopmentChallenge.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var formas = new List<FormaGeometrica>
            {
                new Cuadrado(5),
                new Cuadrado (1),
                new TrianguloEquilatero (4),
                new TrianguloEquilatero (9),
                new Circulo (2.75m),
                new Circulo (3),
                new TrianguloEquilatero (4.2m),
                new Rectangulo (3, 4)
            };

            var traductor = new Traductor();
            var idiomas = traductor.ObtenerIdiomas();

            Console.WriteLine("Seleccione el idioma del reporte:");
            for (var i = 0; i < idiomas.Length; i++)
            {
                Console.WriteLine($"{i} - {idiomas[i]}");
            }

            Console.Write("Ingrese el indice de idioma: ");
            var entradaUsuario = Console.ReadLine();

            var indiceValido = int.TryParse(entradaUsuario, out var indiceIdiomaSeleccionado)
                              && indiceIdiomaSeleccionado >= 0
                              && indiceIdiomaSeleccionado < idiomas.Length;

            if (!indiceValido)
            {
                Console.WriteLine("no existe idioma, se utilizara el idioma por defecto");
                indiceIdiomaSeleccionado = -1;
            }

            Console.WriteLine();
            Console.WriteLine("===== Reporte =====");
            Console.WriteLine(Reporte.Imprimir(formas, indiceIdiomaSeleccionado));
            Console.WriteLine();

            Console.WriteLine("Presione una tecla para salir...");
            Console.ReadKey();
        }
    }
}
