namespace TP7
{
    public enum Estado
    {
        Pendiente,
        EnProgreso,
        Completada
    }
    public class Tarea
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public Estado Estado { get; set; }

        public Tarea()
        {
        }
        public Tarea(int id, string titulo, string Descripcion, Estado estado)
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Descripcion = Descripcion;
            this.Estado = estado;
        }
    }
}
