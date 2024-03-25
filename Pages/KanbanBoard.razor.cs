 using KanbanBoard_Blazor.Extensions;
using KanbanBoard_Blazor.Models;
using Microsoft.AspNetCore.Components;


namespace KanbanBoard_Blazor.Pages
{
    public partial class KanbanBoard
    {
		[Parameter] public string projectId { get; set; }
        public Status _status { get; set; }
        private Project _project = new Project();
        private KanbanTask _currenTask;
        private bool _isDragging = false;
        [SupplyParameterFromForm] 
        private KanbanTask _addedTask { get; set; } = new KanbanTask();
        private bool started = false;

		// Methods
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
				await localStorage.SetItemAsync(projectId, _project);
			}
			await LoadProject();
        }

        // LocalStorage methods
        private async Task LoadProject()
        {
            _addedTask.description = "New Task name...";
            _project = await localStorage.GetItemAsync<Project>(projectId) ?? new Project();
            var projects = await localStorage.GetItemAsync<List<Project>>("projects");
			_project.name = projects.FirstOrDefault(p => p.id == projectId)?.name;
			StateHasChanged();
        }

        protected override async Task OnInitializedAsync()
        {
           await LoadProject();
		}

        private async Task AddTask()
        {
            if (_addedTask is not null)
            {
                if (_project.tasks is null)
                {
                    _project.tasks = new List<KanbanTask>();
                }
                _project.tasks.Add(new KanbanTask { description = _addedTask.description, status = Status.ToDo });
				await localStorage.SetItemAsync(projectId, _project);
				await LoadProject();
            }
        }

        public async void ClearProject( )
        {
            _project.tasks.Clear();
            await  localStorage.RemoveItemAsync(projectId);
			await LoadProject();
        }

        public async Task DeleteProject()
        {
            var projects = await localStorage.GetItemAsync<List<Project>>("projects");
            projects.Remove(projects.FirstOrDefault(_p=> _p.id == projectId));
            await localStorage.SetItemAsync("projects", projects);
			_project.tasks.Clear();
			await localStorage.RemoveItemAsync(projectId);
            uriHelper.NavigateTo("/",forceLoad:true);
		}

	}
}
