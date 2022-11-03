using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SeleniumCoreDemo
{
    internal class Keyboard
    {
        string? keycap;
        string? brand;
        string? size;
        string? switches;
        int cost;
        string? color;
        int weight;



        //public Keyboard(string keycap, string brand, string size, string switches, int cost)
        //{
        // this.keycap = keycap;
        //this.brand = brand;
        // this.size = size;
        // this.switches = switches;
        //  this.cost = cost;
        // }


        public void SetKeycapType(string keycapType)
        {
            keycap = keycapType;
        }

        public void SetBrand(string brandType)
        {
            brand = brandType;
        }

        public void SetSize(string sizeType)
        {
            size = sizeType;
        }

        public void SetSwitches(string switchesType) 
        { 
            switches = switchesType;    
        }

        public void SetCost(int costAmount)
        { 
            cost = costAmount;
        }

        public void SetColor(string newColor) 
        {
            color = newColor;
        }

        public void SetWeight(int newWeight) 
        {
            weight = newWeight;
        }

        public string GetKecapType()
        {
            return keycap;
        }

        public string GetBrand()
        { 
            return brand; 
        }

        public string GetSize() 
        {
            return size;
        }

        public string GetSwitches() 
        {
            return switches;
        }

        public int GetCost() 
        {
            return cost;
        }

        public int GetWeight() 
        {
            return weight;
        }

        public string GetColor()
        {
            return color;
        }

        public void ButtonClick(string clickedButton)
        {

            Console.WriteLine("Clicked button: " + clickedButton);
            
        }
    }
}

