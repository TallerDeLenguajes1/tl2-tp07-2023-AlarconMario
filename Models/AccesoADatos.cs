using System.Text.Json;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace TP7
{
    public class AccesoADatos
    {
        private List<Tarea> ListaTarea = new List<Tarea>();
        public bool GuardarTarea(List<Tarea> tareas)
        {
            string json = File.ReadAllText("Tarea.json");
            var listaTareas = JsonSerializer.Deserialize<List<Tarea>>(json);
            string listaTarea = JsonSerializer.Serialize(tareas);  // serealizmos la lista de tareas
            File.WriteAllText("Tarea.json", listaTarea);
            if (listaTarea!=null)
            {
                return true;
            }else
            {
                return false;
            }
        }

        public List<Tarea> Leer()
        {
            string json = File.ReadAllText("Tarea.json");
            ListaTarea = JsonSerializer.Deserialize<List<Tarea>>(json);
            return ListaTarea;
        }
        
        

        
    }
}