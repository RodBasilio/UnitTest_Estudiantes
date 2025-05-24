using AppEstudiantes.Modelos;
using AppEstudiantes.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace AppEstudiantes.Controladores
{
    [ApiController]
    [Route("[controller]")]
    public class ControladorEstudiante : ControllerBase
    {
        private readonly IServicioEstudiante _servicioEstudiante;

        public ControladorEstudiante(IServicioEstudiante servicioEstudiante)
        {
            _servicioEstudiante = servicioEstudiante;
        }

        [HttpGet]
        public List<Estudiante> ObtenerTodos()
        {
            return _servicioEstudiante.ObtenerTodos();
        }

        [HttpGet("{ci}")]
        public Estudiante ObtenerPorCI(int ci)
        {
            return _servicioEstudiante.ObtenerPorCI(ci);
        }

        [HttpPost]
        public Estudiante Crear(Estudiante estudiante)
        {
            return _servicioEstudiante.Crear(estudiante);
        }

        [HttpPut("{ci}")]
        public Estudiante Actualizar(int ci, Estudiante estudianteActualizado)
        {
            return _servicioEstudiante.Actualizar(ci, estudianteActualizado);
        }

        [HttpDelete("{ci}")]
        public Estudiante Eliminar(int ci)
        {
            return _servicioEstudiante.Eliminar(ci);
        }

        [HttpGet("/estado/{ci}")]
        public string ObtenerEstado(int ci)
        {
           return _servicioEstudiante.EstaAprobado(ci) ? "Aprobado" : "Reprobado";
        }

    }
}