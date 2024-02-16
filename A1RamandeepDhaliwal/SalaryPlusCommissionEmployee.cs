using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1RamandeepDhaliwal
{
    public class SalaryPlusCommissionEmployee : CommissionEmployee
    {
        private double _salary;
        public double Salary
        {
            get { return _salary; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Salary must be greater than zero.");
                }
                else
                {
                    _salary = value;
                }
            }
        }

        public SalaryPlusCommissionEmployee(EmployeeType employeeType, string employeeName, double grossSale, double commissionRate, double salary) : base(employeeType, employeeName, grossSale, commissionRate)
        {
            Salary = salary;
        }

        public override double GrossEarnings()
        {
            return Salary + base.GrossEarnings();
        }

        public override string ToString()
        {
            return base.ToString() + $"Salary = {Salary.ToString("C"),-10}";
        }
    }
}
