using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static A1RamandeepDhaliwal.Employee;

namespace A1RamandeepDhaliwal
{
    public class HourlyEmployee : Employee
    {
        private double _hours;
        public double Hours
        {
            get { return _hours; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Hours must be greater than zero.");
                }
                else
                {
                    _hours = value;
                }

            }
        }

        private double _wage;
        public double Wage
        {
            get { return _wage; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Wage must be greater than zero.");
                }
                else
                {
                    _wage = value;
                }
            }
        }

        public HourlyEmployee(EmployeeType employeeType, string employeeName, double hours, double wage) : base(employeeType, employeeName)
        {
            Hours = hours;
            Wage = wage;
        }

        public override double GrossEarnings()
        {
            if (Hours <= 40)
            {
                return Hours * Wage;
            }
            else
            {
                return (40 * Wage) + ((Hours - 40) * (1.5 * Wage));
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"Hours Worked = {Hours,-10} Hourly Wage = {Wage.ToString("C"),-1}";
        }

    }
}
