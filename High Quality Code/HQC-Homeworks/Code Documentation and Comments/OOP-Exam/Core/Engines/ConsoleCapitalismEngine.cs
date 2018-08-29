namespace ExamPreparationCapitalism.Core.Engines
{
    using System;
    using Commands;
    using Interfaces;

    internal class ConsoleCapitalismEngine : IEngine
    {
        private readonly IDatabase db;

        public ConsoleCapitalismEngine(IDatabase db)
        {
            this.db = db;
        }

        public void Run()
        {
            IExecutable command = null;
            var line = Console.ReadLine();
            while (line != "end")
            {
                var tokens = line.Split();
                switch (tokens[0])
                {
                    case "create-company":
                        command = new CreateCompanyCommand(this.db,
                            tokens[1],
                            tokens[2],
                            tokens[3],
                            decimal.Parse(tokens[4]));
                        break;
                    case "create-employee":
                        string departmentName = null;
                        if (tokens.Length > 5)
                        {
                            departmentName = tokens[5];
                        }
                        command = new CreateEmployeeCommand(this.db,
                            tokens[1],
                            tokens[2],
                            tokens[3],
                            tokens[4],
                            departmentName);
                        break;
                    case "create-department":
                        string mainDepartmentName = null;
                        if (tokens.Length > 5)
                        {
                            mainDepartmentName = tokens[5];
                        }
                        command = new CreateDepartmentCommand(this.db,
                            tokens[1],
                            tokens[2],
                            tokens[3],
                            tokens[4],
                            mainDepartmentName);
                        break;
                    case "pay-salaries":
                        command = new PaySalariesCommand(tokens[1], this.db);
                        break;
                    case "show-employees":
                        command = new ShowEmployeesCommand(tokens[1], this.db);
                        break;
                }
                try
                {
                    Console.Write(command.Execute());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    line = Console.ReadLine();
                }
            }
        }
    }
}