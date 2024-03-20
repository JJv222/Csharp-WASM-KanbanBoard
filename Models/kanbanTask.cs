using System.Drawing;

namespace KanbanBoard_Blazor.Models
{
    public class kanbanTask
    {
        public Guid id { get; set; }
        public string description { get; set; }
        public Status status { get; set; }

    }
}