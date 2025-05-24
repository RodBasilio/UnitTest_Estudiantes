using AppEstudiantes.Modelos;


namespace AppEstudiantes.Servicios
{
    public class ServicioEstudiante : IServicioEstudiante
    {
        private List<Estudiante> _estudiantes;

        public ServicioEstudiante()
        {
            _estudiantes = new List<Estudiante>();
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
            var estudianteExistente = _estudiantes.FirstOrDefault(e => e.CI == ci);
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
            var estudiante = _estudiantes.FirstOrDefault(e => e.CI == ci);
            if (estudiante == null)
            {
                return false;
            }
            return estudiante.Nota >= 51;
        }
    }
}