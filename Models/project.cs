namespace KanbanBoard_Blazor.Models
{
	public class Project
	{
		public int id { get; set; }
		public List<KanbanTask> tasks { get; set; }
	}
}
