using System.Drawing;

namespace KanbanBoard_Blazor.Models
{
    public class KanbanTask
    {
        public int projectId { get; set; }
        public string description { get; set; }
        public Status status { get; set; }

    }
}