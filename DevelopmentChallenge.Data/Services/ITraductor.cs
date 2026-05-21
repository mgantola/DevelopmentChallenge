namespace DevelopmentChallenge.Data.Classes
{
    public interface ITraductor
    {
        string Traducir(string key, string idioma);
        string[] ObtenerIdiomas();
    }
}