namespace DCOM.Presentation.Commands
{
    using System;
    using Business;
    using Data;

    public class GetWorkCommand : Command
    {
        public GetWorkCommand(IDataContextProvider provider) : base("getwork", provider)
        {
        }

        public override void Execute()
        {
            var organization = new Organization(Provider);

            foreach (var dev in organization.GetDevelopers())
            {
                Console.WriteLine($"\t{dev}'s Work Items --");

                foreach (var item in dev.GetWorkItems())
                {
                    Console.WriteLine($"\t\t{item}");
                }
            }
        }
    }
}