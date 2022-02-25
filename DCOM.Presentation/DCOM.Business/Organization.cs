namespace DCOM.Business
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data;

    public class Organization
    {
        private readonly IDataContextProvider provider;

        public Organization(IDataContextProvider provider)
        {
            this.provider = provider;
        }

        public Developer GetDeveloper(string email)
        {
            using (var db = provider.GetContext())
            {
                var id = db.Persons.Where(p => p.Role.Name == "Developer" &&
                                               string.Equals(p.EmailAddress, 
                                                             email, 
                                                             StringComparison.CurrentCultureIgnoreCase))
                                   .Select(p => p.Id)
                                   .SingleOrDefault();

                if (id == 0) return null;

                var dev = new Developer(provider);

                dev.Load(id);

                return dev;
            }
        }

        public IEnumerable<Developer> GetDevelopers()
        {
            using (var db = provider.GetContext())
            {
                foreach (var id in db.Persons.Where(p => p.Role.Name == "Developer").Select(p => p.Id))
                {
                    var dev = new Developer(provider);

                    dev.Load(id);

                    yield return dev;
                }
            }
        }
    }
}