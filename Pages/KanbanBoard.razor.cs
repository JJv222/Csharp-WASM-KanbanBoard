using KanbanBoard_Blazor.Models;

namespace KanbanBoard_Blazor.Pages
{
    public partial class KanbanBoard
    {
        private List<kanbanTask> _tasks { get; set; } = new();
        protected override void OnInitialized()
        {
            _tasks = new List<kanbanTask>
            {
                new kanbanTask { id = 1, description = "Task 1", status = Status.ToDo },
                new kanbanTask { id = 2, description = "Task 2", status = Status.ToDo },
                new kanbanTask { id = 3, description = "Task 3", status = Status.ToDo },
                new kanbanTask { id = 4, description = "Task 4", status =Status.ToDo },
                new kanbanTask { id = 5, description = "Task 5", status = Status.ToDo },
                new kanbanTask { id = 6, description = "Task 6", status = Status.ToDo }
            };
        }
    }
}
