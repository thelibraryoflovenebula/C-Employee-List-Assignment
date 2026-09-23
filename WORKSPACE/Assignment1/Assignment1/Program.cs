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
            










            //RUNNING PROGRAM
            bool running = true;
            while (running)
            {
                Console.Clear();//clears console
                Console.WriteLine("Select a menu item:" +
                    "\n[A] Sort by employee name \t(asc)" +
                    "\n[B] Sort by employee number \t(asc)" +
                    "\n[C] Sort by employee pay rate \t(desc)" +
                    "\n[D] Sort by employee hours \t(desc)" +
                    "\n[E] Sort by employee gross pay\t (desc)" +
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







        /**
         * READ METHOD TO COUNT AND INSERT EMPLOYEES INTO ARRAY
         * ***has exception checking (try catch)
         * 
         * 
         * 
         */
        public void readEmployees()
        {
            try {
                StreamReader reader = new StreamReader(DATAFILE);
                while(!reader.EndOfStream)
                {
                    //columnAttribute = reader.ReadLine().Split(',');



                }



            } catch (Exception ex)
            {
                Console.Error.WriteLine("Error reading the file: " + ex.Message);
            }

        }

        public void readSize()
        {
            try
            {

            }catch(Exception ex)
            {
                Console.Error.WriteLine("Error reading the file: " + ex.Message);
            }
        }

        /**
         * PRINTS THE ARRAY OF EMPLOYEES CREATED BY THE READ METHOD
         */
        public void printEmployees()
        {

        }
    }
}
