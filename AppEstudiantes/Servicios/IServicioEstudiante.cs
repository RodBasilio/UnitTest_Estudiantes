using AppEstudiantes.Modelos;

namespace AppEstudiantes.Servicios
{
    public interface IServicioEstudiante
    {
        List<Estudiante> ObtenerTodos();
        Estudiante ObtenerPorCI(int ci);
        Estudiante Crear(Estudiante estudiante);
        Estudiante Actualizar(int ci, Estudiante estudianteActualizado);
        Estudiante Eliminar(int ci);
        bool EstaAprobado(int ci);
    }
}