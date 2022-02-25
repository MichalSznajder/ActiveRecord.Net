namespace DCOM.Business
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Data;

    public class WorkItem : BusinessEntity<Data.WorkItem, int>
    {
        public WorkItem(IDataContextProvider contextProvider) : base(contextProvider)
        {
        }

        [Required]
        public string Description
        {
            get;
            set;
        }

        [Range(0, int.MaxValue)]
        public int HoursEstimated
        {
            get;
            private set;
        }

        [Range(0, int.MaxValue)]
        public int HoursRemaining
        {
            get;
            private set;
        }

        [Range(0, int.MaxValue)]
        public int HoursWorked
        {
            get;
            private set;
        }
        
        public string Priority
        {
            get;
            private set;
        }

        public string Status
        {
            get;
            private set;
        }

        public void AssignTo(Developer developer)
        {
            Entity.PersonId = developer.Id;
        }

        public void ChangeStatus(string status)
        {
            var entity = Context.WorkItemStatuses.Single(p => p.Name == status);

            Entity.StatusId = entity.Id;

            Status = entity.Name;
        }

        public void ChangePriority(string priority)
        {
            var entity = Context.WorkItemPriorities.Single(p => p.Name == priority);

            Entity.PriorityId = entity.Id;

            Priority = entity.Name;
        }

        public void Estimate(int hours)
        {
            HoursEstimated = hours;
        }

        public void LogWork(int hoursWorked)
        {
            HoursWorked += hoursWorked;
            HoursRemaining = Math.Max(0, HoursRemaining - hoursWorked);
        }

        public override void Load(int id)
        {
            base.Load(id);

            Description    = Entity.Description;
            HoursRemaining = Entity.HoursRemaining;
            HoursWorked    = Entity.HoursWorked;
            HoursEstimated = Entity.HoursEstimated;
            Status         = Context.WorkItemStatuses.Where(p => p.Id == Entity.StatusId).Select(p => p.Name).Single();
            Priority       = Context.WorkItemPriorities.Where(p => p.Id == Entity.PriorityId).Select(p => p.Name).Single();
        }

        public override void New()
        {
            base.New();

            Entity.StatusId = Context.WorkItemStatuses.Select(p => p.Id).First();
            Entity.PriorityId = Context.WorkItemPriorities.Select(p => p.Id).First();
        }

        public override void Save()
        {
            Entity.Description = Description;
            Entity.HoursRemaining = HoursRemaining;
            Entity.HoursWorked = HoursWorked;
            Entity.HoursEstimated = HoursEstimated;

            base.Save();

            if (Id == default(int))
            {
                Id = Entity.Id;
            }
        }

        public override string ToString()
        {
            return $"ID = {Id}, Status = {Status}, Priority = {Priority}, Description = {Description}";
        }
    }
}