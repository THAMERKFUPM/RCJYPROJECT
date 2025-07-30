namespace UserManagement02.ViewModels;

public class TraineeDirectoryVM
{
    public string ScopeTitle { get; set; } = "";
    public bool ShowDepartment { get; set; }
    public bool ShowSupervisor { get; set; }
    public bool ShowEvaluation { get; set; }
    public bool ShowAttendance { get; set; }
    public List<TraineeRowVM> Rows { get; set; }
}