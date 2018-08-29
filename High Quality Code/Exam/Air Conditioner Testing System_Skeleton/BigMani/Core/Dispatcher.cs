namespace BigMani.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Controllers;

    public class Dispatcher
    {
        private readonly Engine engineInstance;
        private Command command;
        private string controllerName;

        public Dispatcher(Engine engine)
        {
            this.engineInstance = engine;
        }

        public void Dispatch()
        {
            try
            {
                if (this.engineInstance.Command.Name.Contains("Report"))
                {
                    this.controllerName = "ReportController";
                }
                else
                {
                    this.controllerName = "AirConditionerController";
                }

                var controllerType = Assembly
                    .GetExecutingAssembly()
                    .GetTypes()
                    .FirstOrDefault(type => type.Name == this.controllerName);
                var controller = Activator.CreateInstance(controllerType);

                this.command = this.engineInstance.Command;

                switch (this.command.Name)
                {
                    case "RegisterStationaryAirConditioner":
                        this.engineInstance.ValidateParametersCount(this.command, 4);

                        (controller as AirConditionerController).RegisterStationaryAirConditioner(
                            this.command.Parameters[0],
                            this.command.Parameters[1],
                            this.command.Parameters[2].ToCharArray()[0], //!!!
                            int.Parse(this.command.Parameters[3]));

                        break;
                    case "RegisterCarAirConditioner":
                        this.engineInstance.ValidateParametersCount(this.command, 3);

                        (controller as AirConditionerController).RegisterCarAirConditioner(
                            this.command.Parameters[0],
                            this.command.Parameters[1],
                            int.Parse(this.command.Parameters[2]));
                        break;
                    case "RegisterPlaneAirConditioner":
                        this.engineInstance.ValidateParametersCount(this.command, 4);

                        (controller as AirConditionerController).RegisterPlaneAirConditioner(
                            this.command.Parameters[0],
                            this.command.Parameters[1],
                            int.Parse(this.command.Parameters[2]),
                            this.command.Parameters[3]);
                        break;
                    case "TestAirConditioner":
                        this.engineInstance.ValidateParametersCount(this.command, 2);

                        (controller as AirConditionerController).TestAirConditioner(
                            this.command.Parameters[0],
                            this.command.Parameters[1]);
                        break;
                    case "FindAirConditioner":
                        this.engineInstance.ValidateParametersCount(this.command, 2);

                        (controller as AirConditionerController).FindAirConditioner(
                            this.command.Parameters[1],
                            this.command.Parameters[0]);
                        break;
                    case "FindReport":
                        this.engineInstance.ValidateParametersCount(this.command, 2);

                        (controller as ReportController).FindReport(
                            this.command.Parameters[0],
                            this.command.Parameters[1]);
                        break;
                    case "FindAllReportsByManufacturer":
                        this.engineInstance.ValidateParametersCount(this.command, 1);

                        (controller as ReportController).FindAllReportsByManufacturer(
                            this.command.Parameters[0]);
                        break;
                    case "Status":
                        this.engineInstance.ValidateParametersCount(this.command, 0);
                        this.engineInstance.Status();
                        break;
                    default:
                        throw new IndexOutOfRangeException(Messages.InvalidCommand);
                }
            }
            catch (FormatException ex)
            {
                throw new InvalidOperationException(Messages.InvalidCommand, ex.InnerException);
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new InvalidOperationException(Messages.InvalidCommand, ex.InnerException);
            }
        }
    }
}