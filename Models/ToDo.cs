namespace ToDoApi.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string Estado { get; set; } = "Pendiente";
    }
}
