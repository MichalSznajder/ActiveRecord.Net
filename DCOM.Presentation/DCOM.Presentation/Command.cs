namespace DCOM.Presentation
{
    using Data;

    public abstract class Command
    {
        protected readonly IDataContextProvider Provider;

        protected Command(string identifier, IDataContextProvider provider)
        {
            Identifier = identifier;
            Provider = provider;
        }

        public string Identifier
        {
            get;
        }

        public abstract void Execute();
    }
}