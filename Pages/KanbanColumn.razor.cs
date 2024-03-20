using KanbanBoard_Blazor.Extensions;
using KanbanBoard_Blazor.Models;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;

namespace KanbanBoard_Blazor.Pages
{
    public partial class KanbanColumn
    {
        //public
        [Parameter][Required]
        public Status status { get; set; }

        [Parameter]
        public string columnName { get; set; }

        [Parameter][Required]
        public List<kanbanTask> tasks { get; set; }

        [Parameter][Required]
        public string colorColumn { get; set; }


        protected override void OnInitialized()
        {
            if (columnName is null)
            {
                columnName = status.GetEnumDescription();
            }
        }


        //comunication with parent
        [Parameter]
        public EventCallback<kanbanTask> OnDrag { get; set; }
        [Parameter]
        public EventCallback<Status> OnDrop { get; set; }


        private void OnDragStart(kanbanTask task)
        {
            OnDrag.InvokeAsync(task);
        }
        private void OnDropTask(Status newStatus)
        {
            OnDrop.InvokeAsync(newStatus);
        }

    }
}
