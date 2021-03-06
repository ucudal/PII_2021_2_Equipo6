using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// Lista publicaciones es un structurer de publicación que posee dos metodos AddPublicacion y removePublicacion
    /// para añadir o remover elementos de una property de la clase llamada ListaPublicaciones, es el encargado
    /// de llevar a cabo dichas tareas porque es el experto en conocer los residuos.
    /// </summary>
    public class ListaPublicaciones : IJsonConvertible
    {
        /// <summary>
        /// Constructor de la clase ListaPublicaciones vacio intencionalmente.
        /// </summary>
        [JsonConstructor]
        public ListaPublicaciones()
        {
        }
        
        /// <summary>
        /// Property publicación, es una lista de instancias de Publicacion
        /// que lleva el registro de las publicaciones de una empresa.
        /// </summary>
        /// <returns></returns>
        [JsonInclude]
        public List<Publicacion> Publicaciones = new List<Publicacion>();

        /// <summary>
        /// AddPublicacion es un metodo que se encarga de agregar publicaciones a la lista
        /// </summary>
        /// <param name="publicacion"></param>
        public void AddPublicacion(Publicacion publicacion)
        {
            Publicaciones.Add(publicacion);
        }

        //[JsonInclude]
        //public IList<Publicacion> Steps { get; private set; } = new List<Publicacion>();

        /// <summary>
        /// RemovePublicacion es un metodo que se encarga de eliminar publicaciones de la lista.
        /// </summary>
        /// <param name="publicacion"></param>
        public void RemovePublicacion(Publicacion publicacion)
        {
            Publicaciones.Remove(publicacion);
        }

        /// <summary>
        /// Sirve para serializar la clase y todas sus property.
        /// </summary>
        /// <returns></returns>
        public string ConvertToJson()
        {
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = MyReferenceHandler.Instance,
                WriteIndented = true
            };

            return JsonSerializer.Serialize(this, options);
        }

        /// <summary>
        /// Sirve para deserializar un string de json para asi 
        /// asignarle una nueva clase ListaEmpresarios los valores 
        /// previos a ponerle un stop al program para asi mantener la información.
        /// </summary>
        /// <param name="json"></param>
        public void LoadFromJson(string json)
        {
            ListaPublicaciones deserialized = JsonSerializer.Deserialize<ListaPublicaciones>(json);
            this.Publicaciones = deserialized.Publicaciones;
        }

    }
}