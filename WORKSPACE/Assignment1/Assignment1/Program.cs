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
                    int numberTemp; //value1
                    decimal rateTemp; //value2
                    double hoursTemp; //value3

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

        public static void sort(string option, Employee[] list)
        {
            /**
             * 
             *   string nameTemp = values[0];
             *   int numberTemp; //value1
             *   decimal rateTemp; //value2
             *   double hoursTemp; //value3
             * 
             */
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
                case "D": ///hours double

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
 * 4. (LEARN) sorting method(s) for each option 
 * 5. Make new print methods for sorted methods
 */




/** NOTES FOR NEXT PATRICK
 * 
 * - sorting you just have to work on
 * - Selection method
 */
