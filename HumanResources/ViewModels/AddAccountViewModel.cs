using System.ComponentModel.DataAnnotations;

namespace HumanResources.ViewModels
{
    public class AddAccountViewModel
    {
        [Required]
        [MaxLength(20)]
        [Display(Name ="帳號")]
        public string UserAccount { get; set; }
        [Required]
        [MaxLength(20)]
        [Display(Name = "姓名")]
        public string UserName { get; set; }
        [Required]
        [MaxLength(20)]
        [Display(Name = "密碼")]
        public string UserPassword { get; set; }
        [Required]
        [MaxLength(20)]
        [Display(Name = "信箱")]
        public string UserEmail { get; set; }
        [Required]
        [MaxLength(20)]
        [Display(Name = "權限")]
        public string UserAuth{ get; set; }
        [Display(Name = "建立時間")]
        public DateTime CreateTime { get; set; }
        [Display(Name = "最後修改者")]
        public string LastModifiedBy { get; set; }
        [Display(Name = "最後修改時間")]
        public DateTime LastModifiedTime { get; set; }
    }
}
