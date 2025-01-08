using System.ComponentModel.DataAnnotations;

namespace HumanResources.Models
{
    public class HumanResourcesMaster
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? CellPhone { get; set; }
        public string? WorkRegion { get; set; }
        public string? Ability { get; set; }
        public string? Status { get; set; }
        public DateTime? CreateTime { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }

    }
}
