using AppEstudiantes.Controladores;
using AppEstudiantes.Test.Stubs;

namespace AppEstudiantes.Test.Controladores
{
    public class TestStubServicioEstudiantes
    {
        [Fact]
        public void ObtenerEstado_DeberiaRetornarAprobado_ConStub()
        {
            var servicioStub = new StubServicioEstudiante(true);

            var controlador = new ControladorEstudiante(servicioStub);
            var resultado = controlador.ObtenerEstado(59816946);

            Assert.NotNull(servicioStub);
            Assert.Equal("Aprobado", resultado);
        }

        [Fact]
        public void ObtenerEstado_DeberiaRetornarReprobado_ConStub()
        {
            var servicioStub = new StubServicioEstudiante(false);

            var controlador = new ControladorEstudiante(servicioStub);
            var resultado = controlador.ObtenerEstado(19261238);

            Assert.NotNull(servicioStub);
            Assert.Equal("Reprobado", resultado);
        }
    }
}