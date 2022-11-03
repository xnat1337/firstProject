using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCoreDemo
{
    public class Calculator
    {
        string About = "This calculator was created by Nikolay Angelov";

        public string GetAboutInformation()
        {
            return About;
        }

        //Method, 2 input parameters, returns nothing - void
        public void Sum(int number1, int number2)
        {
            int result = number1 + number2;
            Console.WriteLine(result);
        }

        //Method, 2 input parameters, returns integer
        public int Sum2(int number1, int number2)
        {
            int result = number1 + number2;
            return result;
        }

        public void Sum3()
        {
            Console.WriteLine("NOTHING TO CALCULATE");
        }

        public string Sum4()
        {
            return "NOTHING TO CALCULATE";
        }

        public string Sum5(int number1, int number2)
        {
            int result = number1 + number2;
            return result.ToString();
        }

        public void Sum6(int number1, int number2, int number3)
        {
            int result = number1 + number2;
            Console.WriteLine(result);
        }
    }
}
