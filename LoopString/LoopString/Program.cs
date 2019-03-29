using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopString
{
    class Program
    {
        private static int readFromUser;

        static void Main(string[] args)
        {

            // Print out the prompt
            PrintPrompt();

            bool StopFlag = false;   // To decide if we should stop the program
      
            // we continue until your tell us to stop
            while (!StopFlag)
            {
               try
                {
                    readFromUser = int.Parse(Console.ReadLine());
                    //Console.WriteLine("1. User input: " + readFromUser);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Exception hanpended! Your input is wrong! Try again!");
                    PrintPrompt();
                    continue;
                }

                // According to user's choose, depatch to different function to perform the tasks
                switch (readFromUser)
                {
                    case 1:                       // if user choose "1", we call function to decide how much he/she should pay
                        {
                            DecideThePayment();
                            break;
                        }
                    case 2:
                        {
                            RepeatUsersInput();   // if user choose "2", we will ask more info and repeat it 10 times
                            break;
                        }
                    case 3:
                        {
                            PickUtThirdWord();   // if user choose "3", we ask more text, and pick ut the third word from the input.
                            break;
                        }
                    case 0:
                        {
                            Console.WriteLine("Stop the program!");
                            StopFlag = true;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Wrong choice! Try again!");
                            PrintPrompt();
                            break;
                        }
                }
            }
        }

        // Print out main menu and prompt user to make choice
        private static void PrintPrompt()
        {
            // Out put some text to tell user how to use this progrom.
            Console.WriteLine(" ");
            Console.WriteLine("============================== Start ============================================");
            Console.WriteLine("Please choose what to do:");
            Console.WriteLine("Type \"1\" to check how much you should pay.");
            Console.WriteLine("Type \"2\" System will repeat your input 10 times");
            Console.WriteLine("Type \"3\" and type in some word, program will parse and pick out the third word");
            Console.WriteLine("Type \"0\" to stop the program.");
            Console.WriteLine(" ");
        }
        // when this is invoked, we further ask the user to give his/her age,
        // according to the age, we decide how much he/she should pay
        public static void DecideThePayment()
        {
            int usersAge;
            Console.WriteLine("You have choosen 1 - Please type in your age: ");

            while (true)
            {
                try
                {
                    usersAge = int.Parse(Console.ReadLine());
                    //Console.WriteLine("The input age: ", usersAge);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Exception happened!, Your input is wrong! Try again!");
                    Console.WriteLine("Type in your age:");
                    continue;
                }
            }

            if (usersAge < 20)
            {
                Console.WriteLine("You are ungdom, for ungdom, price is: 80Kr.");
            }
            else if (usersAge > 64)
            {
                Console.WriteLine("You are pensionar, the price for pensionar is: 90Kr.");
            }
            else
            {
                Console.WriteLine("You need to pay the standard prise: 120Kr.");
            }

            //print out the prompt 
            Program.PrintPrompt();
        }

        // User choose 2, we further prompt user to type in some comment, and we print out users input repeatedly(10 times)
        public static void RepeatUsersInput()
        {
            Console.WriteLine("You have chosen 2 - Now please type in some comments");
            string userComments = Console.ReadLine();
            Console.WriteLine("Your comments is:");
            // Print users comments 10 times
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(userComments);
            }

            //Print the prompt
            Program.PrintPrompt();
        }

        // User chosen 3, we further prompt user to type in a string, 
        // we use 'd' as a dilimiter to split the string into sub-string
        // and print it out.  And pick up the 3rd sub-string and print it out
        public static void PickUtThirdWord()
        {
            Char dilimeter = ' ';
            while (true)
            {
                Console.WriteLine("Please type in some string.");
                String userString = Console.ReadLine();
                Console.WriteLine("You have typed in: " + userString);
                Console.WriteLine("System will divide your string into word, using the d as dilimiter");
                String[] subString = userString.Split(dilimeter);

                // Print out the words splited after the loop
                foreach (string st in subString)
                {
                    Console.WriteLine(st);
                }
                Console.WriteLine(" ");
                Console.WriteLine("The Third Word or \"Sub-String\" is: ");
                try
                {
                    Console.WriteLine(subString[2]);
                    break;
                }
                catch (System.IndexOutOfRangeException)
                {
                    Console.WriteLine("The string you typed in must contain more than 3 words. Your input is less than 3 words. Try again!");
                    continue;
                }
                catch (System.IO.IOException)
                {
                    Console.WriteLine("The string you typed in must contain more than 3 words. Your input is less than 3 words. Try again!");
                }
            }
        }

    }
}
