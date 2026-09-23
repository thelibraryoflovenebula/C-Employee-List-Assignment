using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/** STATEMENT OF AUTHORSHIP
 * 
 * I, 000964569, Neil Patrick Olaires hereby declare that this
 * is my own work and i have not shared this work with anyone 
 * or have even used ai for this program
 */

namespace Assignment1
{
    internal class Employee
    {
        // ATTRIBUTES


        /// <summary>
        /// Employee name
        /// </summary>
        private string name;
        /// <summary>
        ///  Employee number
        /// </summary>
        private int number;
        /// <summary>
        /// Employee rate, pay
        /// </summary>
        private decimal rate;
        /// <summary>
        /// Number of hours employee works -> this is a double
        /// </summary>
        private double hours;





        //CONSTRUCTOR

        /// <summary>
        /// Constructor for employee
        /// 
        /// </summary>
        /// <param name="name"> name of the employee</param>
        /// <param name="number"> the employee id number</param>
        /// <param name="rate"> rate of their pay </param>
        /// <param name="hours">number of hours an employee works</param>
        public Employee(string name, int number, decimal rate, double hours)
        {
            this.name = name;
            if (number < 0)
            {
                this.number = number; //id cant be negative 
            }
            if (rate < 0) { 
                this.rate = rate; // rate cant be negative
            }
            if (hours < 0)
            {
                this.hours = hours; //hours cant be negative
            }
        }

        //GETTERS AND SETTERS 
        public double GetHours(){return this.hours;}
        public string GetName(){return this.name;}
        public decimal GetRate(){return this.rate;}

        public decimal GetGross()
        {
            if (this.hours > 40) // in the case of overtime
            {
                decimal overtimeHours = (decimal)(this.hours - 40)*(decimal)1.5; //store time and a half hours

                decimal normalGross = (decimal)this.hours * this.rate;
                decimal excessGross = overtimeHours * this.rate;
                return normalGross + excessGross;               //calculate normal gross and add excess gross for full gross


            } else               //under 40 hours
            {
                return this.rate * (decimal)this.hours;
            }
        }

        public void SetHours(double hours){this.hours = hours;}
        public void SetName(string name){this.name = name;}
        public void SetNumber(int number){this.number = number;}
        public void SetRate(decimal rate){this.rate = rate;}










        //TO STRING
        public override string ToString()
        {
            return "this is a normal to string";
        }



    }
}
