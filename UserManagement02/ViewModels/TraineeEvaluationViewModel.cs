// ViewModels/TraineeEvaluationViewModel.cs
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using UserManagement02.Models;

namespace UserManagement02.ViewModels
{
    public class TraineeEvaluationViewModel
    {
        [Display(Name = "اسم المتدرب"), Required]
        public int SelectedTraineeId { get; set; }

        public IEnumerable<SelectListItem> Trainees { get; set; }
            = Enumerable.Empty<SelectListItem>();

        // show trainee info
        public string? FullName { get; set; }
        public string? Major { get; set; }
        public string? UniversityName { get; set; }
        public DateTime? TrainingEnd { get; set; }
        [Display(Name = "تاريخ المباشرة")]
        public DateTime StartDate { get; set; }

        [Display(Name = "تاريخ انتهاء التدريب")]
        public DateTime EndDate { get; set; }

        /// <summary> عدد الأيام المتبقية </summary>
        public int DaysRemaining
            => (EndDate.Date - DateTime.Today).Days;

        // the 8 criteria
        [Required, Display(Name = "الحماس للعمل والرغبة فيه")]
        public EvaluationLevel Enthusiasm { get; set; }

        [Required, Display(Name = "الدقة في تقديم العمل المطلوب")]
        public EvaluationLevel Accuracy { get; set; }

        [Required, Display(Name = "جودة الأداء")]
        public EvaluationLevel Quality { get; set; }

        [Required, Display(Name = "روح المبادرة للمهمات")]
        public EvaluationLevel Initiative { get; set; }

        [Required, Display(Name = "العلاقة الفعالة مع الآخرين في العمل")]
        public EvaluationLevel Teamwork { get; set; }

        [Required, Display(Name = "الالتزام بالدوام")]
        public EvaluationLevel Dependability { get; set; }

        [Required, Display(Name = "التحكم في الأمور واتخاذ القرار")]
        public EvaluationLevel DecisionPower { get; set; }

        [Required, Display(Name = "القدرة على التعلم والبحث عن المعلومات")]
        public EvaluationLevel LearningAbility { get; set; }
       
        public DateTime EvaluatedOn { get; set; } = DateTime.UtcNow;


        // --------------------------------------------------------------------
        // overall score = (sum of 8 values) / (max * 8) * 100, rounded
        // --------------------------------------------------------------------
        public int OverallScore
        {
            get
            {
                // sum numeric values directly from enum
                var sum = (int)Enthusiasm
                        + (int)Accuracy
                        + (int)Quality
                        + (int)Initiative
                        + (int)Teamwork
                        + (int)Dependability
                        + (int)DecisionPower
                        + (int)LearningAbility;

                // find highest enum value as maximum per criterion
                var maxPerCriterion = Enum.GetValues(typeof(EvaluationLevel))
                                          .Cast<EvaluationLevel>()
                                          .Max(e => (int)e);

                var maxTotal = maxPerCriterion * 8;
                if (maxTotal == 0) return 0;

                return (int)Math.Round(sum / (double)maxTotal * 100);
            }
        }

        /// <summary>
        /// e.g. "87%"
        /// </summary>
        public string OverallScoreDisplay => $"{OverallScore}%";
        public List<Evaluation> History { get; set; }
            = new List<Evaluation>();
    }
}

