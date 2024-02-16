using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1RamandeepDhaliwal
{
    public class SalariedEmployee : Employee
    {
        private double _fixedSalary;
        public double FixedSalary
        {
            get { return _fixedSalary; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Salary must be geater than zero.");
                }
                else
                {
                    _fixedSalary = value;
                }
            }
        }

        public SalariedEmployee(EmployeeType employeeType, string employeeName, double fixedSalary) : base(employeeType, employeeName)
        {
            FixedSalary = fixedSalary;
        }

        public override double GrossEarnings()
        {
            return _fixedSalary;
        }

        public override string ToString()
        {
            return base.ToString() + $"Weekly Salary = {FixedSalary.ToString("C"),-10}";
        }
    }
}
