using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopString
{
    class Program
    {
        
        static void Main(string[] args)
        {
            // Print out the prompt
            PrintPrompt();

            bool StopFlag = false;   // To decide if we should stop the program
            int readFromUser;

            // we continue until user tell us to stop
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
        public static void PrintPrompt()
        {
            // Out put some text to tell user how to use this progrom.
            Console.WriteLine("\n");
            Console.WriteLine("============================== Start ============================================");
            Console.WriteLine("Please choose what to do:");
            Console.WriteLine("Type \"1\" to check how much you should pay.");
            Console.WriteLine("Type \"2\" and then type in comment, system will cat your comment 10 times to form a long string");
            Console.WriteLine("Type \"3\" and type in some word separated with space, program will parse and pick out the third word");
            Console.WriteLine("Type \"0\" to stop the program.");
            Console.WriteLine("\n");
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
            
            // According to user's age, we decide how much he/she should pay
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

            // One round is done, print out the main menu prompt 
            PrintPrompt();
        }

        // User string builder to repeat a substring N times to a long string
        // In C#, once a string created, it can not be changed. The string like the DateTime, when one want to
        // modify it, the corresponding function will return a new modified string. But with StringBuilder, one
        // can realize a dynamically changeable string which use the same memory block on the heap allocated for 
        // the string at the time delare the StringBuilder instance. 
        // But, if apppend less then 3 or 4 string, StringBuilder is slower. The stringBuilder is faster
        // when append more times.
        public static string StringRepeat(/*this*/ string input, int count)
        {
            if (!string.IsNullOrEmpty(input))
            {
                StringBuilder builder = new StringBuilder(input.Length * count); 
                for (int i = 0; i < count; i++)
                    builder.Append(input);
                //Console.WriteLine("DBG: In builder: " + builder.ToString());
                return builder.ToString();
               
            }

            return string.Empty;
        }

        // In C#, once a string is created, it can not be changed. The string like the DateTime, when one want to
        // modify it, the corresponding function will return a new modified string. 
        // Use string.Concat() and a for loop to repeat to append a string. We create 10 elements string array.
        // This might be little slower than the above function which use StringBuilder to realize a dynamic string.
        // 
        public static string StringRepeatN(string input, int count)
        {
            string[] userString = new string[count+1];    
            userString[0] = input;
            int i;
            for (i = 1; i < count; i++)
            {
                userString[i] = string.Concat(userString[i - 1], input); // input);  userComment); both work, because is passed by reference to func ?
                Console.WriteLine("DBG=>:" + userString[i]);
            }
            //Console.WriteLine("DBG=>: Concate with for loop result:" + userString[i-1] + "i = " + i);
            return userString[i-1];
        }

        // User choose 2, we further prompt user to type in some comment, and then we concatinate users
        // input 10 times to format a longer string to print it out.
        public static void RepeatUsersInput()
        {
           
            Console.WriteLine("You have chosen 2 - Now please type in some comments");
            string userComment;
            userComment = Console.ReadLine();
            Console.WriteLine("Your comments is:" + userComment);

            // Print the concatenated user comments. Here we try two differnet ways with two differnt functions.

            string finalString = StringRepeatN(userComment, 10);                // 1.) use Concat() and for loop
            Console.WriteLine("From string.Concat loop, The string x 10 is:" + finalString);

            string userString10 = StringRepeat(userComment, 10);                // 2.) use StringBuilder to realize dynamic
            Console.WriteLine("From StringBuilder,      The string x 10 is:" + userString10);

            // This round is finished, we start over again, print the main menu prompt
            PrintPrompt();
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
