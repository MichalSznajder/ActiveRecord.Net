namespace DCOM.Data
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table(nameof(WorkItem))]
    public class WorkItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        public int HoursEstimated { get; set; }
        public int HoursWorked { get; set; }
        public int HoursRemaining { get; set; }

        [ForeignKey(nameof(Priority))]
        public int PriorityId { get; set; }

        [ForeignKey(nameof(Status))]
        public int StatusId { get; set; }

        [Required, ForeignKey(nameof(Person))]
        public int PersonId { get; set; }

        public virtual Person Person { get; set; }
        public virtual WorkItemStatus Status { get; set; }
        public virtual WorkItemPriority Priority { get; set; }
    }
}