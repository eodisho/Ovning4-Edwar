/*
 1. Skriv klart implementationen av ExamineList-metoden så att undersökningen blir
genomförbar.
2. När ökar listans kapacitet? (Alltså den underliggande arrayens storlek)
Svar: Kapaciteten ökar när listan fylls och det inte finns mer utrymme för att lägga till nya item i listan
3. Med hur mycket ökar kapaciteten?
Svar: Arrayens kapaciteten fördubblas i storlek (0, 4, 8, 16....268435456) till  minnt är ifylt och programmet krashar.
4. Varför ökar inte listans kapacitet i samma takt som element läggs till?
Svar: Det finns en bestämt list storlek. For att inte änvande mer minnes utryme än det behövs.
5. Minskar kapaciteten när element tas bort ur listan?
Svar: Nej, den minskas inte.
6. När är det då fördelaktigt att använda en egendefinierad array istället för en lista?
Svar: När man vet exakt hur många element som behovs.

Övning 3: ExamineStack()
1. Simulera ännu en gång ICA-kön på papper. Denna gång med en stack . Varför är det
inte så smart att använda en stack i det här fallet?
Svar: P.g.a att den tar bort den sista som som sätta sig in kön. 

Övning 4: CheckParanthesis()
1......Vilken datastruktur använder du?
Svar: Stack
 */

