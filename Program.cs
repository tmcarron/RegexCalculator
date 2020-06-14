using System;
using System.Text.RegularExpressions;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Greeting the user with instruction
            Console.WriteLine("Please enter an arithmatic eqation");
            
            //Taking a user inputted string
            string input = Console.ReadLine();

                TheNumCruncher(input);
            
            

        }
        public static void TheNumCruncher(string initialEquation)
        {
            initialEquation = initialEquation.Replace(" ", "");

            //Checking user input against a regex format guide
            if (Regex.IsMatch(initialEquation, @"^[0-9]{1,}([+]|[-]|[*]|[/])[0-9]{1,}$"))
            {

                float num1 = 0;
                float num2 = 0;
                int charBookmark = 0;


                //Iterating through each character of the user-inputting string to determine the first character that doesn't have numerical value
                for (int i = 0; i < initialEquation.Length; i++)
                {
                    int numPlaceHolder = 0;
                    if (int.TryParse(initialEquation[i].ToString(), out numPlaceHolder) == false && initialEquation[i] != '.')
                    {
                        num1 = float.Parse(initialEquation.Substring(0, i));
                        charBookmark = i;
                        break;
                    }
                }

                //identifying the operator
                char operate = initialEquation[charBookmark];
                //getting the second operand
                num2 = float.Parse(initialEquation.Substring(charBookmark + 1));



                if (operate == '+')
                {
                    Console.WriteLine(num1 + num2);
                }
                else if (operate == '-')
                {
                    Console.WriteLine(num1 - num2);
                }
                else if (operate == '*')
                {
                    Console.WriteLine(num1 * num2);
                }
                else if (operate == '/')
                {
                    Console.WriteLine(num1 / num2);
                }

            }
            else
            {
                Console.WriteLine("Your equation wasn't formatted properly. Format example: x+y");
            }

        }
    }
}
