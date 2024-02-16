//Ramandeep Kaur Dhlaiwal
//991419942
//Assignment 1

using ConsoleTables;
using System.Collections.Concurrent;
using System.Security.Cryptography.X509Certificates;
using static A1RamandeepDhaliwal.Employee;

namespace A1RamandeepDhaliwal
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Employee> list = new List<Employee>();
            mainMenu(list);
        }

        public static void mainMenu(List<Employee> list)
        {
            Console.Clear();
            Console.WriteLine("**********************************");
            Console.WriteLine("           Welcome                ");
            Console.WriteLine("**********************************");
            Console.WriteLine("       1 - Add Employee");
            Console.WriteLine("       2 - Edit Employee");
            Console.WriteLine("       3 - Delete Employee");
            Console.WriteLine("       4 - View Employee");
            Console.WriteLine("       5 - Search Employee");
            Console.WriteLine("       6 - Exit");

            Console.Write("Enter your choice: ");
            string inputValue = Console.ReadLine();

            bool checkValue = checkEmptyInput(inputValue);

            while (checkValue)
            {
                inputValue = Console.ReadLine();
                checkValue = checkEmptyInput(inputValue);
            }

            int choice = int.Parse(inputValue);
            Console.WriteLine(choice);


            switch (choice)
            {
                case 1:
                    addEmployee(list);
                    break;
                case 2:
                    editEmployee(list);
                    break;
                case 3:
                    deleteEmployee(list);
                    break;
                case 4:
                    viewEmployee(list);
                    break;
                case 5:
                    searchEmployee(list);
                    break;
                case 6:
                    exit();
                    break;
            }

        }

        public static bool checkEmptyInput(string input)
        {
            int value;
            int value1;
            bool response = (string.IsNullOrWhiteSpace(input));
            bool response1 = !(int.TryParse(input, out value));


            if ((response == true) || (response1 == true))
            {
                Console.WriteLine("Incorrect input. Please try again.");
                response = true;
            }
            else
            {
                value1 = int.Parse(input);
                if ((value1 >= 1) && (value1 <= 6))
                {
                    response = false;
                }
                else
                {
                    Console.WriteLine("Incorrect choice. Please enter a valid Interger from Menu");
                    response = true;
                }

            }
            return response;
        }

        public static bool isEmptyTryParse(string input)
        {
            bool response = string.IsNullOrWhiteSpace(input);
            bool response1 = true;
            int value;
            if (response == true)
            {
                Console.WriteLine("Incorrect input. Please try again.");
                response = true;
            }
            else
            {
                response1 = int.TryParse(input, out value);

                if (response1 == false)
                {
                    response = true;
                }

                else if (int.Parse(input) < 0)
                {
                    value = int.Parse(input);
                    response = false;
                }

            }
            return response;
        }

        public static void addEmployeeSub()
        {
            Console.WriteLine("Add New Employee");
            Console.WriteLine("     1 - Add Hourly Employee");
            Console.WriteLine("     2 - Add Commission Employee");
            Console.WriteLine("     3 - Add Salaried Employee");
            Console.WriteLine("     4 - Add Salary + Commission Employee");
            Console.WriteLine("     5 - Back to Main Menu");
        }

        public static void addEmployee(List<Employee> list)
        {
            Console.Clear();
            addEmployeeSub();
            Console.Write("Enter your choice: ");

            string inputValue = Console.ReadLine();
            bool checkValue = checkEmptyInput(inputValue);

            while (checkValue)
            {
                inputValue = Console.ReadLine();
                checkValue = checkEmptyInput(inputValue);
            }

            int choice = int.Parse(inputValue);
            addEmployeeSubmenu(choice, list);
        }

        public static void addEmployeeSubmenu(int choice, List<Employee> list)
        {
            switch (choice)
            {
                case 1:
                    addHourlyEmployee(list);
                    break;
                case 2:
                    addCommissionEmployee(list);
                    break;
                case 3:
                    addSalariedEmployee(list);
                    break;
                case 4:
                    addSalaryPlusComm(list);
                    break;
                case 5:
                    backToMain(list);
                    break;
            }
        }
        public static void addHourlyEmployee(List<Employee> list)
        {
            Console.Clear();

            addEmployeeSub();
            double workingHours = 0.0;
            Console.WriteLine("Adding Hourly Employee: ");

            Console.Write("Enter Employee Name: ");
            string name = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.Write("Please enter valid Name: ");
                name = Console.ReadLine();
            }

            Console.Write("Enter number of Hours worked: ");
            string hours = Console.ReadLine();
            bool validHours = isEmptyTryParse(hours);
            while (validHours)
            {
                Console.Write("Please enter valid number for hours: ");
                hours = Console.ReadLine();
                validHours = isEmptyTryParse(hours);
            }
            workingHours = double.Parse(hours);

            Console.Write("Enter wage: ");
            string wagestr = Console.ReadLine();
            bool validWage = isEmptyTryParse(wagestr);
            while (validWage)
            {
                Console.Write("Please enter valid number for wage: ");
                wagestr = Console.ReadLine();
                validWage = isEmptyTryParse(wagestr);
            }
            double wage = double.Parse(wagestr);

            Employee hourlyEmployee = new HourlyEmployee(EmployeeType.HourlyEmployee, name, workingHours, wage);
            list.Add(hourlyEmployee);
            displayHourly(list);
            Console.WriteLine("Select the option to continue......");

            int choice = nextChoice(list);
            addEmployeeSubmenu(choice, list);
        }

        public static void addCommissionEmployee(List<Employee> list)
        {
            Console.Clear();
            addEmployeeSub();
            Console.WriteLine("Adding Commission Employee:");
            double grossSale = 0.0;
            double commRate = 0.0;

            Console.Write("Enter Employee Name: ");
            string name = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.Write("Please enter valid Name: ");
                name = Console.ReadLine();
            }

            Console.Write("Enter Gross Sale: ");
            string gSaleStr = Console.ReadLine();
            bool validSale = isEmptyTryParse(gSaleStr);
            while (validSale)
            {
                Console.Write("Please enter valid number for Gross Sale: ");
                gSaleStr = Console.ReadLine();
                validSale = isEmptyTryParse(gSaleStr);
            }
            grossSale = double.Parse(gSaleStr);

            Console.Write("Enter Commission Rate(e.g: 10% as 10): ");
            string cRatestr = Console.ReadLine();
            bool validRate = isEmptyTryParse(cRatestr);
            while (validRate)
            {
                Console.Write("Please enter valid number for Commission Rate: ");
                cRatestr = Console.ReadLine();
                validRate = isEmptyTryParse(cRatestr);
            }
            commRate = double.Parse(cRatestr);

            Employee commEmployee = new CommissionEmployee(EmployeeType.CommissionEmployee, name, grossSale, commRate);

            list.Add(commEmployee);
            displayComm(list);

            Console.WriteLine("Select the option to continue......");
            int choice = nextChoice(list);
            addEmployeeSubmenu(choice, list);

        }

        public static void addSalariedEmployee(List<Employee> list)
        {
            Console.Clear();
            addEmployeeSub();
            Console.WriteLine("Adding Salaried Employee:");

            Console.Write("Enter Employee Name: ");
            string name = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.Write("Please enter valid Name: ");
                name = Console.ReadLine();
            }

            Console.Write("Enter Salary: ");
            string salry = Console.ReadLine();
            bool validSalary = isEmptyTryParse(salry);
            while (validSalary)
            {
                Console.Write("Please enter valid number for Salary: ");
                salry = Console.ReadLine();
                validSalary = isEmptyTryParse(salry);
            }
            double salary = double.Parse(salry);

            Employee salariedEmployee = new SalariedEmployee(EmployeeType.SalariedEmployee, name, salary);

            list.Add(salariedEmployee);
            displaySalr(list);

            Console.WriteLine("Select the option to continue......");

            int choice = nextChoice(list);
            addEmployeeSubmenu(choice, list);
        }

        public static void addSalaryPlusComm(List<Employee> list)
        {
            Console.Clear();
            addEmployeeSub();
            Console.WriteLine("Adding Salary Plus Commission Employee:");

            Console.Write("Enter Employee Name: ");
            string name = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.Write("Please enter valid Name: ");
                name = Console.ReadLine();
            }

            Console.Write("Enter Gross Sale: ");
            string gSaleStr = Console.ReadLine();
            bool validSale = isEmptyTryParse(gSaleStr);
            while (validSale)
            {
                Console.Write("Please enter valid number for Gross Sale: ");
                gSaleStr = Console.ReadLine();
                validSale = isEmptyTryParse(gSaleStr);
            }
            double grossSale = double.Parse(gSaleStr);

            Console.Write("Enter Commission Rate(e.g: 10% as 10): ");
            string cRatestr = Console.ReadLine();
            bool validRate = isEmptyTryParse(cRatestr);
            while (validRate)
            {
                Console.Write("Please enter valid number for Commission Rate: ");
                cRatestr = Console.ReadLine();
                validRate = isEmptyTryParse(cRatestr);
            }
            double commRate = double.Parse(cRatestr);

            Console.Write("Enter Salary: ");
            string salry = Console.ReadLine();
            bool validSalary = isEmptyTryParse(salry);
            while (validSalary)
            {
                Console.Write("Please enter valid number for Salary: ");
                salry = Console.ReadLine();
                validSalary = isEmptyTryParse(salry);
            }
            double salary = double.Parse(salry);

            Employee salPlusCommE = new SalaryPlusCommissionEmployee(EmployeeType.SalaryPlusCommissionEmployee, name, grossSale, commRate, salary);

            list.Add(salPlusCommE);
            displaySalComm(list);

            Console.WriteLine("Select the option to continue......");

            int nextInt = nextChoice(list);
            addEmployeeSubmenu(nextInt, list);
        }

        public static void displayHourly(List<Employee> list)
        {
            var hourlyEmployees = from e in list
                                  where e.EmployeeTypee == EmployeeType.HourlyEmployee
                                  orderby e.Id
                                  select e;
            ConsoleTable table = new ConsoleTable("Id", "Name", "Hours worked", "Hourly wage", "Gross Sale", "Tax(20%)", "Net Earnings");
            Console.WriteLine("View All Hourly Employees:");
            foreach (var e in hourlyEmployees)
            {

                HourlyEmployee employee = (HourlyEmployee)e;
                //Console.WriteLine(employee.ToString() + $"Gross Earnings = {employee.GrossEarnings().ToString("C"),-10} Tax(20%) = {employee.Tax.ToString("C"),-10} Net Earnings = {employee.NetEarnings.ToString("C"),-10}");
                table.AddRow(employee.Id, employee.EmployeeName, employee.Hours, employee.Wage, employee.GrossEarnings().ToString("C"), employee.Tax.ToString("C"), employee.NetEarnings.ToString("C"));
            }
            table.Write(Format.MarkDown);
        }

        public static void displayComm(List<Employee> list)
        {
            var commEmployees = from e in list
                                where e.EmployeeTypee == EmployeeType.CommissionEmployee
                                orderby e.Id
                                select e;

            Console.WriteLine("View All Commission Employees:");
            ConsoleTable table = new ConsoleTable("Id", "Name", "Gross Sale", "Commission Rate", "Gross Earnings", "Tax(20%)", "Net Earnings");
            foreach (var e in commEmployees)
            {
                CommissionEmployee employee = (CommissionEmployee)e;
                table.AddRow(employee.Id, employee.EmployeeName, employee.GrossSale, employee.CommissionRate.ToString("P"), employee.GrossEarnings().ToString("C"), employee.Tax.ToString("C"), employee.NetEarnings.ToString("C"));
            }
            table.Write(Format.MarkDown);
        }

        public static void displaySalr(List<Employee> list)
        {
            var salEmployees = from e in list
                               where e.EmployeeTypee == EmployeeType.SalariedEmployee
                               orderby e.Id
                               select e;

            Console.WriteLine("View All Salaried Employees:");
            ConsoleTable table = new ConsoleTable("Id", "Name", "Weekly Salary", "Gross Earnings", "Tax(20%)", "Net Earnings");
            foreach (var e in salEmployees)
            {
                SalariedEmployee employee = (SalariedEmployee)e;
                table.AddRow(employee.Id, employee.EmployeeName, employee.FixedSalary, employee.GrossEarnings().ToString("C"), employee.Tax.ToString("C"), employee.NetEarnings.ToString("C"));
            }
            table.Write(Format.MarkDown);
        }

        public static void displaySalComm(List<Employee> list)
        {
            var salComEmployees = from e in list
                                  where e.EmployeeTypee == EmployeeType.SalaryPlusCommissionEmployee
                                  orderby e.Id
                                  select e;

            Console.WriteLine("View All Salary Plus Commission Employees:");
            ConsoleTable table = new ConsoleTable("Id", "Name", "Gross Sale", "Commission Rate", "Fixed Salary", "Gross Earnings", "Tax(20%)", "Net Earnings");
            foreach (var e in salComEmployees)
            {
                SalaryPlusCommissionEmployee employee = (SalaryPlusCommissionEmployee)e;
                table.AddRow(employee.Id, employee.EmployeeName, employee.GrossSale, employee.CommissionRate.ToString("P"), employee.Salary, employee.GrossEarnings().ToString("C"), employee.Tax.ToString("C"), employee.NetEarnings.ToString("C"));
            }
            table.Write(Format.MarkDown);
        }
        public static int nextChoice(List<Employee> list)
        {
            int nextInt = 0;
            do
            {
                string next = Console.ReadLine();
                bool validNext = isEmptyTryParse(next);
                while (validNext)
                {
                    Console.Write("Please enter valid input: ");
                    next = Console.ReadLine();
                    validNext = isEmptyTryParse(next);
                }
                nextInt = int.Parse(next);
                if (nextInt > 5)
                {
                    Console.WriteLine("Please enter valid input:");
                }
            } while (nextInt > 5);
            return nextInt;

        }

        public static void editEmployee(List<Employee> list)
        {
            Console.Clear();
            editMenu(list);
            Console.Write("Enter your choice: ");

            string inputValue = Console.ReadLine();
            bool checkValue = checkEmptyInput(inputValue);

            while (checkValue)
            {
                inputValue = Console.ReadLine();
                checkValue = checkEmptyInput(inputValue);
            }

            int choice = int.Parse(inputValue);
            editEmployeeSubmenu(choice, list);

        }

        public static void editEmployeeSubmenu(int choice, List<Employee> list)
        {
            switch (choice)
            {
                case 1:
                    editHourlyEmployee(list);
                    break;
                case 2:
                    editCommissionEmployee(list);
                    break;
                case 3:
                    editSalariedEmployee(list);
                    break;
                case 4:
                    editSalaryPlusComm(list);
                    break;
                case 5:
                    backToMain(list);
                    break;
            }
        }

        public static void editMenu(List<Employee> list)
        {
            Console.WriteLine("Edit Employee");
            Console.WriteLine("     1 - Edit Hourly Employee");
            Console.WriteLine("     2 - Edit Commission Employee");
            Console.WriteLine("     3 - Edit Salaried Employee");
            Console.WriteLine("     4 - Edit Salary + Commission Employee");
            Console.WriteLine("     5 - Back to Main Menu");
        }


        public static void editHourlyEmployee(List<Employee> list)
        {
            Console.Clear();
            editMenu(list);
            displayHourly(list);
            Console.WriteLine();
            Console.WriteLine("Editing Hourly Employee");
            Console.WriteLine();
            int id = 0;
            Console.Write("Enter ID of employee you want to edit: ");
            string idstr = Console.ReadLine();
            bool validInput = isEmptyTryParse(idstr);
            while (validInput)
            {
                Console.Write("Please enter valid ID: ");
                idstr = Console.ReadLine();
                validInput = isEmptyTryParse(idstr);
            }

            id = int.Parse(idstr);
            bool idExists = list.Exists(e => e.Id == id);
            if (idExists == true)
            {
                double workingHours = 0.0;

                Console.Write("Enter Employee Name: ");
                string name = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(name))
                {
                    Console.Write("Please enter valid Name: ");
                    name = Console.ReadLine();
                }
                Console.Write("Enter number of Hours worked: ");

                string hours = Console.ReadLine();
                bool validHours = isEmptyTryParse(hours);
                while (validHours)
                {
                    Console.Write("Please enter valid number for hours: ");
                    hours = Console.ReadLine();
                    validHours = isEmptyTryParse(hours);
                }
                workingHours = double.Parse(hours);

                Console.Write("Enter hourly wage: ");
                string wagestr = Console.ReadLine();
                bool validWage = isEmptyTryParse(wagestr);
                while (validWage)
                {
                    Console.Write("Please enter valid number for wage: ");
                    wagestr = Console.ReadLine();
                    validWage = isEmptyTryParse(wagestr);
                }
                double wage = double.Parse(wagestr);

                var editableEmp = from e in list
                                  where e.EmployeeTypee == EmployeeType.HourlyEmployee && e.Id == id
                                  select e;

                foreach (var e in editableEmp)
                {
                    HourlyEmployee employee = (HourlyEmployee)e;
                    employee.EmployeeName = name;
                    employee.Hours = workingHours;
                    employee.Wage = wage;
                }
                Console.WriteLine();
                Console.WriteLine($"Employee with ID = {id} is updated.");
                Console.WriteLine();

                displayHourly(list);
                Console.WriteLine("Press any key to continue...");
                int choice = nextChoice(list);
                editEmployeeSubmenu(choice, list);
            }
            else
            {
                Console.WriteLine("Incorect ID!Please start again.");
                Console.WriteLine("Enter the type of employee you want to edit.");
                int choice = nextChoice(list);
                editEmployeeSubmenu(choice, list);
            }

        }

        public static void editCommissionEmployee(List<Employee> list)
        {
            Console.Clear();
            editMenu(list);
            displayComm(list);
            Console.WriteLine();
            Console.WriteLine("Editing Commission Employee");
            Console.WriteLine();

            Console.Write("Enter ID of employee you want to edit: ");
            string idstr = Console.ReadLine();
            bool validInput = isEmptyTryParse(idstr);
            while (validInput)
            {
                Console.Write("Please enter valid ID: ");
                idstr = Console.ReadLine();
                validInput = isEmptyTryParse(idstr);
            }

            int id = int.Parse(idstr);
            bool idExists = list.Exists(e => e.Id == id);
            if (idExists == true)
            {
                Console.Write("Enter Employee Name: ");
                string name = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(name))
                {
                    Console.Write("Please enter valid Name: ");
                    name = Console.ReadLine();
                }

                Console.Write("Enter Gross Sale: ");
                string gSaleStr = Console.ReadLine();
                bool validSale = isEmptyTryParse(gSaleStr);
                while (validSale)
                {
                    Console.Write("Please enter valid number for Gross Sale: ");
                    gSaleStr = Console.ReadLine();
                    validSale = isEmptyTryParse(gSaleStr);
                }
                double grossSale = double.Parse(gSaleStr);

                Console.Write("Enter Commission Rate(e.g: 10% as 10): ");
                string cRatestr = Console.ReadLine();
                bool validRate = isEmptyTryParse(cRatestr);
                while (validRate)
                {
                    Console.Write("Please enter valid number for Commission Rate: ");
                    cRatestr = Console.ReadLine();
                    validRate = isEmptyTryParse(cRatestr);
                }
                double commRate = double.Parse(cRatestr);

                var editableEmp = from e in list
                                  where e.EmployeeTypee == EmployeeType.CommissionEmployee && e.Id == id
                                  select e;

                foreach (var e in editableEmp)
                {
                    CommissionEmployee employee = (CommissionEmployee)e;
                    employee.EmployeeName = name;
                    employee.GrossSale = grossSale;
                    employee.CommissionRate = commRate;
                }
                Console.WriteLine();
                Console.WriteLine($"Employee with ID = {id} is updated.");
                Console.WriteLine();

                displayComm(list);
                Console.WriteLine("Press any key to continue...");
                int choice = nextChoice(list);
                editEmployeeSubmenu(choice, list);
            }
            else
            {
                Console.WriteLine("Incorect ID!Please start again.");
                Console.WriteLine("Enter the type of employee you want to edit.");
                int choice = nextChoice(list);
                editEmployeeSubmenu(choice, list);
            }
        }

        public static void editSalariedEmployee(List<Employee> list)
        {
            Console.Clear();
            editMenu(list);
            Console.WriteLine();
            displaySalr(list);
            Console.WriteLine();
            Console.WriteLine("Editing Salaried Employee");
            Console.WriteLine();

            Console.Write("Enter ID of employee you want to edit: ");
            string idstr = Console.ReadLine();
            bool validInput = isEmptyTryParse(idstr);
            while (validInput)
            {
                Console.Write("Please enter valid ID: ");
                idstr = Console.ReadLine();
                validInput = isEmptyTryParse(idstr);
            }

            int id = int.Parse(idstr);
            bool idExists = list.Exists(e => e.Id == id);
            if (idExists == true)
            {
                Console.WriteLine();
                Console.Write("Enter Employee Name: ");
                string name = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(name))
                {
                    Console.Write("Please enter valid Name: ");
                    name = Console.ReadLine();
                }

                Console.Write("Enter Salary: ");
                string salry = Console.ReadLine();
                bool validSalary = isEmptyTryParse(salry);
                while (validSalary)
                {
                    Console.Write("Please enter valid number for Salary: ");
                    salry = Console.ReadLine();
                    validSalary = isEmptyTryParse(salry);
                }
                double salary = double.Parse(salry);
                var editableEmp = from e in list
                                  where e.EmployeeTypee == EmployeeType.SalariedEmployee && e.Id == id
                                  select e;

                foreach (var e in editableEmp)
                {
                    SalariedEmployee employee = (SalariedEmployee)e;
                    employee.EmployeeName = name;
                    employee.FixedSalary = salary;
                }
                Console.WriteLine();
                Console.WriteLine($"Employee with ID = {id} is updated.");
                Console.WriteLine();

                displaySalr(list);
                Console.WriteLine("Press any key to continue...");
                int choice = nextChoice(list);
                editEmployeeSubmenu(choice, list);
            }
            else
            {
                Console.WriteLine("Incorect ID!Please start again.");
                Console.WriteLine("Enter the type of employee you want to edit.");
                int choice = nextChoice(list);
                editEmployeeSubmenu(choice, list);
            }

        }

        public static void editSalaryPlusComm(List<Employee> list)
        {
            Console.Clear();
            editMenu(list);
            Console.WriteLine();
            displaySalComm(list);
            Console.WriteLine();
            Console.WriteLine("Editing Salary Plus Commission Employee");
            Console.WriteLine();

            Console.Write("Enter ID of employee you want to edit: ");
            string idstr = Console.ReadLine();
            bool validInput = isEmptyTryParse(idstr);
            while (validInput)
            {
                Console.Write("Please enter valid ID: ");
                idstr = Console.ReadLine();
                validInput = isEmptyTryParse(idstr);
            }

            int id = int.Parse(idstr);
            bool idExists = list.Exists(e => e.Id == id);
            if (idExists == true)
            {
                Console.WriteLine();

                Console.Write("Enter Employee Name: ");
                string name = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(name))
                {
                    Console.Write("Please enter valid Name: ");
                    name = Console.ReadLine();
                }

                Console.Write("Enter Gross Sale: ");
                string gSaleStr = Console.ReadLine();
                bool validSale = isEmptyTryParse(gSaleStr);
                while (validSale)
                {
                    Console.Write("Please enter valid number for Gross Sale: ");
                    gSaleStr = Console.ReadLine();
                    validSale = isEmptyTryParse(gSaleStr);
                }
                double grossSale = double.Parse(gSaleStr);

                Console.Write("Enter Commission Rate(e.g: 10% as 10): ");
                string cRatestr = Console.ReadLine();
                bool validRate = isEmptyTryParse(cRatestr);
                while (validRate)
                {
                    Console.Write("Please enter valid number for Commission Rate: ");
                    cRatestr = Console.ReadLine();
                    validRate = isEmptyTryParse(cRatestr);
                }
                double commRate = double.Parse(cRatestr);

                Console.Write("Enter Salary: ");
                string salry = Console.ReadLine();
                bool validSalary = isEmptyTryParse(salry);
                while (validSalary)
                {
                    Console.Write("Please enter valid number for Salary: ");
                    salry = Console.ReadLine();
                    validSalary = isEmptyTryParse(salry);
                }
                double salary = double.Parse(salry);

                var editableEmp = from e in list
                                  where e.EmployeeTypee == EmployeeType.SalaryPlusCommissionEmployee && e.Id == id
                                  select e;

                foreach (var e in editableEmp)
                {
                    SalaryPlusCommissionEmployee employee = (SalaryPlusCommissionEmployee)e;
                    employee.EmployeeName = name;
                    employee.GrossSale = grossSale;
                    employee.CommissionRate = commRate;
                    employee.Salary = salary;

                }
                Console.WriteLine();
                Console.WriteLine($"Employee with ID = {id} is updated.");
                Console.WriteLine();

                displaySalComm(list);
                Console.WriteLine("Press any key to continue...");
                int choice = nextChoice(list);
                editEmployeeSubmenu(choice, list);
            }
            else
            {
                Console.WriteLine("Incorect ID!Please start again.");
                Console.WriteLine("Enter the type of employee you want to edit.");
                int choice = nextChoice(list);
                editEmployeeSubmenu(choice, list);
            }
        }

        public static void deleteEmployee(List<Employee> list)
        {
            Console.Clear();
            deleteMenu(list);
            Console.Write("Enter your choice: ");

            string inputValue = Console.ReadLine();
            bool checkValue = checkEmptyInput(inputValue);

            while (checkValue)
            {
                inputValue = Console.ReadLine();
                checkValue = checkEmptyInput(inputValue);
            }

            int choice = int.Parse(inputValue);
            deleteEmployeeSubmenu(choice, list);
        }

        public static void deleteMenu(List<Employee> list)
        {
            Console.WriteLine("Delete Employee:");
            Console.WriteLine("     1 - Delete Hourly Employee");
            Console.WriteLine("     2 - Delete Commission Employee");
            Console.WriteLine("     3 - Delete Salaried Employee");
            Console.WriteLine("     4 - Delete Salary + Commission Employee");
            Console.WriteLine("     5 - Back to Main Menu");
        }

        public static void deleteEmployeeSubmenu(int choice, List<Employee> list)
        {
            switch (choice)
            {
                case 1:
                    deleteHourlyEmployee(list);
                    break;
                case 2:
                    deleteCommissionEmployee(list);
                    break;
                case 3:
                    deleteSalariedEmployee(list);
                    break;
                case 4:
                    deleteSalaryPlusComm(list);
                    break;
                case 5:
                    backToMain(list);
                    break;
            }
        }

        public static void deleteHourlyEmployee(List<Employee> list)
        {
            Console.Clear();
            deleteMenu(list);
            Console.WriteLine();
            displayHourly(list);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Deleting Hourly Emplyee");
            Console.WriteLine();

            Console.Write("Enter ID of employee you want to delete: ");
            string idstr = Console.ReadLine();
            bool validInput = isEmptyTryParse(idstr);
            while (validInput)
            {
                Console.Write("Please enter valid ID: ");
                idstr = Console.ReadLine();
                validInput = isEmptyTryParse(idstr);
            }

            int id = int.Parse(idstr);
            Console.WriteLine();

            bool idExists = list.Exists(e => e.Id == id);
            if (idExists == true)
            {

                var deleteEmp = from e in list
                                where e.EmployeeTypee == EmployeeType.HourlyEmployee && e.Id == id
                                select e;

                int index = -1;
                foreach (var e in deleteEmp)
                {
                    index = list.IndexOf(e);
                }

                if (index >= 0)
                {
                    list.RemoveAt(index);
                }
                else
                {
                    Console.WriteLine("Please enter valid id of employee to be delted.");
                    Console.WriteLine("returning to Main Menu");
                    Console.Clear();
                    mainMenu(list);
                }

                Console.WriteLine();
                Console.WriteLine($"Employee with ID = {id} is Deleted.");
                Console.WriteLine();

                displayHourly(list);
                Console.WriteLine("Press any key to continue...");
            }
            else
            {
                Console.WriteLine("Incorect ID!Please start again.");
                Console.WriteLine("Enter the type of employee you want to delete.");
                int choice = nextChoice(list);
                deleteEmployeeSubmenu(choice, list);
            }

        }

        public static void deleteCommissionEmployee(List<Employee> list)
        {
            Console.Clear();
            deleteMenu(list);
            Console.WriteLine();
            displayComm(list);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Deleting Commission Emplyee");
            Console.WriteLine();

            Console.Write("Enter ID of employee you want to delete: ");
            string idstr = Console.ReadLine();
            bool validInput = isEmptyTryParse(idstr);
            while (validInput)
            {
                Console.Write("Please enter valid ID: ");
                idstr = Console.ReadLine();
                validInput = isEmptyTryParse(idstr);
            }

            int id = int.Parse(idstr);
            Console.WriteLine();

            bool idExists = list.Exists(e => e.Id == id);
            if (idExists == true)
            {
                var deleteEmp = from e in list
                                where e.EmployeeTypee == EmployeeType.CommissionEmployee && e.Id == id
                                select e;

                int index = -1;
                foreach (var e in deleteEmp)
                {
                    Console.WriteLine(e.Id);
                    index = list.IndexOf(e);
                    Console.WriteLine(index);
                }

                if (index >= 0)
                {
                    list.RemoveAt(index);
                }
                else
                {
                    Console.WriteLine("Please enter valid id of employee to be delted.");
                    Console.WriteLine("returning to Main Menu");
                    Console.Clear();
                    mainMenu(list);
                }

                Console.WriteLine();
                Console.WriteLine($"Employee with ID = {id} is Deleted.");
                Console.WriteLine();

                displayComm(list);
                Console.WriteLine("Press any key to continue...");
            }
            else
            {
                Console.WriteLine("Incorect ID!Please start again.");
                Console.WriteLine("Enter the type of employee you want to delete.");
                int choice = nextChoice(list);
                deleteEmployeeSubmenu(choice, list);
            }
        }

        public static void deleteSalariedEmployee(List<Employee> list)
        {
            Console.Clear();
            deleteMenu(list);
            Console.WriteLine();
            displaySalr(list);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Deleting Salaried Emplyee");
            Console.WriteLine();

            Console.Write("Enter ID of employee you want to delete: ");
            string idstr = Console.ReadLine();
            bool validInput = isEmptyTryParse(idstr);
            while (validInput)
            {
                Console.Write("Please enter valid ID: ");
                idstr = Console.ReadLine();
                validInput = isEmptyTryParse(idstr);
            }

            int id = int.Parse(idstr);
            Console.WriteLine();

            bool idExists = list.Exists(e => e.Id == id);
            if (idExists == true)
            {
                var deleteEmp = from e in list
                                where e.EmployeeTypee == EmployeeType.SalariedEmployee && e.Id == id
                                select e;

                int index = -1;
                foreach (var e in deleteEmp)
                {
                    index = list.IndexOf(e);
                }

                if (index >= 0)
                {
                    list.RemoveAt(index);
                }
                else
                {
                    Console.WriteLine("Please enter valid id of employee to be delted.");
                    Console.WriteLine("returning to Main Menu");
                    Console.Clear();
                    mainMenu(list);
                }

                Console.WriteLine();
                Console.WriteLine($"Employee with ID = {id} is Deleted.");
                Console.WriteLine();

                displaySalr(list);
                Console.WriteLine("Press any key to continue...");
            }
            else
            {
                Console.WriteLine("Incorect ID!Please start again.");
                Console.WriteLine("Enter the type of employee you want to delete.");
                int choice = nextChoice(list);
                deleteEmployeeSubmenu(choice, list);
            }
        }

        public static void deleteSalaryPlusComm(List<Employee> list)
        {
            Console.Clear();
            deleteMenu(list);
            Console.WriteLine();
            displaySalComm(list);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Deleting Salary Plus Employee");
            Console.WriteLine();

            Console.Write("Enter ID of employee you want to delete: ");
            string idstr = Console.ReadLine();
            bool validInput = isEmptyTryParse(idstr);
            while (validInput)
            {
                Console.Write("Please enter valid ID: ");
                idstr = Console.ReadLine();
                validInput = isEmptyTryParse(idstr);
            }

            int id = int.Parse(idstr);
            Console.WriteLine();

            bool idExists = list.Exists(e => e.Id == id);
            if (idExists == true)
            {
                var deleteEmp = from e in list
                                where e.EmployeeTypee == EmployeeType.SalaryPlusCommissionEmployee && e.Id == id
                                select e;

                int index = -1;
                foreach (var e in deleteEmp)
                {
                    index = list.IndexOf(e);
                }

                if (index >= 0)
                {
                    list.RemoveAt(index);
                }
                else
                {
                    Console.WriteLine("Please enter valid id of employee to be delted.");
                    Console.WriteLine("returning to Main Menu");
                    Console.Clear();
                    mainMenu(list);
                }

                Console.WriteLine();
                Console.WriteLine($"Employee with ID = {id} is Deleted.");
                Console.WriteLine();

                displaySalComm(list);
                Console.WriteLine("Press any key to continue...");
            }
            else
            {
                Console.WriteLine("Incorect ID!Please start again.");
                Console.WriteLine("Enter the type of employee you want to delete.");
                int choice = nextChoice(list);
                deleteEmployeeSubmenu(choice, list);
            }
        }

        public static void viewEmployee(List<Employee> list)
        {
            Console.Clear();
            Console.WriteLine("Hourly Employees:");
            Console.WriteLine();
            displayHourly(list);
            Console.WriteLine();
            Console.WriteLine("Salaried Employees:");
            Console.WriteLine();
            displaySalr(list);
            Console.WriteLine();
            Console.WriteLine("Commission Employees:");
            Console.WriteLine();
            displayComm(list);
            Console.WriteLine();
            Console.WriteLine("Salary Plus Commisson Employees:");
            Console.WriteLine();
            displaySalComm(list);
            Console.WriteLine();
            Console.Write("Press 1 to go to Main Menu: ");
            string input = Console.ReadLine();

            bool validInput = isEmptyTryParse(input);


            int intInput = 0;

            do
            {
                while (validInput)
                {

                    Console.WriteLine(validInput);
                    Console.Write("Incorrect input, Please enter 1 to go to Main Menu: ");
                    input = Console.ReadLine();
                    validInput = isEmptyTryParse(input);




                }
                intInput = int.Parse(input);


                if (intInput == 1)
                {

                    Console.Clear();
                    mainMenu(list);
                    break;
                }
                else
                {
                    validInput = true;

                }
            } while (validInput == true);
        }



        public static void searchEmployee(List<Employee> list)
        {
            Console.Clear();
            Console.WriteLine("Search Employee by Name. Partial matches can fetch results.");
            Console.Write("Enter Employee name to search: ");
            string name = Console.ReadLine();


            var emp = from e in list
                      where e.EmployeeName.ToUpper().Contains(name.ToUpper())
                      select e;


            ConsoleTable hourlyEmpTb = new ConsoleTable("Id", "Name", "Hours worked", "Hourly wage", "Gross Sale", "Tax(20%)", "Net Earnings");
            ConsoleTable salariedEmpTb = new ConsoleTable("Id", "Name", "Weekly Salary", "Gross Earnings", "Tax(20%)", "Net Earnings");
            ConsoleTable commEmpTb = new ConsoleTable("Id", "Name", "Gross Sale", "Commission Rate", "Gross Earnings", "Tax(20%)", "Net Earnings");
            ConsoleTable salPlCommEmpTb = new ConsoleTable("Id", "Name", "Gross Sale", "Commission Rate", "Fixed Salary", "Gross Earnings", "Tax(20%)", "Net Earnings");
            bool matchedHrly = false;
            bool matchedSal = false;
            bool matchedComm = false;
            bool matchedSalCom = false;

            if (list.Exists(e => e.EmployeeName.ToUpper().Contains(name.ToUpper())))
            {
                foreach (var e in emp)
                {

                    if (e.EmployeeTypee == EmployeeType.HourlyEmployee)
                    {
                        matchedHrly = true;
                        HourlyEmployee hourlyEmp = (HourlyEmployee)e;
                        hourlyEmpTb.AddRow(hourlyEmp.Id, hourlyEmp.EmployeeName, hourlyEmp.Hours, hourlyEmp.Wage, hourlyEmp.GrossEarnings().ToString("C"), hourlyEmp.Tax.ToString("C"), hourlyEmp.NetEarnings.ToString("C"));

                    }

                    if (e.EmployeeTypee == EmployeeType.SalariedEmployee)
                    {
                        matchedSal = true;
                        SalariedEmployee salEmp = (SalariedEmployee)e;
                        salariedEmpTb.AddRow(salEmp.Id, salEmp.EmployeeName, salEmp.FixedSalary, salEmp.GrossEarnings().ToString("C"), salEmp.Tax.ToString("C"), salEmp.NetEarnings.ToString("C"));
                    }

                    if (e.EmployeeTypee == EmployeeType.CommissionEmployee)
                    {
                        matchedComm = true;
                        CommissionEmployee comEmp = (CommissionEmployee)e;
                        commEmpTb.AddRow(comEmp.Id, comEmp.EmployeeName, comEmp.GrossSale, comEmp.CommissionRate.ToString("P"), comEmp.GrossEarnings().ToString("C"), comEmp.Tax.ToString("C"), comEmp.NetEarnings.ToString("C"));
                    }

                    if (e.EmployeeTypee == EmployeeType.SalaryPlusCommissionEmployee)
                    {
                        matchedSalCom = true;
                        SalaryPlusCommissionEmployee salComEmp = (SalaryPlusCommissionEmployee)e;
                        salPlCommEmpTb.AddRow(salComEmp.Id, salComEmp.EmployeeName, salComEmp.GrossSale, salComEmp.CommissionRate.ToString("P"), salComEmp.Salary, salComEmp.GrossEarnings().ToString("C"), salComEmp.Tax.ToString("C"), salComEmp.NetEarnings.ToString("C"));

                    }

                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("No employee(s) found based on search.");
                Console.WriteLine();
                Console.Write("Press 1 to go to Main Menu: ");
                string input = Console.ReadLine();

                bool validInput = isEmptyTryParse(input);
                Console.WriteLine(validInput);

                int intInput = 0;

                do
                {
                    while (validInput)
                    {

                        Console.WriteLine(validInput);
                        Console.Write("Incorrect input, Please enter 1 to go to Main Menu: ");
                        input = Console.ReadLine();
                        validInput = isEmptyTryParse(input);




                    }
                    intInput = int.Parse(input);


                    if (intInput == 1)
                    {
                        Console.WriteLine(intInput);
                        Console.Clear();
                        mainMenu(list);
                        break;
                    }
                    else
                    {
                        validInput = true;
                        Console.WriteLine("else +" + validInput);
                    }
                } while (validInput == true);

            }


            if (matchedComm)
            {
                Console.WriteLine();
                Console.WriteLine("View Matched Commission Employees:");
                Console.WriteLine();
                commEmpTb.Write(Format.MarkDown);
            }

            if (matchedSal)
            {
                Console.WriteLine();
                Console.WriteLine("View Matched Salaried Employees:");
                Console.WriteLine();
                salariedEmpTb.Write(Format.MarkDown);
            }

            if (matchedSalCom)
            {
                Console.WriteLine();
                Console.WriteLine("View Matched Salaried plus Commission Employees:");
                Console.WriteLine();
                salPlCommEmpTb.Write(Format.MarkDown);
            }

            if (matchedHrly)
            {
                Console.WriteLine();
                Console.WriteLine("View Matched Hourly Employees:");
                Console.WriteLine();
                hourlyEmpTb.Write(Format.MarkDown);
            }


        }

        public static void exit()
        {
            Environment.Exit(0);

        }

        public static void backToMain(List<Employee> list)
        {
            Console.Clear();
            mainMenu(list);
        }
    }
}