using KanbanBoard_Blazor.Extensions;
using KanbanBoard_Blazor.Models;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;

namespace KanbanBoard_Blazor.Pages
{
    public partial class KanbanColumn
    {
        //public
        [Parameter]
        [Required]
        public Status status { get; set; }

        [Parameter]
        public string columnName { get; set; }

        [Parameter]
        [Required]
        public List<kanbanTask> tasks { get; set; }

        [Parameter]
        [Required]
        public myColor colorColumn { get; set; }

        protected override void OnInitialized()
        {
            if(columnName is null)
            {
                columnName =status.GetEnumDescription();
            }
        }
    }
}
