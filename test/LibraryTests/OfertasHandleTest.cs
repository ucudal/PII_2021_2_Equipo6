using NUnit.Framework;
using ClassLibrary;

namespace Tests
{
    public class OfertasHandlerTests
    {
        Residuo residuo;
        OfertasHandler handler;
        string message;
        Empresa empresa;
        Empresario UsuarioEmpresario;
        Emprendedor UsuarioEmprendedor;
        Ubicacion ubicacion;
        int id;
        int contador;
        Publicacion publicacion;
        Ubicacion ubicacion2;

        int id2;

        [SetUp]
        public void Setup()
        {
            residuo = new Residuo("metal", 100, "kg", 250, "$");
            handler = new OfertasHandler(null);
            int invitacion = InvitationGenerator.Generate();
            ubicacion = new Ubicacion("Av. 8 de Octubre 2738");
            ubicacion2 = new Ubicacion("Av. Italia 3479");
            empresa = new Empresa("MercadoPrivado", ubicacion, 099679938);
            empresa.residuos.AddResiduo(residuo);
            UsuarioEmpresario = new Empresario(invitacion, empresa);
            UsuarioEmprendedor = new Emprendedor(id);
            id = 12345678;
            id2 = 87654321;
            UsuarioEmprendedor.id = id;
            UsuarioEmpresario.id = id2;
            ListaEmpresarios.AddEmpresario(UsuarioEmpresario);
            ListaUsuarios.AddUsuario(UsuarioEmprendedor);
            contador = 0;
            publicacion = new Publicacion(residuo, ubicacion2, empresa, "tener un camion");
            Mercado.AddMercado(publicacion);
        }

        [Test]
        public void OfertasCanHandle()
        {
            message = handler.Keywords[0];
            string response;

            IHandler result = handler.Handle(message, id, out response);

            Assert.That(response, Is.EqualTo("¿Quieres realizar tu busqueda usando una palabra clave? Responda si o no"));
        }

        [Test]
        public void OfertasEmpresarioCanHandle()
        {
            message = handler.Keywords[0];
            string response;

            IHandler result = handler.Handle(message, UsuarioEmpresario.id, out response);

            Assert.That(response, Is.EqualTo("¿Quieres realizar tu busqueda usando una palabra clave? Responda si o no"));
        }

        [Test]
        public void OfertasEnOfertasHandler()
        {
            message = handler.Keywords[0];
            string response;

            IHandler result = handler.Handle(message, id, out response);
            
            Assert.That(response, Is.EqualTo("¿Quieres realizar tu busqueda usando una palabra clave? Responda si o no"));
            message = "si";
            handler.Handle(message, UsuarioEmprendedor.id, out response);
            Assert.That(response, Is.EqualTo("Ingrese el numero de la palabra clave que buscar:\n0. Barato.\n1. Envio Gratis.\n2. Usado.\n3. Nuevo.\n"));
            message = "1";
            handler.Handle(message, UsuarioEmprendedor.id, out response);
            Assert.That(response, Is.EqualTo("¿Cual es tu direccion? (Asi encontraremos publicaciones por proximidad)"));
            message = ubicacion2.direccion;
            handler.Handle(message, UsuarioEmprendedor.id, out response);
            Assert.That(response, Is.EqualTo("Ahora dime que tipo de residuos estas buscando?"));
            message = residuo.tipo;
            handler.Handle(message, UsuarioEmprendedor.id, out response);
            Assert.That(response, Is.EqualTo($"Ingrese el número de la publicación para ver más información de la misma:\n0. {publicacion.empresa.nombre} ofrece: {publicacion.residuo.cantidad} {publicacion.residuo.unidad} de {publicacion.residuo.tipo} en {publicacion.ubicacion.direccion}. Ademas la habilitacion para conseguir estos residuos es: {publicacion.habilitacion}\n"));
        }
    
    
    }

    









}