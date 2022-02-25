namespace DCOM.Business
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;

    public class Developer : BusinessEntity<Person, int>
    {
        public Developer(IDataContextProvider contextProvider) : base(contextProvider)
        {
        }

        public string Name 
        { 
            get; 
            private set;
        }

        public string Email
        {
            get;
            private set;
        }

        public string Role
        {
            get;
            private set;
        }

        public int WorkItems
        {
            get;
            private set;
        }

        public int WorkRemaining
        {
            get;
            private set;
        }

        public void AddWorkItem(WorkItem item)
        {
            item.AssignTo(this);
        }

        public IEnumerable<WorkItem> GetWorkItems()
        {
            var ids = Context.WorkItems.Where(p => p.PersonId == Id)
                                       .Select(p => p.Id);

            foreach (var id in ids)
            {
                var item = new WorkItem(ContextProvider);

                item.Load(id);

                yield return item;
            }
        }

        public override void Load(int id)
        {
            base.Load(id);

            Name = $"{Entity.FirstName} {Entity.LastName}";

            Role          = Context.PersonRoles.Where(p => p.Id == Entity.RoleId).Select(p => p.Name).Single();
            WorkRemaining = Context.WorkItems.Where(p => p.PersonId == Id).Sum(p => p.HoursRemaining);
            WorkItems     = Context.WorkItems.Count(p => p.PersonId == Id);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}