# DevelopmentChallenge

## Resumen de cambios implementados

- Se refactorizó la jerarquía de formas para aplicar polimorfismo:
  - `FormaGeometrica` pasó a ser abstracta.
  - Se crearon implementaciones concretas por forma: `Cuadrado`, `Circulo`, `TrianguloEquilatero` y `Rectangulo`.
- Se extrajo la responsabilidad de traducción a un servicio dedicado:
  - Interfaz `ITraductor`.
  - Implementación `Traductor` que lee recursos desde `Resources/idiomas.json`.
- Se agregó soporte multi-idioma configurable desde JSON:
  - Idiomas actuales: `Castellano`, `Ingles`, `Italiano`.
  - Método `ObtenerIdiomas()` para listar idiomas disponibles.
- Se ajustó el punto de entrada de consola para selección dinámica de idioma:
  - Muestra `indice - idioma`.
  - Permite seleccionar idioma por número.
  - Si el índice no existe, informa y usa idioma por defecto.
- Se agregaron tests unitarios nuevos para cubrir `Traductor`.

## Patrones, prácticas y principios aplicados

- SRP (Single Responsibility Principle):
  - Cálculo geométrico y traducción están en componentes separados.
- OCP (Open/Closed Principle):
  - Nuevas formas se agregan extendiendo `FormaGeometrica`.
  - Nuevos idiomas se agregan en JSON sin cambiar lógica de reporte.
- Polimorfismo:
  - Cada forma implementa su propio cálculo de área y perímetro.
- Inversión de dependencias (DI liviana):
  - `ReporteService` depende de `ITraductor`, no de una implementación concreta.
- Pruebas unitarias:
  - Se mantuvieron pruebas del reporte y se agregaron pruebas específicas del traductor.

## Estructura principal

- `DevelopmentChallenge.Data`: lógica de dominio (formas, reporte, traducción).
- `DevelopmentChallenge.Data.Tests`: pruebas unitarias con NUnit.
- `DevelopmentChallenge.ConsoleApp`: programa principal para ejecutar el reporte por consola.

## Cómo ejecutar el programa principal

### Opción 1: Visual Studio

1. Abrir `DevelopmentChallenge.sln`.
2. Establecer `DevelopmentChallenge.ConsoleApp` como proyecto de inicio.
3. Ejecutar (`F5` o `Ctrl+F5`).
4. Seleccionar el idioma ingresando el índice mostrado en consola.

### Opción 2: Línea de comandos (Developer Command Prompt / PowerShell con MSBuild)

Desde la carpeta `Source`:

```powershell
msbuild DevelopmentChallenge.sln /t:Build /p:Configuration=Debug
.\DevelopmentChallenge.ConsoleApp\bin\Debug\DevelopmentChallenge.ConsoleApp.exe
```

## Cómo ejecutar tests

```powershell
msbuild DevelopmentChallenge.sln /t:Build /p:Configuration=Debug
```

Luego ejecutar los tests desde Visual Studio (Test Explorer) o con el runner de NUnit disponible en tu entorno.
