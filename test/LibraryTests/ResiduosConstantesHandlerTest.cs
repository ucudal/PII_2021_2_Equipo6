using NUnit.Framework;
using ClassLibrary;

namespace Tests
{
    /// <summary>
    /// Clase de test que se encarga de probar las distintas funciones del ResiduosConstantesHandler.
    /// Los test individualmente utilizando "run test" funcionan correctamente, pero al intentar usar "run all tests" no detecta ninguno.
    /// </summary>
    public class ResiduosConstantesTests
    {
        Residuo Residuo;
        ResiduosConstantesHandler Handler;
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
        Publicacion Publicacion;

        /// <summary>
        /// El Setup de los test
        /// </summary>
        [SetUp]
        public void Setup()
        {
            Residuo = new Residuo("Metal", 100, "kg", 250, "$");
            Handler = new ResiduosConstantesHandler(null);

            InvitationGenerator generator = new InvitationGenerator();
            
            string invitacion = ListaInvitaciones.GetInstance(generator).AddInvitacion();
            Ubicacion = new Ubicacion("Av. 8 de Octubre 2738");
            Empresa = new Empresa("MercadoPrivado", Ubicacion, "099679938");
            Empresa.Residuos.AddResiduo(Residuo);
            Usuario = new Empresario(invitacion, Empresa);
            Id = 12345678;
            Usuario.Id = Id;
            Empresarios.AddEmpresario(Usuario);
            string invitacion2 = ListaInvitaciones.GetInstance(generator).AddInvitacion();
            Usuario2 = new Administrador(invitacion2);
            Usuario2.Id = Id;
            Administradores.AddAdministrador(Usuario2);
            Publicacion = new Publicacion(Residuo, Ubicacion, Empresa, "Tener un camion", true);
            Mercado.AddMercado(Publicacion);
        }

        /// <summary>
        /// Este test se encarga de comprobar que funciona el comando /residuosconstantes.
        /// </summary>
        [Test]
        public void ResiduosConstantesCanHandle()
        {
            Message = Handler.Keywords[0];
            string response;

            IHandler result = Handler.Handle(Message, Id, out response);

            Assert.That(response, Is.EqualTo("Estos son los residuos constantes:\nMetal"));
            Assert.That(Publicacion.Constante, Is.EqualTo(true));
        }
        
        /// <summary>
        /// Este test se encarga de comprobar que el handler no responde nada si se utiliza 
        /// un comando distinto de /residuosconstantes.
        /// </summary>
        [Test]
        public void ResiduosConstantesCantHandle()
        {
            Emprendedor emprendedor = new Emprendedor(34314458);
            Message = "/residuospuntuales";
            string response;

            IHandler result = Handler.Handle(Message, emprendedor.Id, out response);

            Assert.That(response, Is.EqualTo(""));
        }
    }
}