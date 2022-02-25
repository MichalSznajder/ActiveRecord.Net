namespace DCOM.Presentation.Commands
{
    using System;
    using Data;

    public class ClsCommand : Command
    {
        public ClsCommand(IDataContextProvider provider) : base("cls", provider)
        {
        }

        public override void Execute()
        {
            Console.Clear();
        }
    }
}