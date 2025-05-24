using AppEstudiantes.Modelos;
using AppEstudiantes.Servicios;

namespace AppEstudiantes.Test.Stubs
{
    public class StubServicioEstudiante : IServicioEstudiante
    {
        private List<Estudiante> _estudiantes;
        private readonly bool? _resultadoFijo;

        public StubServicioEstudiante()
        {
            _estudiantes = new List<Estudiante>
            {
                new Estudiante { CI = 59816946, Nombre = "Echo", Nota = 83 },
                new Estudiante { CI = 19261238, Nombre = "Fives", Nota = 25 },
                new Estudiante { CI = 98419261, Nombre = "Appo", Nota = 64 }
            };
        }

        public StubServicioEstudiante(bool resultado) : this()
        {
            _resultadoFijo = resultado;
        }


        public List<Estudiante> ObtenerTodos()
        {
            return _estudiantes;
        }

        public Estudiante ObtenerPorCI(int ci)
        {
            return _estudiantes.FirstOrDefault(e => e.CI == ci);
        }

        public Estudiante Crear(Estudiante estudiante)
        {
            _estudiantes.Add(estudiante);
            return estudiante;
        }

        public Estudiante Actualizar(int ci, Estudiante estudianteActualizado)
        {
            var estudianteExistente = ObtenerPorCI(ci);
            if (estudianteExistente == null) return null;

            estudianteExistente.Nombre = estudianteActualizado.Nombre;
            estudianteExistente.Nota = estudianteActualizado.Nota;

            return estudianteExistente;
        }

        public Estudiante Eliminar(int ci)
        {
            var estudiante = ObtenerPorCI(ci);
            if (estudiante != null)
            {
                _estudiantes.Remove(estudiante);
            }
            return estudiante;
        }

        public bool EstaAprobado(int ci)
        {
            if (_resultadoFijo.HasValue)
                return _resultadoFijo.Value;

            var estudiante = ObtenerPorCI(ci);
            return estudiante != null && estudiante.Nota >= 51;
        }
    }
}