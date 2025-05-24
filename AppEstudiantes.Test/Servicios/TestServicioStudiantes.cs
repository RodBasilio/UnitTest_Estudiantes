using AppEstudiantes.Modelos;
using AppEstudiantes.Servicios;

namespace AppEstudiantes.Test.Servicios
{
    public class TestServicioEstudiante
    {
        [Fact]
        public void EstudianteConNotaMayorA51_DeberiaAprobar()
        {
            var estudiante = new Estudiante { CI = 17463916, Nombre = "Noa", Nota = 75 };
            var servicio = new ServicioEstudiante();
            servicio.Crear(estudiante);

            var resultado = servicio.EstaAprobado(estudiante.CI);

            Assert.True(resultado);
        }

        [Fact]
        public void EstudianteConNotaMenorA51_DeberiaReprobar()
        {
            var estudiante = new Estudiante { CI = 27023923, Nombre = "Tito", Nota = 40 };
            var servicio = new ServicioEstudiante();
            servicio.Crear(estudiante);

            var resultado = servicio.EstaAprobado(estudiante.CI);

            Assert.False(resultado);
        }

        [Fact]
        public void NombreDelEstudiante_DebeSerCorrecto()
        {
            var servicio = new ServicioEstudiante();
            var estudiante = new Estudiante { CI = 29529374, Nombre = "Cody", Nota = 62 };
            var creado = servicio.Crear(estudiante);

            Assert.Equal("Cody", creado.Nombre);
        }

        [Fact]
        public void CIDelEstudiante_DebeSerCorrecto()
        {
            var servicio = new ServicioEstudiante();
            var estudiante = new Estudiante { CI = 51907415, Nombre = "Rex", Nota = 37 };
            var creado = servicio.Crear(estudiante);

            Assert.Equal(51907415, creado.CI);
        }
    }
}