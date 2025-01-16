using System.ComponentModel.DataAnnotations;

namespace HumanResources.Models
{
    public class HumanResourcesMaster
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="姓名")]
        public string? Name { get; set; }
        [Display(Name = "性別")]
        public string? Gender { get; set; }
        [Display(Name = "電子信箱")]
        public string? Email { get; set; }
        [Display(Name = "市話")]
        public string? Phone { get; set; }
        [Display(Name = "手機")]
        public string? CellPhone { get; set; }
        [Display(Name = "工作地區")]
        public string? WorkRegion { get; set; }
        [Display(Name = "專業能力")]
        public string? Ability { get; set; }
        [Display(Name = "狀態")]
        public string? Status { get; set; }
        public DateTime? CreateTime { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }

    }
}
