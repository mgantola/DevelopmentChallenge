/******************************************************************************************************************/
/******* ¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
/******************************************************************************************************************/

/*
 * TODO: 
 * Refactorizar la clase para respetar principios de la programación orientada a objetos.
 * Implementar la forma Trapecio/Rectangulo. 
 * Agregar el idioma Italiano (o el deseado) al reporte.
 * Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada (los tests deben pasar correctamente al entregar la solución, incluso los actuales.)
 * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar la nueva versión :).
 */

using System;

namespace DevelopmentChallenge.Data.Classes
{
    public abstract class FormaGeometrica
    {
        public abstract decimal CalcularArea();
        public abstract decimal CalcularPerimetro();
    }

    public class Cuadrado : FormaGeometrica
    {
        private readonly decimal _lado;

        public Cuadrado(decimal lado)
        {
            _lado = lado;
        }

        public override decimal CalcularArea()
        {
            return _lado * _lado;
        }

        public override decimal CalcularPerimetro()
        {
            return _lado * 4;
        }
    }

    public class Circulo : FormaGeometrica
    {
        private readonly decimal _radio;

        public Circulo(decimal radio)
        {
            _radio = radio;
        }

        public override decimal CalcularArea()
        {
            return (decimal)Math.PI * (_radio / 2) * (_radio / 2);
        }

        public override decimal CalcularPerimetro()
        {
            return (decimal)Math.PI * _radio;
        }
    }

    public class TrianguloEquilatero : FormaGeometrica
    {
        private readonly decimal _lado;

        public TrianguloEquilatero(decimal lado)
        {
            _lado = lado;
        }

        public override decimal CalcularArea()
        {
            return ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
        }

        public override decimal CalcularPerimetro()
        {
            return _lado * 3;
        }
    }
    public class Rectangulo : FormaGeometrica
    {
        private readonly decimal _primerLado;
        private readonly decimal _segundoLado;

        public Rectangulo(decimal primerLado, decimal segundoLado)
        {
            _primerLado = primerLado;
            _segundoLado = segundoLado;
        }

        public override decimal CalcularArea()
        {
            return _primerLado * _segundoLado;
        }

        public override decimal CalcularPerimetro()
        {
            return ((_primerLado * 2)  + (_segundoLado * 2));
        }
    }
}
