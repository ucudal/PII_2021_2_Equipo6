using NUnit.Framework;
using ClassLibrary;

namespace Tests
{
    /// <summary>
    /// Clase de test que se encarga de probar las distintas funciones del PublicarHandler.
    /// Los test individualmente utilizando "run test" funcionan correctamente, pero al intentar usar "run all tests" no detecta ninguno.
    /// </summary>
    public class PublicarHandlerTests
    {
        Residuo Residuo;
        PublicarHandler Handler;
        InvitarHandler Handler2;
        string Message;
        Empresa Empresa;
        Empresario Usuario;
        Administrador Usuario2;
        Ubicacion Ubicacion;
        int Id;
        ListaEmpresarios Empresarios = ListaEmpresarios.GetInstance();
        ListaAdministradores Administradores = ListaAdministradores.GetInstance();
        ListaUsuarios Usuarios = ListaUsuarios.GetInstance();
        Mercado Mercado = Mercado.GetInstance();

        /// <summary>
        /// el set up de los test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            Residuo = new Residuo("metal", 100, "kg", 250, "$");
            Handler = new PublicarHandler(null);
            
            int invitacion = InvitationGenerator.Generate();
            Ubicacion = new Ubicacion("Av. 8 de Octubre 2738");
            Empresa = new Empresa("MercadoPrivado", Ubicacion, "099679938");
            Empresa.Residuos.AddResiduo(Residuo);
            Usuario = new Empresario(invitacion, Empresa);
            Id = 12345678;
            Usuario.Id = Id;
            Empresarios.AddEmpresario(Usuario);

            Handler2 = new InvitarHandler(null);
            int invitacion2 = InvitationGenerator.Generate();
            Usuario2 = new Administrador(invitacion2);
            Usuario2.Id = Id;
            Administradores.AddAdministrador(Usuario2);
        }

        /// <summary>
        /// Este test se encarga de comprobar que funciona el comando /publicar.
        /// </summary>
        [Test]
        public void PublicarCanHandleTest()
        {
            Message = Handler.Keywords[0];
            string response;

            IHandler result = Handler.Handle(Message, Id, out response);

            Assert.That(response, Is.EqualTo("Ingrese el numero de la palabra clave que quiera agregar:\n0. Barato.\n1. Envio Gratis.\n2. Usado.\n3. Nuevo.\n"));
        }

        /// <summary>
        /// Este test se encarga de comprobar que el comando /publicar no funciona con un usuario que no es un empresario.
        /// </summary>
        [Test]
        public void PublicarCantHandleTest()
        {
            Emprendedor emprendedor = new Emprendedor(34314458);
            Message = Handler.Keywords[0];
            string response;

            IHandler result = Handler.Handle(Message, emprendedor.Id, out response);

            Assert.That(response, Is.EqualTo("Usted no es un empresario, no puede usar el codigo..."));
        }

        /// <summary>
        /// Este test se encarga de comprobar la funcionalidad de crear una publicación.
        /// </summary>
        [Test]
        public void WorkingPublicarHandlerTest()
        {
            Emprendedor emprendedor = new Emprendedor(34314458);
            Message = Handler.Keywords[0];
            string response;

            IHandler result = Handler.Handle(Message, Id, out response);
            Assert.That(response, Is.EqualTo("Ingrese el numero de la palabra clave que quiera agregar:\n0. Barato.\n1. Envio Gratis.\n2. Usado.\n3. Nuevo.\n"));

            Message = "1";
            Handler.Handle(Message, emprendedor.Id, out response);
            Assert.That(response, Is.EqualTo("Porfavor ingrese la habilitacion para los residuos."));

            Message = "Necesitara un camion o vehiculo";
            Handler.Handle(Message, emprendedor.Id, out response);
            Assert.That(response, Is.EqualTo("Porfavor responda si o no, ¿Estos residuos que se generaron se generan de forma constante? Si fue puntual responda no."));

            Message = "si";
            Handler.Handle(Message, emprendedor.Id, out response);
            Assert.That(response, Is.EqualTo("Porfavor ingrese la direccion de los residuos."));

            Message = Ubicacion.Direccion;
            Handler.Handle(Message, emprendedor.Id, out response);
            Assert.That(response, Is.EqualTo("Ahora dime sobre cual de tus residuos quieres publicar"));

            Message = Residuo.Tipo;
            Handler.Handle(Message, Id, out response);
            Assert.That(response, Is.EqualTo($"Se ha publicado la oferta de {Residuo.Tipo} de la empresa {Empresa.Nombre}. En la ubicacion {Ubicacion.Direccion}"));
        }
    }
}