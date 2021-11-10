using System;

namespace ClassLibrary
{
    /// <summary>
    /// Publicacion es una clase que conoce la informacion de empresa, residuo, la fecha
    /// y ubicacion de una publicacion hecha por una X empresa.
    /// </summary>
    public class Publicacion
    {
        /// <summary>
        /// Property empresa, es la empresa que crea la publicacion.
        /// </summary>
        /// <value></value>
        public Empresa empresa{ get; set; }

        /// <summary>
        /// Property habilitación, es la habilitación que se le pide a la empresa.
        /// </summary>
        /// <value></value>
        public string habilitacion { get; set; }

        /// <summary>
        /// Property residuo, es el residuo que se esta ofertando en la publicacion.
        /// </summary>
        /// <value></value>
        public Residuo residuo{ get; set; }

        /// <summary>
        /// Property ubicacion, es la ubicacion de donde se encuentran los residuos de la oferta.
        /// </summary>
        /// <value></value>
        public Ubicacion ubicacion{ get; set; }

        /// <summary>
        /// Property constante, indica si un residuo es constante o no.
        /// </summary>
        /// <value></value>

        public bool constante { get; set; }

        public int usuarioEntregado { get; set; }

        /// <summary>
        /// Property palabraClave, es una palabra clave que pudo haber sido agregada por un empresario al crear la publicacion.
        /// </summary>
        /// <value></value>
        public string palabraClave { get; set; }

        /// <summary>
        /// Fecha en la que fue creada la publicacion.
        /// </summary>
        /// <value></value>
        public DateTime fecha { get; set; }

        /// <summary>
        /// Property que indica si los residuos de una publicacion ya fueron o no entregados.
        /// </summary>
        /// <value></value>
        public bool entregado { get; set; } = false;

        /// <summary>
        /// Constructor de una instancia de Publicacion.
        /// </summary>
        public Publicacion(Residuo residuo, Ubicacion ubicacion, Empresa empresa, string habilitacion, bool constante)
        {
            this.constante = constante;
            this.residuo = residuo;
            this.ubicacion = ubicacion;
            this.empresa = empresa;
            this.fecha = DateTime.Now;
        }

        /// <summary>
        /// Método que se encarga de agregar palabras clave a la publicación
        /// </summary>
        /// <param name="PalabraClave"></param>
        public void AgregarPalabraClave(string PalabraClave)
        {
            this.palabraClave = PalabraClave;
        }
    
        public void AgregarUsuarioEntregado(int id)
        {

        }
    }
}