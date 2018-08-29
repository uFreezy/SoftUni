namespace BigMani.Core
{
    using System;
    using System.Linq;
    using Data;
    using Interfaces;

    public class Engine
    {
        private readonly Dispatcher dispatcher;

        //private Command command;

        private readonly IUserInterface userInterface;

        public Engine(IUserInterface userInterface)
        {
            this.dispatcher = new Dispatcher(this);
            this.userInterface = userInterface;
        }

        public Command Command { get; set; }

        public void Run()
        {
            while (true)
            {
                var line = this.userInterface.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    break;
                }

                line = line.Trim();
                try
                {
                    this.Command = new Command(line);
                    this.dispatcher.Dispatch();
                }
                catch (InvalidOperationException ex)
                {
                    this.userInterface.WriteLine(ex.Message);
                }
            }
        }

        public string Status()
        {
            var reports = AirConditionerData.GetReportsCount();
            double airConditioners = AirConditionerData.GetAirConditionersCount();

            var percent = reports/airConditioners;
            percent = percent*100;
            throw new InvalidOperationException(string.Format(Messages.Status, percent));
            //return string.Format(Messages.Status, percent);
        }

        public void ValidateParametersCount(Command command, int count)
        {
            if (command.Parameters.Count() != count)
            {
                throw new InvalidOperationException(Messages.InvalidCommand);
            }
        }
    }
}