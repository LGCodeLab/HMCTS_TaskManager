using System.ComponentModel.DataAnnotations;

namespace HMCTS_TaskManager.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        public string Status { get; set; } = string.Empty;

        [Required]
        public DateTime DueDate { get; set; }
    }
}
