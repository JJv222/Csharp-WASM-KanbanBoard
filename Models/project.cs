namespace KanbanBoard_Blazor.Models
{
	public class Project
	{
		public string id { get; set; }
		public string name { get; set; }
		public List<KanbanTask> tasks { get; set; }
	}
}
