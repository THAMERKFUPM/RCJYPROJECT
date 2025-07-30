namespace UserManagement02.ViewModels;

public class TraineeRowVM
{
    public int TraineeId { get; set; }
    public string FullName { get; set; } = "";
    public string Major { get; set; } = "";
    public string University { get; set; } = "";
    public string Department { get; set; } = "";
    public string? Supervisor { get; set; }
    public double? AverageScore { get; set; }
    public int? AttendancePercentage { get; set; }
}