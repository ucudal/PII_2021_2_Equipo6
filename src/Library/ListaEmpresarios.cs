using System.Collections.Generic;
namespace ClassLibrary
{
    /// <summary>
    /// ListaEmpresarios es el experto en conocer a los empresarios, y 
    /// por el patron Expert este tambien es quien
    /// posee la responsabilidad de agregar Empresarios y/o remover Empresarios.
    /// </summary>
    public static class ListaEmpresarios
    {
        /// <summary>
        /// Variable estatica empresarios, porque es una lista de instancias de Empresario
        /// que lleva un registro de todos los empresarios que hay.
        /// </summary>
        /// <returns></returns>
        public static List<Empresario> empresarios{get; set;} = new List<Empresario>();

        /// <summary>
        /// Metodo que agrega un empresario a la lista de empresarios, desginado a esta clase por Expert.
        /// </summary>
        /// <param name="empresario"></param>
        public static Empresario AddEmpresario(int invitacion, Empresa empresa, int id)
        {
            Empresario empresario = new Empresario(invitacion, empresa, id);
            empresarios.Add(empresario);
            return empresario;
        }

        /// <summary>
        /// Metodo que remove un empresario a la lista de empresarios, desginado a esta clase por Expert.
        /// </summary>
        /// <param name="empresario"></param>
        public static void RemoveEmpresario(Empresario empresario)
        {
            empresarios.Remove(empresario);
        }
    }
}


