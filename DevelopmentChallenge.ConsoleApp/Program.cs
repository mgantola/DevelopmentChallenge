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

            Console.WriteLine("===== Reporte en Castellano =====");
            Console.WriteLine(Reporte.Imprimir(formas, 0));
            Console.WriteLine();

            Console.WriteLine("===== Report in English =====");
            Console.WriteLine(Reporte.Imprimir(formas, 1));
            Console.WriteLine();

            Console.WriteLine("===== Rapporto in italiano =====");
            Console.WriteLine(Reporte.Imprimir(formas, 2));
            Console.WriteLine();

            Console.WriteLine("===== Reporte para validar idioma default (Ingles) =====");
            Console.WriteLine(Reporte.Imprimir(formas, 9));
            Console.WriteLine();

            Console.WriteLine("Presione una tecla para salir...");
            Console.ReadKey();
        }
    }
}
