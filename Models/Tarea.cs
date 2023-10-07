namespace TP7
{
    public class Tarea
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Titulo { get; set; }
        public Estado Estado { get; set; }
    }
    public enum Estado
    {
        Pendiente,
        EnProgreso,
        Completada
    }
}
