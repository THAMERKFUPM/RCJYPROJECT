// Models/Evaluation.cs
using System.ComponentModel.DataAnnotations;

namespace UserManagement02.Models
{
    public class Evaluation
    {
        public int Id { get; set; }
        public int TraineeId { get; set; }
        public Trainee Trainee { get; set; } = null!;

        public EvaluationLevel Enthusiasm { get; set; }
        public EvaluationLevel Accuracy { get; set; }
        public EvaluationLevel Quality { get; set; }
        public EvaluationLevel Initiative { get; set; }
        public EvaluationLevel Teamwork { get; set; }
        public EvaluationLevel Dependability { get; set; }
        public EvaluationLevel DecisionPower { get; set; }
        public EvaluationLevel LearningAbility { get; set; }

        [Required]
        public int Score { get; set; }

        public DateTime EvaluatedOn { get; set; } = DateTime.UtcNow;
    }

    public enum EvaluationLevel
    {
        Poor = 25,
        Good = 50,
        [Display(Name = "Very Good")]
        Very_Good = 75,
        Excellent = 100
    }
}
