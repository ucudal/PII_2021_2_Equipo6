using System.Collections.Generic;
namespace ClassLibrary
{
    /// <summary>
    /// Lista residuos es un structurer de residuo que posee dos metodos AddResiduo y removeresiduo
    /// para añadir o remover elementos de una property de la clase llamada ListaResiduo, es el encargado
    /// de llevar a cabo dichas tareas porque es el experto en conocer los residuos.
    /// </summary>
    public class ListaResiduos
    {
        /// <summary>
        /// Property int residuo, es una lista de instancias de Residuo
        /// que lleva el registro de los residuos de una empresa.
        /// </summary>
        /// <returns></returns>
        public List<Residuo> listaResiduos = new List<Residuo>();

        /// <summary>
        /// AddResiduo es un metodo que se encarga de agregar residuos a la lista.
        /// </summary>
        /// <param name="residuo"></param>
        public Residuo AddResiduo(string tipo, int cantidad, string unidad, int costo, string moneda)
        {
            Residuo residuo = new Residuo(tipo, cantidad, unidad, costo, moneda);
            listaResiduos.Add(residuo);
            return residuo;
        }

        /// <summary>
        /// RemoveResiduo es un metodo que se encarga de eliminar residuos de la lista.
        /// </summary>
        /// <param name="residuo"></param>
        public void RemoveResiduo(Residuo residuo)
        {
            listaResiduos.Remove(residuo);
        }
    }
}