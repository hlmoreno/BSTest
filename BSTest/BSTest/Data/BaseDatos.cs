using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BSTest.Data
{
    public class BaseDatos : IPersistencia
    {
        readonly SQLiteAsyncConnection database;

        public BaseDatos(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<TodoTask>().Wait();
        }
        public Task<int> BorrarTareaAsync(object Id)
        {
            return database.DeleteAsync<TodoTask>(Id);
        }

        public Task<int> GuardarTareaAsync(TodoTask tarea)
        {
            return database.InsertAsync(tarea);
        }

        public Task<int> MarcarTareaAsync(object Id)
        {
            var tarea = database.FindAsync<TodoTask>(Id).Result;
            tarea.Done = true;
            return database.InsertOrReplaceAsync(tarea);
        }

        public Task<List<TodoTask>> TraerTareas()
        {
            return database.Table<TodoTask>().ToListAsync();
        }
    }
}
