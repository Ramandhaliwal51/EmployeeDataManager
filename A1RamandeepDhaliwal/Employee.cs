using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace A1RamandeepDhaliwal
{
    public abstract class Employee
    {
        private static int uniqueId = 1;
        public enum EmployeeType { HourlyEmployee, CommissionEmployee, SalariedEmployee, SalaryPlusCommissionEmployee };

        private EmployeeType _employeeType;
        public EmployeeType EmployeeTypee
        {
            get { return _employeeType; }
            set { _employeeType = value; }
        }

        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _employeeName;
        public string EmployeeName
        {
            get { return _employeeName; }
            set { _employeeName = value; }
        }

        public Employee(EmployeeType employeeType, string employeeName)
        {
            EmployeeTypee = employeeType;
            Id = uniqueId++;
            EmployeeName = employeeName;
        }

        public abstract double GrossEarnings();

        public double Tax
        {
            get { return GrossEarnings() * 0.2; }
        }

        public double NetEarnings
        {
            get { return GrossEarnings() - Tax; }
        }

        public override string ToString()
        {
            return $"Id = {Id,-5} Name= {EmployeeName,-15}";
        }
    }
}
