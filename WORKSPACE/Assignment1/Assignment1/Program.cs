/** VIEW CLASS
 * - all inputs are done in this class
 * 
 * 
 * STATEMENT OF AUTHORSHIP
 * 
 * I, 000964569, Neil Patrick Olaires hereby declare that this
 * is my own work and i have not shared this work with anyone 
 * or have even used ai for this program
 */

/** CHECK INS
 *  sept 22 3:01pm
 *  sept 23 12:30pm
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    
    internal class Program
    {

        //store file path of .csv into string variable 
        const string DATAFILE = "employees.txt";

        
        /** Employee size for array
         *  Static
         */
        public static int employeeSize;

        //initialize employee array
        static Employee[] employeeList;



        /** Main Method
         *  
         * (association employee class [*])
         */
        static void Main(string[] args)
        {

            read(DATAFILE); //read and initalize size for array
            //while loop
            bool running = true;
            while (running)
            {
                Console.Clear();//clears console
                printEmployees(employeeList); //prints employees 
                Console.Write("Select a menu item:" + //prints menu
                    "\n[A] ↑ Sort by employee name" +
                    "\n[B] ↑ Sort by employee number " +
                    "\n[C] ↓ Sort by employee pay rate" +
                    "\n[D] ↓ Sort by employee hours" +
                    "\n[E] ↓ Sort by employee gross pay" +
                    "\n[X] Exit" +
                    "\n\n>>> ");

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


        /** read method
         * 
         * 
         */
        public static void read(string DATAFILE)
        {
            StreamReader reader = null;

            //check if file exists
            if (File.Exists(DATAFILE))
            {
                //array declaration
                reader = new StreamReader(File.OpenRead(DATAFILE));
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine(); //accesses a single line
                    employeeSize++;
                }
                reader.Close();
                employeeList = new Employee[employeeSize];


                //array initialization of employee csv values
                reader = new StreamReader(File.OpenRead(DATAFILE));
                int count = 0;
                while (!reader.EndOfStream)        //UNTIL THE END OF THE FILE
                {
                    string line = reader.ReadLine(); //accesses a single line
                    var values = line.Split(','); //splits the single line into array by ','

                    string nameTemp = values[0];
                    int numberTemp;
                    decimal rateTemp;
                    double hoursTemp;

                    //INPUT VALIDATION FOR .csv FILE 
                    bool parseFail = false; //IF ANY PARSE ATTEMPTS FAIL, SWITCH THIS ON TO ADD ERROR

                    //number parsing
                    if (!int.TryParse(values[1], out numberTemp))
                    {
                        parseFail = true;
                        numberTemp = 0;
                    }
                    //rate parsing
                    if (!decimal.TryParse(values[2], out rateTemp))
                    {
                        parseFail = true;
                        rateTemp = 0;
                    }
                    //hours parsing
                    if (!double.TryParse(values[3], out hoursTemp))
                    {
                        parseFail = true;
                        hoursTemp = 0;
                    }

                    if (parseFail)
                    {
                        nameTemp = nameTemp + " [error]";
                    }

                    employeeList[count] = new Employee(nameTemp, numberTemp, rateTemp, hoursTemp);
                    count++;
                }
                reader.Close();
            }   else {Console.WriteLine("The file doesn't exist");}
        }

        /** print employees method
         *  
         *  ONLY prints employees from array
         *  array must be initialized and properly done before printed
         */
        public static void printEmployees(Employee[] list)
        {
            Console.WriteLine("Employee Name \t\t Id \t\t Rate \t\t Hours \t\t Gross Pay");
            Console.WriteLine("___________________________________________________________________________________");
            foreach (Employee e in list)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("\n");
        }






    }
}




/** TO DO LIST
 * 1. ✓ Make formatted ToString for employee objects 
 * 2. ✓ (LEARN) insert information in .csv into array (multi dimensional array)
 * 3. ✓ Make print method for array
 * 4. (LEARN) sorting method(s) for each option 
 * 5. Make new print methods for sorted methods
 */




/**
 * Lab should have
 * 1. read method -> puts all info into array (exception check)
 * 2. sort method(s)
 * 3. main method is highly modularized
 */



/**
 * 
 * TYPES OF WAYS TO INITIALIZE ARRAY
string[] array = new string[2]; // creates array of length 2, default values
string[] array = new string[] { "A", "B" }; // creates populated array of length 2
string[] array = { "A" , "B" }; // creates populated array of length 2
string[] array = new[] { "A", "B" }; // creates populated array of length 2
string[] array = ["A", "B"]; // creates populated array of length 2
 */