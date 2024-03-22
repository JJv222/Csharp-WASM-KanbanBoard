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
        public List<KanbanTask> tasks { get; set; }

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
        public EventCallback<KanbanTask> OnDrag { get; set; }
        [Parameter]
        public EventCallback<Status> OnDrop { get; set; }


        private void OnDragStart(KanbanTask task)
        {
            OnDrag.InvokeAsync(task);
        }
        private void OnDropTask(Status newStatus)
        {
            OnDrop.InvokeAsync(newStatus);
        }

    }
}
