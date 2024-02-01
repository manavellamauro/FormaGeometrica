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

/*
 * OBSERVACIONES
 * Se mantiene la firma del método public static string Imprimir(List<FormaGeometrica> formas, int idioma). No sé si era parte de la consigna pero por compatibilidad decidí mantenerla.
 * Se crea la carpeta Helpers donde guardamos una Enum de idiomas, constantes y métodos que nos ayudan a tener el código mas ordenado.
 * Si se quiere agregar una nueva forma geométrica se debe crear la clase y hacerla heredar de FormaGeométrica
 * Si se quiere agregar un nuevo idioma se debe crear un nuevo archivo de recursos para dicho idioma y agregarlo a la Enum de idiomas.
 * 
 */

using DevelopmentChallenge.Data.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;

namespace DevelopmentChallenge.Data.Classes
{
    public abstract class FormaGeometrica
    {
        public static string Imprimir(List<FormaGeometrica> formas, int idioma)
        {
            ResourceManager resourceManager = new ResourceManager(IdiomaHelper.ObtenerNombreDeArchivoDeRecursos((Idioma)idioma), Assembly.GetExecutingAssembly());

            var sb = new StringBuilder();

            if (!formas.Any())
                sb.Append(resourceManager.GetString(Constantes.LISTA_VACIA_DE_FORMAS));
            else
            {
                int cantidadTotal = 0;
                double areaTotal = 0, perimetroTotal = 0;

                sb.Append(resourceManager.GetString(Constantes.TITULO));

                var tiposFormasGeometricas = Assembly.GetExecutingAssembly().GetTypes().Where(type => type.IsClass && !type.IsAbstract && type.IsSubclassOf(typeof(FormaGeometrica)));

                foreach (var tipo in tiposFormasGeometricas)
                {
                    int cantidad = formas.Where(x => x.GetType() == tipo).Count();
                    double area = formas.Where(x => x.GetType() == tipo).Sum(x => x.CalcularArea());
                    double perimetro = formas.Where(x => x.GetType() == tipo).Sum(x => x.CalcularPerimetro());

                    if (cantidad > 0)
                    {
                        cantidadTotal += cantidad;
                        areaTotal += area;
                        perimetroTotal += perimetro;
                        var tipoStr = cantidad > 1 ? resourceManager.GetString($"{tipo.Name}EnPlural") : resourceManager.GetString($"{tipo.Name}EnSingular");
                        sb.Append($"{cantidad} {tipoStr} | {resourceManager.GetString(Constantes.AREA)} {area:#.##} | {resourceManager.GetString(Constantes.PERIMETRO)} {perimetro:#.##} <br/>");
                    }
                }

                // FOOTER
                sb.Append(resourceManager.GetString(Constantes.TOTAL));
                sb.Append($"{cantidadTotal} {resourceManager.GetString(Constantes.FORMAS)} ");
                sb.Append($"{resourceManager.GetString(Constantes.PERIMETRO)} {perimetroTotal.ToString("#.##")} ");
                sb.Append($"{resourceManager.GetString(Constantes.AREA)} {areaTotal.ToString("#.##")}");
            }

            return sb.ToString();
        }

        public abstract double CalcularArea();
        public abstract double CalcularPerimetro();
    }
}