using System;
using System.Collections.Generic;
namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()[0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /// Switch statement C#: https://www.dotnetperls.com/string-switch
            /// Substring: https://www.dotnetperls.com/substring
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            bool choice = true;
            Console.WriteLine("Please choose one of the following options");
            Console.WriteLine("0 - Quit the program");
            Console.WriteLine("1 - Choose '+' and the name together to add a person");
            Console.WriteLine("2 - Choose '-' and the name together to remove a person");
            Console.WriteLine("3 - You must enter either '+' or '-'");

            List<string> theList = new List<string>();
            var capacity = -1; // initalize capacity -1
            do
            {

                Console.WriteLine();
                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1, input.Length - 1);

                switch (nav)
                {
                    case '+':
                        {
                            if (capacity <= 4)
                                theList.Add(value);
                            foreach (var item in theList)
                            {
                                Console.WriteLine($"name: {item}");
                            }
                            Console.WriteLine($"The capacity is: {theList.Capacity}");
                            break;
                        }

                    case '-':
                        {

                            // Testing the size of the list and see if it shrinks when we remove values from it
                            theList.Remove(value);
                            Console.WriteLine();
                            Console.WriteLine($"Item removed and the capacity is: {theList.Capacity}");
                            break;
                        }
                    case '0':
                        Main();
                        break;
                    default:
                        {
                            Console.WriteLine("You must  use only + or -, try again!");
                            Console.WriteLine();
                            break;
                        }
                }
            } while (choice);
        }


        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
        * Loop this method untill the user inputs something to exit to main menue.
        * Create a switch with cases to enqueue items or dequeue items
        * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
        */
            bool choice = true;
            Console.WriteLine("Please choose one of the following options");
            Console.WriteLine("0 - Quit the program");
            Console.WriteLine("1 - Enqueue an item");
            Console.WriteLine("2 - Enqueue and item");
            Console.WriteLine("3 - You must add a correct value");

            char yourChar = ' ';
            Queue<Customers> line = new Queue<Customers>();
            do
            {
                Console.WriteLine();
                Console.WriteLine("Please choose a number");

                yourChar = char.ToLower(Console.ReadKey().KeyChar);

                switch (yourChar)
                {
                    case '1':
                        {
                            Console.WriteLine();
                            Console.WriteLine("Enter a name to the queue");
                            line.Enqueue(new Customers { Name = Console.ReadLine() });
                            break;
                        }

                    case '2':
                        {
                            //Console.WriteLine("Enter a name to dequeue");
                            //var Customers = Console.ReadLine();   // this is not working
                            //line.Peek();
                            var Customers = line.Dequeue();
                            Console.WriteLine();
                            Console.WriteLine($"the name {Customers.Name} was removed from the queue");
                            break;
                        }
                    case '0':
                        Main();
                        break;
                    default:
                        {
                            Console.WriteLine("You must  enter a name to add or remove from the queue, try again!");
                            Console.WriteLine();
                            break;
                        }
                }
            } while (choice);
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
            bool choice = true;
            Console.WriteLine("Please choose one of the following options");
            Console.WriteLine("0 - Quit the program");
            Console.WriteLine("1 - Stack an item");
            Console.WriteLine("2 - Remove and item");
            Console.WriteLine("3 - Reverse a sting using the stack");
            Console.WriteLine("4 - You must add a correct value");

            // stack is known as FILO (First in Last out) data structure
            Stack<Customers> line = new Stack<Customers>();
            char yourChar = ' ';
            do
            {
                Console.WriteLine();
                Console.WriteLine("Please choose a number");

                yourChar = char.ToLower(Console.ReadKey().KeyChar);

                switch (yourChar)
                {
                    case '1':
                        {
                            Console.WriteLine();
                            Console.WriteLine("Enter a name to add to the stack");
                            line.Push(new Customers { Name = Console.ReadLine() });
                            line.Peek();
                            break;
                        }

                    case '2':
                        {
                            //Console.WriteLine("Enter a name to dequeue");
                            //var Customers = Console.ReadLine();   // this is not working
                            var customers = line.Pop();
                            Console.WriteLine();
                            Console.WriteLine($"the name {customers.Name} was removed from the stack");
                            line.Peek();
                            //while (line.Count > 0)
                            //{
                            //    customers = line.Pop();
                            //    Console.WriteLine(customers.Name);
                            //}
                            break;
                        }
                    case '3':
                        {
                            Console.WriteLine();
                            Console.WriteLine("Write a word to reverse");
                            string text = Console.ReadLine();
                            var stack = new Stack<char>();
                            foreach (char c in text)
                                stack.Push(c);
                            stack.Peek();
                            text = string.Empty;
                            while (stack.Count > 0)
                                text += stack.Pop();
                            Console.WriteLine(text);
                            break;
                        }
                    case '0':
                        Main();
                        break;
                    default:
                        {
                            Console.WriteLine("You must  enter a name, try again!");
                            Console.WriteLine();
                            break;
                        }
                }
            } while (choice);
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            Stack<char> buffer = new Stack<char>();
            Console.WriteLine("Type in the brackets you want check.");
            string Input = Console.ReadLine();
            bool result = IsValid(Input);
            if (result)
                Console.WriteLine("Yes, the brackets matched");
            else
                Console.WriteLine("No, the brackets did not match");

        }
        //The below code copied from: https://leetcode.com/problems/valid-parentheses/discuss/361216/c-solution-with-stack
        static bool IsValid(string input)
        {
            Stack<char> buffer = new Stack<char>();

            bool isValid = true;

            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case '(':
                    case '{':
                    case '[':
                    case '<':
                        // if opening bracket, just add it to the stack
                        buffer.Push(input[i]);
                        break;

                    case ')':
                        // if the stack has elements, pop the top; if matches the closing continue to next char; if doesn't match, it's not - the parenthesis are not matching
                        isValid = (buffer.Count > 0 && buffer.Pop() == '(');
                        break;

                    case '}':
                        // if the stack has elements, pop the top; if matches the closing continue to next char; if doesn't match, it's not - the parenthesis are not matching
                        isValid = (buffer.Count > 0 && buffer.Pop() == '{');
                        break;

                    case ']':
                        // if the stack has elements, pop the top; if matches the closing continue to next char; if doesn't match, it's not - the parenthesis are not matching
                        isValid = (buffer.Count > 0 && buffer.Pop() == '[');
                        break;
                    case '>':
                        // if the stack has elements, pop the top; if matches the closing continue to next char; if doesn't match, it's not - the parenthesis are not matching
                        isValid = (buffer.Count > 0 && buffer.Pop() == '<');
                        break;

                    default:
                        break;
                }

                if (!isValid) break; // if found non-matching brackets already, just leave
            }

            return isValid && buffer.Count == 0; // all brackets were found and there are no pending brackets in the stack
        }
    }

}


