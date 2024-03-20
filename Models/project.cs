namespace KanbanBoard_Blazor.Models
{
	public class project
	{
		public Guid id { get; set; }
		public List<kanbanTask> tasks { get; set; }
	}
}
