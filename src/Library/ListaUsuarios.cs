using System.Collections.Generic;
namespace ClassLibrary
{
    /// <summary>
    /// ListaUsuario es el experto en conocer a todos los usuarios, y 
    /// por el patron Expert este tambien es quien
    /// posee la responsabilidad de agregar y/o remover Usuarios.
    /// A su vez depende de IUsuario para agregar cualquier tipo de usuario (emprendedor,
    /// administrador o usuarios).
    /// </summary>
    public static class ListaUsuarios
    {
        /// <summary>
        /// Variable estatica Usuarios, porque es una lista de instancias de Usuarios
        /// que lleva un registro de todos las usuarios que hay.
        /// </summary>
        /// <returns></returns>
        public static List<IUsuario> usuarios{get;set;} = new List<IUsuario>();
        /// <summary>
        /// AddUsuarios es el encargado de agregar usuarios a la lista.
        /// </summary>
        /// <param name="usuario"></param>
        public static Emprendedor AddUsuario(int id)
        {
            Emprendedor usuario = new Emprendedor(id);
            usuarios.Add(usuario);
            return usuario;
        }

        /// <summary>
        /// RemoveUsuario es el encargado de remover usuarios de la lista.
        /// </summary>
        /// <param name="usuario"></param>
        public static void RemoveUsuario(IUsuario usuario)
        {
            usuarios.Remove(usuario);
        }
    }
}