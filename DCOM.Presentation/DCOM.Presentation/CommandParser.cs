namespace DCOM.Presentation
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Data;

    public class CommandParser
    {
        private readonly IDataContextProvider provider;

        public CommandParser(IDataContextProvider provider)
        {
            this.provider = provider;
        }

        public bool TryParse(string input, out Command command)
        {
            var asm = Assembly.GetExecutingAssembly();
            var types = asm.GetTypes().Where(p => p.BaseType == typeof(Command));
            var type = types.SingleOrDefault(p => String.Equals(p.Name.Replace("Command", string.Empty), input, StringComparison.CurrentCultureIgnoreCase));

            if (type != null)
            {
                command = (Command)Activator.CreateInstance(type, new[] {provider});

                return true;
            }

            command = null;

            return false;
        }
    }
}