using KanbanBoard_Blazor.Extensions;
using KanbanBoard_Blazor.Models;

namespace KanbanBoard_Blazor.Pages
{
    public partial class KanbanBoard
    {
        
        public Status _status { get; set; }

        private List<kanbanTask> _tasks { get; set; } = new();
        private kanbanTask _currenTask;
        private bool _isDragging = false;
        // Methods
        protected override void OnInitialized()
        {
            _tasks = new List<kanbanTask>
            {
                new kanbanTask { id = Guid.NewGuid(), description = "Task 1", status = Status.ToDo },
                new kanbanTask { id = Guid.NewGuid(), description = "Task 2", status = Status.ToDo },
                new kanbanTask { id = Guid.NewGuid(), description = "Task 3", status = Status.ToDo },
                new kanbanTask { id = Guid.NewGuid(), description = "Task 4", status =Status.ToDo },
                new kanbanTask { id = Guid.NewGuid(), description = "Task 5", status = Status.ToDo },
                new kanbanTask { id = Guid.NewGuid(), description = "Task 6", status = Status.ToDo },
                new kanbanTask { id = Guid.NewGuid(), description = "Task7", status = Status.InProgress },
                new kanbanTask { id = Guid.NewGuid(), description = "Task 8", status = Status.InProgress },
                new kanbanTask { id = Guid.NewGuid(), description = "Task 9", status = Status.InProgress },
                new kanbanTask { id = Guid.NewGuid(), description = "Task 10", status = Status.Done },
                new kanbanTask { id = Guid.NewGuid(), description = "Task 11", status = Status.Done },
            };
        }
        private void onStartDrag(kanbanTask task)
        {
            _currenTask = task;
            _isDragging = true;
        }
        private void onDrop(Status newStatus)
        {
            if (_currenTask is not null && _isDragging)
            {
                _currenTask.status = newStatus;
                _currenTask = null;
                _isDragging = false;
            }
        }
    }
}
