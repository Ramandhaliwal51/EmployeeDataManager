using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1RamandeepDhaliwal
{
    public class CommissionEmployee : Employee
    {
        private double _grossSale;
        public double GrossSale
        {
            get { return _grossSale; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Gross Sale must be greater than zero.");
                }
                else
                {
                    _grossSale = value;
                }
            }
        }

        private double _commissionRate;
        public double CommissionRate
        {
            get { return _commissionRate; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Commission Rate must be greater than zero.");
                }
                else
                {
                    _commissionRate = (value / 100);
                }
            }
        }

        public CommissionEmployee(EmployeeType employeeType, string employeeName, double grossSale, double commissionRate) : base(employeeType, employeeName)
        {
            GrossSale = grossSale;
            CommissionRate = commissionRate;
        }

        public override double GrossEarnings()
        {
            return GrossSale * (CommissionRate);
        }

        public override string ToString()
        {
            return base.ToString() + $"Gross Sale = {GrossSale.ToString("C"),-12} Commission Rate = {CommissionRate.ToString("P"),-12}";
        }
    }
}
