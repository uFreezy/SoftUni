namespace BigMani.Core
{
    using System;

    public class Command
    {
        //Parses commands.
        public Command(string line)
        {
            try
            {
                this.Name = line.Substring(0, line.IndexOf(' '));

                //BUG: Was line.IndexOf(' '). Supposed to be  +1. 
                this.Parameters = line.Substring(line.IndexOf(' ') + 1)
                    .Split(new[] {'(', ')', ','}, StringSplitOptions.RemoveEmptyEntries);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(Messages.InvalidCommand, ex);
            }
        }

        public string Name { get; private set; }

        public string[] Parameters { get; private set; }
    }
}