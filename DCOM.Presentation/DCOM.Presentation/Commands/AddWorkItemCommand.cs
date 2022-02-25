namespace DCOM.Presentation.Commands
{
    using System;
    using Business;
    using Data;
    using WorkItem = Business.WorkItem;

    public class AddWorkItemCommand : Command
    {
        public AddWorkItemCommand(IDataContextProvider provider) : base("addwork", provider)
        {
        }

        public override void Execute()
        {
            Console.Write("\tdev's email: ");

            string email = Console.ReadLine();

            Console.Write("\tdescription: ");

            string description = Console.ReadLine();

            var organization = new Organization(Provider);

            var dev = organization.GetDeveloper(email);

            if (dev == null)
            {
                Console.WriteLine($"\t{email} is not a developer within the organization.");
                return;
            }

            var item = new WorkItem(Provider);

            item.New();
            item.Description = description;
            item.AssignTo(dev);

            if (item.IsValid(out var results))
            {
                item.Save();

                Console.WriteLine($"\tAdded {item} to {dev.Name}.");
            }
            else
            {
                Console.WriteLine("\tItem not added because:");

                foreach (var result in results)
                {
                    Console.WriteLine($"\t\t{result.ErrorMessage}");
                }
            }
        }
    }
}