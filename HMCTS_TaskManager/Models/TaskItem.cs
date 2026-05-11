namespace HMCTS_TaskManager.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string Status { get; set; } = "ToDo";

        public DateTime DueDate { get; set; }
    }
}
