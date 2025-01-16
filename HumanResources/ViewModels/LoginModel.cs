using System.ComponentModel.DataAnnotations;

namespace HumanResources.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage ="請輸入帳號")]
        [Display(Name ="帳號")]
        public string uid { get; set; }
        [Required(ErrorMessage = "請輸入密碼")]
        [Display(Name = "密碼")]
        public string pwd { get; set; }
    }
}
