using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models
{
    public class Todo
    {
        [Key]
        public int TodoId { get; set; }

        [MinLength(4,ErrorMessage = "too short")]
        [Required(ErrorMessage = "Task name is required")]
        public string TaskName { get; set; }

        [Required(ErrorMessage = "Task description is required")]
        [MinLength(5, ErrorMessage = "Task description must be at least 10 characters long")]
        public string TaskDescription { get; set; }

        public bool IsCompleted { get; set; } = false;

        public DateTime? CreatedAt { get; set; } = DateTime.Now;




    }
}
