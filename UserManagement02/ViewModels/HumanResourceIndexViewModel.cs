namespace UserManagement02.ViewModels;

public class HumanResourceIndexViewModel
{
    
    public int TotalEmployees    { get; set; }
    public int ActiveEmployees   { get; set; }
    public int InactiveEmployees { get; set; }
    public string SearchTerm     { get; set; }
    public IEnumerable<TraineeViewModel> Items { get; set; }
}
