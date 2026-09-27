/** VIEW CLASS
 * - all inputs are done in this class
 * 
 * 
 * STATEMENT OF AUTHORSHIP
 * 
 * I, 000964569, Neil Patrick Olaires hereby declare that this
 * is my own work and i have not shared this work with anyone 
 * or have even used ai for this program
 * 
 * 
 * SELECTION SORT METHOD USED : https://www.youtube.com/watch?v=EwjnF7rFLns
 * 
 */

/** CHECK INS
 *  sept 22 3:01pm
 *  sept 23 12:30pm
 *  sept 25 12:57am
 *  sept 26 9:42pm
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
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
                        sort("A", employeeList);
                        Console.WriteLine(">>> Table sorted by ascending names");
                        break;

                    //SORT NUMBER
                    case ("B"):
                        sort("B", employeeList);
                        Console.WriteLine(">>> Table sorted by ascending ID");
                        break;

                    //SORT PAYRATE
                    case ("C"):
                        sort("C", employeeList);
                        Console.WriteLine(">>> Table sorted by descending payrate");
                        break;

                    //SORT HOURS
                    case ("D"):
                        sort("D", employeeList);
                        Console.WriteLine(">>> Table sorted by descending hours ");
                        break;

                    //SORT GROSS PAY
                    case ("E"):
                        sort("E", employeeList);
                        Console.WriteLine(">>> Table sorted by descending gross pay ");
                        break;

                    //EXIT
                    case ("X"): 
                        running = false;
                        break;
                    default:
                        Console.WriteLine(">>> Invalid input... ");
                        break;

                }

                //after break, before while loops re-enters
                Console.WriteLine(">>> Press any key to continue...");
                Console.ReadKey();


            }

            Console.WriteLine("Have a nice day!");
        }


        /** READ METHOD
         * reads csv and initializes array needed to print employees
         * 
         *  PARAMETERS:
         *  - string DATAFILE -> the file of .csv empolees
         * 
         * helper functions:
         * 1. declareArray()
         * 2. parseTry()
         * 
         */
        public static void read(string DATAFILE)
        {
            StreamReader reader = null;

            //check if file exists
            if (File.Exists(DATAFILE))
            {
                declareArray(reader, DATAFILE);
                employeeList = new Employee[employeeSize];



                //array initialization of employee csv values
                reader = new StreamReader(File.OpenRead(DATAFILE));
                int count = 0;
                while (!reader.EndOfStream)        //UNTIL THE END OF THE FILE
                {
                    string line = reader.ReadLine(); //accesses a single line
                    var values = line.Split(','); //splits the single line into array by ','

                    string nameTemp =           values[0];
                    int numberTemp = 0;              //value1
                    decimal rateTemp = 0;            //value2
                    double hoursTemp= 0;            //value3

                    //INPUT VALIDATION FOR .csv FILE 
                    bool parseFail = false; //IF ANY PARSE ATTEMPTS FAIL, SWITCH THIS ON TO ADD ERROR

                    parseTry(values, out parseFail, out numberTemp, out rateTemp, out hoursTemp); // USING THE OUT KEYWORD TO PASS MANY LOOCAL VARIABLES, THIS IS NOT CHEATING I RESEARCHED THIS;SLDKFJS;DLFKJ

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

        /** DECLARE ARRAY METHOD 
         *  first helper method for read() method
         *  declares and initializes array size
         *  
         *  PARAM:
         *  - StreamReader reader -> reader object for reading
         *  - string DATAFILE -> the file of .csv empolees
         */
        private static void declareArray(StreamReader reader, string DATAFILE)
        {
            reader = new StreamReader(File.OpenRead(DATAFILE));
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine(); //accesses a single line
                employeeSize++;
            }
            reader.Close();
            
        }

        /** CSV ARRAY PARSING METHOD
         *  Attempts to parse string variables into designated value types,
         *  handles exceptions and boolean gates
         * 
         *  second helper method for read() method
         *  
         *  OUT -> researched for my method, i am unsure if it is allowed but it was needed
         *  due to modularization = returning many outputs and to work with local variables
         *  
         *  
         *  PARAM:
         *  - string[] values -> local string array for individual employee object, hosts all values
         *  - bool parseFail -> boolean gate for any tryParse failures, addition to catch Exception
         *  - int numberTemp -> temporary number variable
         *  - decimal rateTemp -> temporary rate variable
         *  - double hoursTemp -> temporary hours variable
         *  
         *  
         */
        private static void parseTry(string[] values, out bool parseFail, out int numberTemp, out decimal rateTemp, out double hoursTemp)
        {
            try
            {
                parseFail = false;

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


            } catch (Exception ex)
            {
                Console.Error.WriteLine("Error happened at: " + ex);
                parseFail = true;
                hoursTemp = 0;
                rateTemp = 0;
                numberTemp = 0;


            }
        }




        /** PRINT EMPLOYEE OBJECTS METHOD
         *  prints employee objects in table format,
         *  does not track sorting, only functions as print
         * 
         * 
         * PARAM:
         * - Employee[] list -> list of employee objects
         * 
         *  
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


        /** SORTING METHOD 
         *  Holds switch cases for desired sorting.
         *  Uses selection sort method and was learned by this video  (https://www.youtube.com/watch?v=EwjnF7rFLns)
         *  
         *  PARAM:
         *  - string option -> the choice for specific cases, doesn't need input validation
         *  - Employee[] list -> the designated array for employees to be sorted
         * 
         */
        public static void sort(string option, Employee[] list)
        {
            switch (option.ToUpper())
            {
                case "A": //name
                    for (int i = 0; i < list.Length; i++)
                    {
                        Employee min; //i
                        Employee temp; //j 

                        for (int j = i + 1; j < list.Length; j++)
                        {
                            int order = string.Compare(list[i].GetName(), list[j].GetName(), StringComparison.Ordinal); //https://learn.microsoft.com/en-us/dotnet/api/system.string.compare?view=net-10.0

                            if (order > 0)  // ASSCENDING
                            {
                                min = list[j];
                                temp = list[i];
                                list[i] = min;
                                list[j] = temp;
                            }
                        }
                    }
                    break;
                case "B": //number int
                    for (int i = 0; i < list.Length; i++)
                    {
                        int minTemp;
                        Employee min;
                        Employee temp;

                        for (int j = i + 1; j < list.Length; j++)
                        {
                            minTemp = list[i].GetNumber();
                            if (minTemp > list[j].GetNumber())  // ASSCENDING
                            {
                                min = list[j]; 
                                temp = list[i];
                                list[i] = min; 
                                list[j] = temp; 
                            }
                        }
                    }
                    break;
                case "C": //payrate decimal
                    for (int i = 0; i < list.Length; i++)
                    {
                        decimal minTemp;
                        Employee min;
                        Employee temp;

                        for (int j = i + 1; j < list.Length; j++)
                        {
                            minTemp = list[i].GetRate();
                            if (minTemp < list[j].GetRate()) // DESCENDING
                            {
                                min = list[j]; 
                                temp = list[i]; 
                                list[i] = min; 
                                list[j] = temp;
                            }
                        }
                    }
                    break;
                case "D": //hours double
                    for (int i = 0; i < list.Length; i++)
                    {
                        double minTemp;
                        Employee min;
                        Employee temp;

                        for (int j = i + 1; j < list.Length; j++)
                        {
                            minTemp = list[i].GetHours();
                            if (minTemp < list[j].GetHours())  // DESCENDING
                            {
                                min = list[j]; 
                                temp = list[i];
                                list[i] = min; 
                                list[j] = temp; 
                            }
                        }
                    }
                    break;
                case "E": //gross pay decimal
                    for (int i = 0; i < list.Length; i++)
                    {
                        decimal minTemp;
                        Employee min;
                        Employee temp;

                        for (int j = i + 1; j < list.Length; j++)
                        {
                            minTemp = list[i].GetGross();
                            if (minTemp < list[j].GetGross())  // DESCENDING
                            {
                                min = list[j];
                                temp = list[i];
                                list[i] = min;
                                list[j] = temp;
                            }
                        }
                    }
                    break;
            }
        }



    }
}




/** TO DO LIST
 * 1. ✓ Make formatted ToString for employee objects 
 * 2. ✓ (LEARN) insert information in .csv into array (multi dimensional array)
 * 3. ✓ Make print method for array
 * 4. ✓ (LEARN) sorting method(s) for each option 
 * 5. ✓ Make new print methods for sorted methods NOTNEEDED
 * 6. ✓ Modularize Read method
 * 7. ✓ Documentation
 */




/** NOTES FOR NEXT PATRICK
 * 
 * - sorting you just have to work on
 * - Selection method
 */
