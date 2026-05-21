using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace DevelopmentChallenge.Data.Classes
{
    public class Traductor : ITraductor
    {
        private static Dictionary<string, Dictionary<string, string>> _diccionario;
        private static readonly object _lock = new object();
        private static bool _cargado = false;

        private static void CargarDiccionario()
        {
            if (_cargado) return;
            lock (_lock)
            {
                if (_cargado) return;
                var ruta = ResolverRutaDiccionario();
                if (!File.Exists(ruta))
                    throw new FileNotFoundException($"No se encontró el archivo de idiomas en {ruta}");
                var json = File.ReadAllText(ruta);
                _diccionario = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(json);
                _cargado = true;
            }
        }

        private static string ResolverRutaDiccionario()
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            var assemblyDir = Path.GetDirectoryName(typeof(Traductor).Assembly.Location) ?? baseDir;

            var candidatos = new[]
            {
                Path.Combine(baseDir, "Resources", "idiomas.json"),
                Path.Combine(baseDir, "idiomas.json"),
                Path.Combine(assemblyDir, "Resources", "idiomas.json"),
                Path.Combine(assemblyDir, "idiomas.json")
            }
            .Select(Path.GetFullPath)
            .Distinct()
            .ToList();

            var dir = new DirectoryInfo(baseDir);
            while (dir != null)
            {
                candidatos.Add(Path.GetFullPath(Path.Combine(dir.FullName, "DevelopmentChallenge.Data", "Resources", "idiomas.json")));
                candidatos.Add(Path.GetFullPath(Path.Combine(dir.FullName, "Source", "DevelopmentChallenge.Data", "Resources", "idiomas.json")));
                dir = dir.Parent;
            }

            foreach (var candidato in candidatos.Distinct())
            {
                if (File.Exists(candidato))
                {
                    return candidato;
                }
            }

            return Path.GetFullPath(Path.Combine(baseDir, "Resources", "idiomas.json"));
        }

        public string Traducir(string key, string idioma)
        {
            CargarDiccionario();
            if (_diccionario.TryGetValue(idioma, out var traducciones))
            {
                if (traducciones.TryGetValue(key, out var valor))
                    return valor;
            }
            return key;
        }

        public string[] ObtenerIdiomas()
        {
            CargarDiccionario();
            return _diccionario.Keys.ToArray();
        }
    }
}