using System;

namespace DevelopmentChallenge.Data.Helper
{
    public static class IdiomaHelper
    {
        public static string ObtenerNombreDeArchivoDeRecursos(Idioma idioma)
        {
            switch (idioma)
            {
                case Idioma.Castellano: return "DevelopmentChallenge.Data.Resources-es";
                case Idioma.Ingles: return "DevelopmentChallenge.Data.Resources-us";
                case Idioma.Italiano: return "DevelopmentChallenge.Data.Resources-it";
                default:
                    throw new ArgumentOutOfRangeException(@"Idioma no implementado");
            }
        }
    }
}
