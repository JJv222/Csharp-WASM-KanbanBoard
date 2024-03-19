namespace KanbanBoard_Blazor.Models
{
	public class project
	{
		public int id { get; set; }
		public List<kanbanTask> tasks { get; set; }
	}
}
