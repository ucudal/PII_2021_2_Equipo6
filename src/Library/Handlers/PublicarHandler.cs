using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "distancia".
    /// </summary>
    public class PublicarHandler : BaseHandler
    {
        /// <summary>
        /// El estado del comando.
        /// </summary>
        public PublicarState State { get; private set; }

        /// <summary>
        /// Los datos que va obteniendo el comando en los diferentes estados.
        /// </summary>
        public Ubicacion UbicacionData { get; private set; }
        public ListaPalabrasClave clave { get; private set; }
        public string residuoTipo { get; private set; }
        public Residuo ResiduoElegido { get; private set; }
        public string PalabraClave { get; private set; }
        public Publicacion result { get; private set; }
        public Empresa empresaUsuario { get; private set; }
        public string habilitacionData { get; private set; }
        public bool Constante { get; private set; }

        public PublicarHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/publicar" };
        }


        /// <summary>
        /// Procesa todos los mensajes y retorna true siempre.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado indicando que el mensaje no pudo se procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(string message, int id, out string response)
        {
            bool realEmpresario = false;
            foreach(Empresario empresario in ListaEmpresarios.empresarios)
            {
                if(empresario.id == id)
                {
                    this.empresaUsuario = empresario.empresa;
                    realEmpresario = true;
                }
            }
            if(realEmpresario == true && State ==  PublicarState.Start && message == "/publicar")
            {
                // En el estado Start le pide la dirección de origen y pasa al estado FromAddressPrompt
                ListaPalabrasClave claves = new ListaPalabrasClave();
                int contador = 0;
                this.State = PublicarState.PalabrasClavePrompt;
                string unfinishedResponse = "Ingrese el numero de la palabra clave que quiera agregar:\n";
                foreach(string palabra in ListaPalabrasClave.palabras)
                {
                    unfinishedResponse += $"{contador}. {palabra}.\n";
                    contador += 1;
                }
                response = unfinishedResponse;
                return true;
            }
            else if (State == PublicarState.PalabrasClavePrompt)
            {
                this.PalabraClave = ListaPalabrasClave.palabras[(Convert.ToInt32(message))];
                this.State = PublicarState.HabilitacionPrompt;
                response = "Porfavor ingrese la habilitacion para los residuos.";
                return true;
            }
            else if (State == PublicarState.HabilitacionPrompt)
            {
                this.habilitacionData = message;
                this.State = PublicarState.UbicacionPrompt;
                response = "Porfavor responda si o no, ¿Estos residuos que se generaron se generan de forma constante? Si fue puntual responda no.";
                return true;
            }
            else if (State == PublicarState.ConstantePrompt)
            {
                if(message == "si")
                {
                    this.Constante = true;
                }
                else if(message == "no")
                {
                    this.Constante = false;
                }
                this.State = PublicarState.UbicacionPrompt;
                response = "Porfavor ingrese la direccion de los residuos.";
                return true;
            }
            else if (State == PublicarState.UbicacionPrompt)
            {
                // En el estado FromAddressPrompt el mensaje recibido es la respuesta con la dirección de origen
                this.UbicacionData = new Ubicacion(message);
                this.State = PublicarState.ResiduoPrompt;
                response = "Ahora dime sobre cual de tus residuos quieres publicar";
                return true;
            }
            else if (State == PublicarState.ResiduoPrompt)
            {
                this.residuoTipo = message;
                foreach(Residuo residuo in this.empresaUsuario.residuos.listaResiduos)
                {
                    if(residuo.tipo == residuoTipo)
                    {
                        this.ResiduoElegido = residuo;
                    }
                }
                this.result = new Publicacion(this.ResiduoElegido, this.UbicacionData, this.empresaUsuario, this.habilitacionData, this.Constante);
                if(this.ResiduoElegido != null && this.result != null)
                {
                    response = $"Se ha publicado la oferta de {this.result.residuo.tipo} de la empresa {this.result.empresa.nombre}. En la ubicacion {this.result.ubicacion.direccion}";
                    this.State = PublicarState.Start;
                }
                else
                {
                    // Si no encuentra alguna de las direcciones se las pide de nuevo y vuelve al estado FromAddressPrompt.
                    // Una versión más sofisticada podría determinar cuál de las dos direcciones no existe y volver al
                    // estado en el que se pide la dirección que falta.
                    response = "No se ha podido hacer crear la publicacion, vuelva a intentarlo.";
                    this.State = PublicarState.Start;
                }

                return true;
            }
            else if (realEmpresario == false)
            {
                // En los estados FromAddressPrompt o ToAddressPrompt si no hay un buscador de direcciones hay que
                // responder que hubo un error y volver al estado inicial.
                response = "Usted no es un empresario, no puede usar el codigo...";

                return false;
            }
            else
            {
                response = string.Empty;
                return false;
            }
        }

        /// <summary>
        /// Retorna este "handler" al estado inicial.
        /// </summary>
        protected override void InternalCancel()
        {
            this.State = PublicarState.Start;
            this.UbicacionData = null;
            this.residuoTipo = null;
            this.ResiduoElegido = null;
            this.empresaUsuario = null;
        }

        /// <summary>
        /// Indica los diferentes estados que puede tener el comando DistanceHandler.
        /// - Start: El estado inicial del comando. En este estado el comando pide la dirección de origen y pasa al
        /// siguiente estado.
        /// - FromAddressPrompt: Luego de pedir la dirección de origen. En este estado el comando pide la dirección de
        /// destino y pasa al siguiente estado.
        /// - ToAddressPrompt: Luego de pedir la dirección de destino. En este estado el comando calcula la distancia
        /// y vuelve al estado Start.
        /// </summary>
        public enum PublicarState
        {
            Start,
            PalabrasClavePrompt,
            HabilitacionPrompt,
            ConstantePrompt,
            UbicacionPrompt,
            ResiduoPrompt
        }
    }
}