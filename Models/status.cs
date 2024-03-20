using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KanbanBoard_Blazor.Models
{
    public enum Status
    {
        [Description("New")]
        ToDo,
        [Description("Active")]
        InProgress,
        [Description("Resolved")]
        Done
    }
}
