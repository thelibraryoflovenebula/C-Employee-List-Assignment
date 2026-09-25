/** MODEL CLASS 
 * -class for employee objects
 * 
 * 
 * STATEMENT OF AUTHORSHIP
 * 
 * I, 000964569, Neil Patrick Olaires hereby declare that this
 * is my own work and i have not shared this work with anyone 
 * or have even used ai for this program
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class Employee
    {
    //ATTRIBUTES


        /** name variable*/
        private string name;
        /** employee number */
        private int number;
        /** employee rate */
        private decimal rate;
        /** number of hours an employee works */
        private double hours;

        /** constructor
         * 
         *      params:
         *      - numbers cant be negative
         *      
         *      
         *      name (string)= name of the employee
         *      number (int) = employee id number 
         *      rate (decimal) = rate of their pay
         *      hours (double) = number of hours an employee works
         */
        public Employee(string name, int number, decimal rate, double hours)
        {
            this.name = name;
            if (number >= 0)
            {
                this.number = number; //id cant be negative 
            }
            if (rate >= 0) { 
                this.rate = rate; // rate cant be negative
            }
            if (hours >= 0)
            {
                this.hours = hours; //hours cant be negative
            }
        }

    //METHODS

        /** getter for employee hours [returns, int employee hours]*/
        public double GetHours(){return this.hours;}

        public int GetNumber() { return this.number; }
        /** getter for employee name [returns, string employee name]*/
        public string GetName(){return this.name;}
        /** getter for employee rate [returns, decimal employee rate ]*/
        public decimal GetRate(){return this.rate;}

        /** getter and calculator for employee gross incoming  [returns, decimal employee gross income]*/
        public decimal GetGross()
        {
            if (this.hours > 40) // in the case of overtime
            {
                decimal overtimeHours = (decimal)(this.hours - 40)*(decimal)1.5; //store time and a half hours

                decimal normalGross = (decimal)40 * this.rate;
                decimal excessGross = overtimeHours * this.rate;
                return normalGross + excessGross;               //calculate normal gross and add excess gross for full gross


            } else               //under 40 hours
            {
                return this.rate * (decimal)this.hours;
            }
        }

        /** setter for employee hours */
        public void SetHours(double hours){this.hours = hours;}
        /** setter for employee name */
        public void SetName(string name){this.name = name;}
        /** setter for employee number */
        public void SetNumber(int number){this.number = number;}
        /** setter for employee rate  */
        public void SetRate(decimal rate){this.rate = rate;}

        /** ToString [returns, formatted string]*/
        public override string ToString()
        {
            return $"{name} \t\t {number} \t ${rate:f2} \t {hours:F2} \t\t ${this.GetGross():F0}";
        }



    }
}
