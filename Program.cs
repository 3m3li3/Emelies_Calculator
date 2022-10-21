/** Jag har skapat en simpel miniräknare som kan räkna ut summan, division, multiplikation och
 * modulo mellan två tal, samt att kunna räkna ut arean för cirklar, rektanglar och trianglar. 
 * För att utöka miniräknaren, för att t.ex. kunna göra uträkningar med fler tal
 * hade jag (skapat ett regex för att kunna prioritera operatorerna). Vad gäller gränssnittet är jag nöjd men hade föredragit
 * en pilmeny istället för knappvalen som jag har nu. Då hade antalet knapptryck och "krångligheten" blivit mindre. 
 * Jag har valt att inte skapa egna klasser i detta projekt men hade en idé om att skapa egna klasser för t.ex. kunna 
 * kalla på metoder för att ändra färgen på texten därigenom istället för att skriva det i program, det hade gjort
 * att koden blir mer lättläst och inte lika kluddig av "onödiga" saker som bara styr det visuella.
 * Jag har fler kommentarer i själva koden om varför jag valt att göra på ett visst sätt och saker jag velat förbättra 
 * eller göra annorlunda **/


namespace Emelies_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //A list to store previous calculations
            List<string> previousCalculations = new List<string>();

            //Changing the window title to a suitable name
            Console.Title = "Console Calculator";

            //A do while loop if the user chooses to continue the program                     
            do
            {
                //Declaring the variables for calculations
                double number1 = 0;
                double number2 = 0;
                double result = 0;

                //Declaring the variables for "fun with circles etc.."
                double choice, r, l, w, b, h;
                double area = 0;

                //Clearing the console inbetween loops
                Console.Clear();

                //Changing the text-colour of "Console Calculator"
                Console.ForegroundColor = ConsoleColor.Yellow;

                //Welcome message
                Console.WriteLine("\t\t___________________________________");
                Console.WriteLine("   \n\t\t\tConsole Calculator  ");
                Console.WriteLine("\t\t___________________________________");

                //Changing the text-colour back to white 
                Console.ForegroundColor = ConsoleColor.White;

                //Calling menuOfChoices method to show the first menu
                menuOfChoices();

                //Changing the text-colour in to white 
                Console.ForegroundColor = ConsoleColor.White;
                string userChoice = Console.ReadLine();

                //Switch statement to hold the entire first menu
                switch (userChoice)
                {
                    case "1":
                        Console.Clear();
                        //Changing the text-colour in to white 
                        Console.ForegroundColor = ConsoleColor.White;
                        //Calling the method that asks the user to enter the first number                                                                     
                        Console.WriteLine("Enter a number: ");
                        number1 = ReadDouble();

                        //Calling the method that asks the user to enter the second number                     
                        Console.WriteLine("Enter another number: ");
                        number2 = ReadDouble();

                        //Calling method of choices to make with input numbers
                        menuOfOperators();

                        //Calling method of which operators to choose from
                        operators();

                        break;

                    case "2":
                        //Fixing, clearing the menu
                        Console.Clear();

                        //Changing the text-colour of "Fun with circles, rectangles and triangles"
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\t\t _______________________________________________");
                        Console.WriteLine("\n\t\t    Fun with circles, rectangles and triangles  ");
                        Console.WriteLine("\t\t _______________________________________________");
                        Console.Write("\n\n");

                        //Calling method to show menu of "fun with ..."
                        menuFunWith();

                        //Makes sure user input is a number and not another character.
                        choice = ReadDouble();
                        //If statement to make sure user can only make a choice from the menu
                        if ((choice > 3) || (choice <= 0))
                        {
                            Console.Clear();
                            Console.WriteLine("You have to choose a number from the menu (1-3).");
                            break;
                        }


                        /** I realize a nested switch inside another switch isn't alwasýs a good thing, 
                         * but so far I don't know of a better way of doing it and there are only three cases in this switch. 
                         * I tried to make a method of the whole switch but did not succeed.**/
                        switch (choice)
                        {
                            case 1:
                                //Asking the user to input a number to calculate the area of a circle
                                Console.Write("Enter radius of the circle: ");
                                //Calling method ReadDouble() to make sure user enters a number and not another character.
                                r = ReadDouble();
                                area = Math.PI * r * r;
                                //Declaring variable and saving result to list
                                var save = "Area of circle: " + Math.PI + " * " + r + " * " + r + " = " + area;
                                previousCalculations.Add(save);
                                break;
                            case 2:
                                //Asking the user to input a number to calculate the area of a rectangle
                                Console.Write("Enter length of the rectangle: ");
                                //Calling method ReadDouble() to make sure user enters a number and not another character.
                                l = ReadDouble();
                                Console.Write("Enter width of the rectangle: ");
                                //Calling method ReadDouble() to make sure user enters a number and not another character.
                                w = ReadDouble();
                                area = l * w;
                                //Saving result to list
                                save = "Area of rectangle: " + l + " * " + w + " = " + area;
                                previousCalculations.Add(save);
                                break;
                            case 3:
                                //Asking the user to input a number to calculate the area of a trangle
                                Console.Write("Enter the base of the triangle: ");
                                //Calling method ReadDouble() to make sure user enters a number and not another character.
                                b = ReadDouble();
                                Console.Write("Enter the hight of the triangle: ");
                                //Calling method ReadDouble() to make sure user enters a number and not another character.
                                h = ReadDouble();
                                area = .5 * b * h;
                                //Saving result to list
                                save = "Area of triangle: " + .5 + " * " + b + " * " + h + " = " + area;
                                previousCalculations.Add(save);
                                break;


                        }
                        //Fixing, clearing the menu & typing out the result of the calculation..
                        Console.Clear();
                        Console.Write("The area is : {0}\n", area);
                        break;


                    case "3":
                        //Clearing, fixing the menu
                        Console.Clear();
                        //Changing the text-colour of "List of previous calculations"
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\t\t ______________________________________");
                        Console.WriteLine("\n\t\t      List of previous calculations  ");
                        Console.WriteLine("\t\t ______________________________________");

                        //Changing the text-colour back to white 
                        Console.ForegroundColor = ConsoleColor.White;

                        //A foreach-loop to retrieve the calculations made in the program via the list
                        Console.WriteLine("\n");
                        foreach (var item in previousCalculations)
                        {
                            Console.WriteLine(item);

                        }

                        //If the user hasn't made a calculation yet, this message appears
                        if (previousCalculations.Count == 0)
                        {
                            Console.WriteLine("Nothing here yet, you have to perform a calculation first!");
                        }

                        Console.WriteLine("\nPress any key to continue..");
                        Console.ReadLine();
                        break;

                    //Exiting the program
                    case "4":
                        Console.Clear();
                        //Changing the text-colour in to White 
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Leaving the calculator..");
                        break;

                    //Default option to catch if the user enters an invalid option
                    default:
                        Console.Clear();
                        Console.WriteLine("You made an invalid option. You have to make a choise from the menu (1-4).");
                        break;
                }


                /**Methods, they are all whitin the while-loop, 
                 * therefor not placed at the very end of the program.**/

                //Method menuOfChoises() shows the first menu in program
                void menuOfChoices()
                {
                    Console.WriteLine("\n\nWhat would you like to do?");
                    Console.WriteLine("\nTo perform a calculation                          >press 1<");
                    Console.WriteLine("Fun with circles, rectangles and triangles        >press 2<");
                    Console.WriteLine("To see previous calculations                      >press 3<");
                    //Changing the text-colour in to red 
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("To exit the program                               >press 4<\n");
                }

                //Method menuOfOperators() shows user options with the two numbers they chose.
                void menuOfOperators()
                {
                    Console.WriteLine("\nWhat would you like to do with the two numbers?");
                    Console.WriteLine("+ : Add");
                    Console.WriteLine("- : Subtract");
                    Console.WriteLine("* : Multiply");
                    Console.WriteLine("/ : Divide");
                    Console.WriteLine("% : Modulo");
                    Console.Write("\nEnter an option ");
                }

                //Method operators() performs the calculation of chosen type
                void operators()
                {
                    switch (Console.ReadLine())

                    {
                        //Addition
                        case "+":
                            result = number1 + number2;
                            Console.Clear();
                            Console.WriteLine($"\n\nYour result: {number1} + {number2} = " + result);

                            //Saving the calculation to my list
                            var save = "Calculation: " + number1 + " + " + number2 + " = " + result;
                            previousCalculations.Add(save);
                            break;

                        //Subtraction
                        case "-":
                            result = number1 - number2;
                            Console.Clear();
                            Console.WriteLine($"Your result: {number1} - {number2} = " + result);

                            //Saving the calculation to my list
                            save = "Calculation: " + number1 + " - " + number2 + " = " + result;
                            previousCalculations.Add(save);
                            break;

                        //Multiplication
                        case "*":
                            result = number1 * number2;
                            Console.Clear();
                            Console.WriteLine($"Your result: {number1} * {number2} = " + result);

                            //Saving the calculation to my list
                            save = "Calculation: " + number1 + " * " + number2 + " = " + result;
                            previousCalculations.Add(save);
                            break;

                        //Division
                        case "/":
                            Console.Clear();

                            /*A while loop to catch if the user puts in 0 as a second number
                             *as you can't divide anything by 0. At first I had an if-else solution here but 
                             *decided on a while-loop since I want to give the user the option to enter the
                             second number directly instead of starting over*/
                            while (number2 == 0)
                            {
                                Console.WriteLine("You can't divide a number by 0, enter another number please:");
                                number2 = ReadDouble();
                            }
                            result = number1 / number2;

                            //Showing the result of division
                            Console.Write("Your result: {0} / {1} = {2}\n", number1, number2, number1 / number2);

                            //Saving the calculation to my list
                            save = "Calculation: " + number1 + " / " + number2 + " = " + result;
                            previousCalculations.Add(save);
                            break;

                        //Modulo
                        case "%":
                            Console.Clear();
                            result = number1 % number2;
                            Console.WriteLine($"Your result: {number1} % {number2} = " + result);

                            //Saving the calculation to my list
                            save = "Calculation: " + number1 + " % " + number2 + " = " + result;
                            previousCalculations.Add(save);
                            break;

                        // Default in case the user enters an invalid option, telling them to start over
                        default:
                            Console.WriteLine("That was not a valid option, you have to start over");
                            break;
                    }
                }


                /* A method using TryParse to make sure the user
                 * enters a number and not some other character. I could have used try-catch as a solution 
                 but decided om this because I thought it was cleaner*/
                double ReadDouble()
                {
                    double numberOne;
                    while (double.TryParse(Console.ReadLine(), out numberOne) == false)
                    {
                        Console.WriteLine("You have to enter a number, have another try: ");
                    }
                    return numberOne;
                }

                //Method of menu of "fun with..."
                void menuFunWith()
                {
                    //Changing the text-colour back to white
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("To calculate the area of a circle           >press 1< \n");
                    Console.Write("To calculate the area of a rectangle        >press 2< \n");
                    Console.Write("To calculate the area of a triangle         >press 3< \n\n");
                }


                //The do..while loop asking the user if they want to exit program or go at it again 
                Console.WriteLine("\n\nDo you want to go at it again or perhaps take a look at previous calculations?\n");
                //Changing the text-colour in to green
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Y = Yes, take me to the main menu");
                //Changing the text-colour in to red 
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("N = No, I would like to exit the program ");
                //Changing the text-colour back to white
                Console.ForegroundColor = ConsoleColor.White;
            } while (Console.ReadLine().ToUpper() == "Y");

            //Fixing, clearing the menu
            Console.Clear();

            //Changing the text-colour back to white
            Console.ForegroundColor = ConsoleColor.White;
            //Good Bye message
            Console.WriteLine("\n\nSad to see you go, bye!");

            Console.ReadKey();



        }
    }
}