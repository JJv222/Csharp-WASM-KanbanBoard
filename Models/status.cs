using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KanbanBoard_Blazor.Models
{
    public enum Status
    {
        [Display(Name = "New")]
        ToDo,
        [Display(Name = "Active")]
        InProgress,
        [Display(Name = "Resolved")]
        Done
    }
}
