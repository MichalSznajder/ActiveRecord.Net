namespace DCOM.Data
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(nameof(WorkItemPriority))]
    public class WorkItemPriority
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<WorkItem> WorkItems{ get; set; }
    }
}