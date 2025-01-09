using Microsoft.EntityFrameworkCore;

//public class ApplicationDbContext : DbContext
//{
//    public DbSet<User> Users { get; set; }
//    public DbSet<DayType> DayTypes { get; set; }
//    public DbSet<WorkingDay> WorkingDays { get; set; }
//    public DbSet<UserWorkingDay> UserWorkingDays { get; set; }
//    public DbSet<ChangeRequest> ChangeRequests { get; set; }
//    public DbSet<UserChangeRequest> UserChangeRequests { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {
//        optionsBuilder.UseNpgsql("Host=localhost;Database=StaffFlow;Username=postgres;Password=123456");
//    }
//}


public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<DayType> DayTypes { get; set; }
    public DbSet<WorkingDay> WorkingDays { get; set; }
    public DbSet<UserWorkingDay> UserWorkingDays { get; set; }
    public DbSet<ChangeRequest> ChangeRequests { get; set; }
    public DbSet<UserChangeRequest> UserChangeRequests { get; set; }
    public DbSet<SensorData> SensorData { get; set; }

}
