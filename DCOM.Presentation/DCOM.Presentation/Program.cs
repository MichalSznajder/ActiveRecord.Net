namespace DCOM.Presentation
{
    using System;
    using Data;

    class Program
    {
        private static readonly IDataContextProvider Provider = new DataContextProvider();
        private static readonly CommandParser Parser = new CommandParser(Provider);

        static void Main()
        {
            while (true)
            {
                Console.Write(@"DCOM:\> ");

                string input = Console.ReadLine();

                if (Parser.TryParse(input, out var command))
                {
                    command.Execute();
                    continue;
                }
                
                Console.WriteLine($"{input} is not a valid command.");
            }
        }
    }
}