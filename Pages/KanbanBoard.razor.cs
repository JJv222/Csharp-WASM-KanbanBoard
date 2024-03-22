 using KanbanBoard_Blazor.Extensions;
using KanbanBoard_Blazor.Models;
using Microsoft.AspNetCore.Components;

namespace KanbanBoard_Blazor.Pages
{
    public partial class KanbanBoard
    {
        
        public Status _status { get; set; }
        private Project _project = new Project();
        private KanbanTask _currenTask;
        private bool _isDragging = false;

        [SupplyParameterFromForm] 
        private KanbanTask _addedTask { get; set; } = new KanbanTask();
        // Methods
        protected override async Task OnInitializedAsync()
        {
            _addedTask.description = "Wprowadz nowe zadanie";
            _project = await localStorage.GetItemAsync<Project>(_project.id.ToString()) ?? new Project();
        }
        private void onStartDrag(KanbanTask task)
        {
            _currenTask = task;
            _isDragging = true;
        }

        private async void onDrop(Status newStatus)
        {
            if (_currenTask is not null && _isDragging)
            {
                _currenTask.status = newStatus;
                _currenTask = null;
                _isDragging = false;
            }
            await localStorage.ClearAsync();
            await localStorage.SetItemAsync(_project.id.ToString(), _project);
        }

        // LocalStorage methods
        private async Task AddTask()
        {
            if (_addedTask is not null)
            {
                if (_project.tasks is null)
                {
                    _project.tasks = new List<KanbanTask>();
                }
                _project.tasks.Add(new KanbanTask { description = _addedTask.description, status = Status.InProgress });
                await localStorage.SetItemAsync(_project.id.ToString(), _project);
            }
        }

        public async void ClearProject( )
        {
            _project.tasks.Clear();
            await  localStorage.ClearAsync();
            StateHasChanged();
        }
    }
}
