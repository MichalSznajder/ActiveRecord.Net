namespace DCOM.Data
{
    using Microsoft.EntityFrameworkCore;

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public virtual DbSet<PersonRole> PersonRoles { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<WorkItem> WorkItems { get; set; }
        public virtual DbSet<WorkItemStatus> WorkItemStatuses { get; set; }
        public virtual DbSet<WorkItemPriority> WorkItemPriorities { get; set; }
    }
}