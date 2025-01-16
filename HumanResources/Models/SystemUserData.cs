using System;
using System.ComponentModel.DataAnnotations;

namespace HumanResources.Models
{
    public class SystemUserData
    {
        [Key]
        public required string UserAccount { get; set; }
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
        public string? UserPassword { get; set; }
        public string? PasswordHash { get; set; }
        public string? UserAuth { get; set; }
        public DateTime? CreateTime { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
