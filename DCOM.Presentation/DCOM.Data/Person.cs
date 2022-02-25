namespace DCOM.Data
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(nameof(Person))]
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required, EmailAddress]
        public string EmailAddress { get; set; }

        [Required, ForeignKey(nameof(Role))]
        public int RoleId { get; set; }
        
        public virtual PersonRole Role { get; set; }
        public virtual ICollection<WorkItem> WorkItems { get; } = new List<WorkItem>();
    }
}