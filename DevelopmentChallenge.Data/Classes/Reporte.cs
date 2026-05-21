using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data.Classes
{
    public class ReporteService
    {
        private readonly ITraductor _traductor;
        private const string IdiomaDefault = "Ingles";

        public ReporteService(ITraductor traductor)
        {
            _traductor = traductor ?? throw new ArgumentNullException(nameof(traductor));
        }

        public string Imprimir(List<FormaGeometrica> formas, int idioma)
        {
            var idiomasConfigurados = _traductor.ObtenerIdiomas();
            var idiomaSeleccionado = idiomasConfigurados.ElementAtOrDefault(idioma) ?? IdiomaDefault;
            return ImprimirConIdioma(formas, idiomaSeleccionado);
        }

        private string ImprimirConIdioma(List<FormaGeometrica> formas, string idioma)
        {
            var sb = new StringBuilder();

            if (!formas.Any())
            {
                sb.Append($"<h1>{_traductor.Traducir("reporte_vacio", idioma)}</h1>");
            }
            else
            {
                sb.Append($"<h1>{_traductor.Traducir("reporte_titulo", idioma)}</h1>");

                var resumen = formas
                    .GroupBy(f => f.GetType())
                    .Select(grupo => new
                    {
                        Tipo = grupo.Key.Name,
                        Cantidad = grupo.Count(),
                        Area = grupo.Sum(f => f.CalcularArea()),
                        Perimetro = grupo.Sum(f => f.CalcularPerimetro())
                    });

                foreach (var item in resumen)
                {
                    sb.Append(ObtenerLinea(item.Cantidad, item.Area, item.Perimetro, item.Tipo, idioma));
                }

                sb.Append($"{_traductor.Traducir("total", idioma)}<br/>");
                sb.Append(formas.Count + " " + _traductor.Traducir("formas", idioma) + " ");
                sb.Append(_traductor.Traducir("perimetro", idioma) + " " + formas.Sum(f => f.CalcularPerimetro()).ToString("#.##") + " ");
                sb.Append($"{_traductor.Traducir("area", idioma)} " + formas.Sum(f => f.CalcularArea()).ToString("#.##"));
            }

            return sb.ToString();
        }

        private string ObtenerLinea(int cantidad, decimal area, decimal perimetro, string tipo, string idioma)
        {
            if (cantidad > 0)
            {
                var tipoTraducido = TraducirForma(tipo, cantidad, idioma);
                return $"{cantidad} {tipoTraducido} | {_traductor.Traducir("area", idioma)} {area:#.##} | {_traductor.Traducir("perimetro", idioma)} {perimetro:#.##} <br/>";
            }

            return string.Empty;
        }

        private string TraducirForma(string tipo, int cantidad, string idioma)
        {
            var clave = tipo.ToLower() + (cantidad == 1 ? "_singular" : "_plural");
            return _traductor.Traducir(clave, idioma);
        }
    }

    public static class Reporte
    {
        private static readonly ReporteService _reporteService = new ReporteService(new Traductor());

        public static string Imprimir(List<FormaGeometrica> formas, int idioma)
        {
            return _reporteService.Imprimir(formas, idioma);
        }
    }
}
