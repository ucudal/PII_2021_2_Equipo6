using System.Collections.Generic;
namespace ClassLibrary
{
    /// <summary>
    /// Lista residuos es un structurer de residuo que posee dos metodos AddResiudo y removeresiduo
    /// para añadir o remover elementos de una property de la clase llamada ListaResiudo, es el encargado
    /// de llevar a cabo dichas tareas porque es el experto en conocer los residuos.
    /// </summary>
    public static class ListaResiduos
    {
        public static List<Residuo> listaResiduos = new List<Residuo>();

        /// <summary>
        /// AddResiduo es un metodo que se encarga de agregar residuos a la lista.
        /// </summary>
        /// <param name="residuo"></param>
        public static void AddResiduo(Residuo residuo)
        {
            listaResiduos.Add(residuo);
        }

        /// <summary>
        /// RemoveResiduo es un metodo que se encarga de eliminar residuos de la lista.
        /// </summary>
        /// <param name="residuo"></param>
        public static void RemoveResiduo(Residuo residuo)
        {
            listaResiduos.Remove(residuo);
        }
    }
}