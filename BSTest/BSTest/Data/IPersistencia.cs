using System.Collections.Generic;
using System.Threading.Tasks;

namespace BSTest.Data
{
    public interface IPersistencia
    {
        Task<List<TodoTask>> TraerTareas();
        Task<int> GuardarTareaAsync(TodoTask tarea);
        Task<int> MarcarTareaAsync(object Id);
        Task<int> BorrarTareaAsync(object Id);

    }
}
