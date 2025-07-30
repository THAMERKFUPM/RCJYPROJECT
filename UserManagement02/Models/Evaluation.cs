// Models/Evaluation.cs
using System.ComponentModel.DataAnnotations;

namespace UserManagement02.Models
{
    public class Evaluation
    {
        public int Id { get; set; }
        public int TraineeId { get; set; }
        public Trainee Trainee { get; set; } = null!;

        // 0 = ضعيف, 1 = جيد, 2 = جيد جداً, 3 = ممتاز
        public EvaluationLevel Enthusiasm { get; set; }
        public EvaluationLevel Accuracy { get; set; }
        public EvaluationLevel Quality { get; set; }
        public EvaluationLevel Initiative { get; set; }
        public EvaluationLevel Teamwork { get; set; }
        public EvaluationLevel Dependability { get; set; }
        public EvaluationLevel DecisionPower { get; set; }
        public EvaluationLevel LearningAbility { get; set; }

        public DateTime EvaluatedOn { get; set; } = DateTime.UtcNow;
    }

    public enum EvaluationLevel
    {
        ضعيف = 0,
        جيد = 1,
        [Display(Name = "جيد جداً")]
        جيد_جداً = 2,
        ممتاز = 3
    }
}
