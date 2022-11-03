using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCoreDemo
{
    internal class Mouse
    {
        string shape;
        int size;
        string color;
        int weight;
        string confortability;

        public Mouse(string shape, int weight, int size, string color)
        {
            this.shape = shape;
            this.size = size;
            this.weight = weight;
            this.color = color;
            
        }

        public void DisplayShape() 
        {
            
            if (shape == "Ergonomic")
            {
                Console.WriteLine("Mouse is Ergonomic");
            }
            else if (shape == "Ambi")
            {
                Console.WriteLine("Mouse is Ambidextrous");
            }
            else 
            {
                Console.WriteLine("Mouse has different shape adjustments");
            }
        }

        public int GetWeight() 
        {
            return weight;
        }

        public int GetSize()
        {
            return size;
        }

        public string GetColor()
        { 
            return color;
        }

        public void SetWeight(int newWeight)
        {
            weight = newWeight;
        }

        public void SetSize(int newSize) 
        {
            size = newSize;
        }

        public void SetColor(string newColor)
        { 
            color = newColor;
        }

        public void ButtonClick(string clickedButton)
        {

            Console.WriteLine("Clicked button: " + clickedButton);

        }
    }
}
