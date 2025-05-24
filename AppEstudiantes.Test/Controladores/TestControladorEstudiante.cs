using AppEstudiantes.Controladores;
using AppEstudiantes.Modelos;
using AppEstudiantes.Servicios;
using Moq;

namespace AppEstudiantes.Test.Controladores
{
    public class TestControladorEstudiante
    {
        [Fact]
        public void ObtenerEstado_DeberiaRetornarAprobado_ConMock()
        {
            var estudiante = new Estudiante { CI = 41924628, Nombre = "Maria", Nota = 90 };

            var servicioMock = new Mock<IServicioEstudiante>();
            servicioMock.Setup(s => s.EstaAprobado(estudiante.CI)).Returns(true);

            var controlador = new ControladorEstudiante(servicioMock.Object);
            var resultado = controlador.ObtenerEstado(estudiante.CI);

            Assert.Equal("Aprobado", resultado);
        }

        [Fact]
        public void ObtenerEstado_DeberiaRetornarReprobado_ConMock()
        {
            var estudiante = new Estudiante { CI = 41928418, Nombre = "Pedro", Nota = 20 };

            var servicioMock = new Mock<IServicioEstudiante>();
            servicioMock.Setup(s => s.EstaAprobado(estudiante.CI)).Returns(false);

            var controlador = new ControladorEstudiante(servicioMock.Object);
            var resultado = controlador.ObtenerEstado(estudiante.CI);

            Assert.Equal("Reprobado", resultado);
        }
    }
}