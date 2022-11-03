using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCoreDemo
{
    //class car with constructor for setting car parameters
    //parameter traveldistance
    //parameter age
    //parameter color
    //parameter number of passanger
    //parameter weight
    //method Move - write "Car is moving"
    //method Stop - "Car stopped"
    //method Steer with parameter direction (left,right) "Car steers left/right"
    //method GetCarAge returns the age of the car, -> color, numberOfpassnangers, weight, traveldistance
    //method ReColor -> changes the color of the car 
    public class Person
    {
        int age;
        string name;

        public Person(int age, string name)
        {
            this.age = age;
            this.name = name;
        }

        public void TalkSomething(string whatToTalk)
        {
            Console.WriteLine(whatToTalk);
        }

        public void RenameMe(string newName)
        {
            name = newName;
        }

        public void GetOlderBy(int byAge)
        {
            age = age + byAge;
        }

        public string GetName()
        {
            return name;
        }
    }
}
