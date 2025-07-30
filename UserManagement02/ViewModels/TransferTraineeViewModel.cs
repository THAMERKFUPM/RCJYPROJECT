using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace UserManagement02.ViewModels
{
    public class TransferTraineeViewModel
    {
        [Required(ErrorMessage = "الرجاء اختيار اسم الطالب")]
        [Display(Name = "اختر اسم الطالب")]
        public int? TraineeId { get; set; }

        public IEnumerable<SelectListItem> Trainee { get; set; }
            = Enumerable.Empty<SelectListItem>();

        [Required(ErrorMessage = "الرجاء اختيار الإدارة")]
        [Display(Name = "اختر الإدارة")]
        public int? DepartmentId { get; set; }

        public IEnumerable<SelectListItem> Departments { get; set; }
            = Enumerable.Empty<SelectListItem>();
    }
}
