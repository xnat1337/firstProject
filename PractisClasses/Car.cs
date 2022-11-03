using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCoreDemo
{
    public class Car
    {
        int travelDistance;       
        int age;
        string color;
        int numberOfPassanger;
        int weight;

      
        public Car(int travelDistance, int age, string color, int numberOfPassanger, int weight) 
        {
            this.travelDistance = travelDistance;
            this.age = age;
            this.color = color;
            this.numberOfPassanger = numberOfPassanger;
            this.weight = weight;
            
        }

        public void CarMovе() 
        {
            Console.WriteLine("Car is moving.");
        }

        public void CarStop() 
        {
            Console.WriteLine("Car Stopped");
        }

        public void Steer(string direction)
        {
           
            
            if (direction == "left")
            {
                Console.WriteLine("Steer Left");
            }
            else 
            {
                Console.WriteLine("Steer Right");
            }

        }

        public int GetCarAge()
        {
            return age;
        }

        public string GetCarColor()
        {
            return color;
        }

        public int GetNumberOfPassangers()
        { 
            return numberOfPassanger;
        }

        public int GetWeight()
        {
            return weight;
        }

        public int GetTraveLdistance() 
        {
            return travelDistance;
        }

        public void SetColor(string newColor)
        {
            color = newColor;
                      
        }

        public void SetTravelDistance(string distance) 
        {
            travelDistance = Convert.ToInt32(distance);
        }

        public void SetTravelDistance(int distance) 
        {
             travelDistance = distance;          
        }

        public void SetCarAge(int newAge)
        {
            age = newAge;
        }



    }
}
