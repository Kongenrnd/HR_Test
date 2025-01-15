using HumanResources.Models;
using Microsoft.EntityFrameworkCore;

namespace HumanResources.Data
{
    public class HumanResourcesContext: DbContext
    {
        public HumanResourcesContext(DbContextOptions<HumanResourcesContext> options)
        : base(options)
        {
        }
        public DbSet<HumanResourcesMaster> HumanResourcesMasters { get; set; } = null!;
        public DbSet<SystemUserData> SystemUserDatas { get; set; } = null!;
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer(@"Data Source=desktop-f8382e1;Initial Catalog=HRDB;Integrated Security=True;Trust Server Certificate=True;");
        //}
    }
}
