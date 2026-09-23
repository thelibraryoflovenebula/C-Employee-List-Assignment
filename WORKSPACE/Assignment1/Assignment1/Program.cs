using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/** STATEMENT OF AUTHORSHIP
 * 
 * I, 000964569, Neil Patrick Olaires hereby declare that this
 * is my own work and i have not shared this work with anyone 
 * or have even used ai for this program
 */

/** CHECK INS
 *  sept 22 3:01pm
 *  sept 23 12:30pm
 */

namespace Assignment1
{
    
    internal class Program
    {

        //store file path of .csv into string variable =
        const string DATAFILE = "employees.txt";

        //initialize employee array
        Employee[] employeeList;



        /** 
         * Main Method 
         * (association employee class [*])
         */
        static void Main(string[] args)
        {
            
            //part where you initialize array stuff









            //RUNNING PROGRAM
            bool running = true;
            while (running)
            {
                Console.Clear();//clears console
                Console.WriteLine("Select a menu item:" +
                    "\n[A] ↑ Sort by employee name" +
                    "\n[B] ↑ Sort by employee number " +
                    "\n[C] ↓ Sort by employee pay rate" +
                    "\n[D] ↓ Sort by employee hours" +
                    "\n[E] ↓ Sort by employee gross pay" +
                    "\n[X] Exit");

                //reads option input
                string option = Console.ReadLine();

                switch (option.ToUpper())
                {
                    //SORT NAME
                    case ("A"):
                        break;

                    //SORT NUMBER
                    case ("B"):
                        break;

                    //SORT PAYRATE
                    case ("C"):
                        break;

                    //SORT HOURS
                    case ("D"):
                        break;

                    //SORT GROSS PAY
                    case ("E"):
                        break;

                    //EXIT
                    case ("X"): 
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input... ");
                        break;

                }

                //after break, before while loops re-enters
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();


            }

            Console.WriteLine("Have a nice day!");
        }




    }
}




/** TO DO LIST
 * 1. Make formatted ToString for employee objects 
 * 2. (LEARN) insert information in .csv into array (multi dimensional array)
 * 3. Make print method for array
 * 4. (LEARN) sorting method(s) for each option 
 */




/**
 * Lab should have
 * 1. read method -> puts all info into array (exception check)
 * 2. sort method(s)
 * 3. main method is highly modularized
 */
