namespace TP7
{
    public class ManejoDeTareas
    {
        private AccesoADatos accesoADatos;
        private List<Tarea> ListaDeTareas;

        public ManejoDeTareas(AccesoADatos datos)
        {
            this.accesoADatos = datos;
            this.ListaDeTareas = accesoADatos.Leer();
        }

        public Tarea crearTarea(Tarea tarea)
        {
            var ultimaTarea = ListaDeTareas.Last();
            tarea.Id = ultimaTarea.Id + 1;
            ListaDeTareas.Add(tarea);
            accesoADatos.GuardarTarea(ListaDeTareas);
            return tarea;
        }

        public Tarea ObtenerTarea(int id)
        {
            Tarea tarea = ListaDeTareas.FirstOrDefault(t => t.Id == id);
            return tarea;
        }

        public List<Tarea> actualizarTarea(int idTarea, int estado)
        {
            for (int i = 0; i < ListaDeTareas.Count; i++)
            {
                if (ListaDeTareas[i].Id == idTarea)
                {
                    ListaDeTareas[i].Estado = (Estado)estado;
                    break;
                }
            }
            accesoADatos.GuardarTarea(ListaDeTareas);
            return ListaDeTareas;
        }

        public void EliminarTarea(int idTarea)
        {
            for (int i = 0; i < ListaDeTareas.Count; i++)
            {
                if (ListaDeTareas[i].Id == idTarea)
                {
                    ListaDeTareas.RemoveAt(i);
                    break;
                }
            }
            accesoADatos.GuardarTarea(ListaDeTareas);
        }

        public List<Tarea> ListarTareas()
        {
            return ListaDeTareas;
        }

        public List<Tarea> ListaTareasCompletadas()
        {
            List<Tarea> Tcompletadas = new List<Tarea>();
            foreach (var t in ListaDeTareas)
            {
                if (t.Estado == Estado.Completada)
                {
                    Tcompletadas.Add(t);
                }
            }
            return Tcompletadas;
        }

        public bool IdTareaExiste(int idCadete)
        {
            Tarea tarea = ListaDeTareas.FirstOrDefault(t => t.Id == idCadete);
            if (tarea == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}