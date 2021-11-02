namespace ClassLibrary
{
    /// <summary>
    /// Clase Administrador del tipo IUsuario, posee, ademas de las property id, name e invitacion de toda clase 
    /// usuario, una property empresa que indica la empresa de la que participa el Empresario.
    /// </summary>
    public class Administrador : IUsuario
    {
        /// <summary>
        /// Property nombre, es el encargado de conocer el nombre del administrador.
        /// </summary>
        /// <value></value>
        public string nombre{get; set;}
        /// <summary>
        /// Property id, es el encargado de conocer el numero entero del id del administrador.
        /// </summary>
        /// <value></value>
        public int id{get; set;}
        /// <summary>
        /// Property invitacion, es el encargado de conocer el numero entero de la invitacion del 
        /// adminitrador.
        /// </summary>
        /// <value></value>
        public int invitacion{get; set;}
        /// <summary>
        /// Constructor de una instancia de administrador. 
        /// </summary>
        /// <param name="invitacion"></param>
        /// <param name="nombre"></param>

        public Administrador(int invitacion, string nombre)
        {
            this.invitacion = invitacion;
            this.nombre = nombre;
        }
    }
}