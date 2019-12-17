using System;
using System.Collections.Generic;
using System.Text;

namespace MisterBurger
{
    public class Burger
    {
        private string title;
        private double price;
        private bool coocked;

        public Burger(string title, double price)
        {
            this.title = title;
            this.price = price;
        }

        public string getTitle()
        {
            return this.title;
        }
        public double getPrice()
        {
            return this.price;
        }
        public bool isCoocked()
        {
            return this.coocked;
        }
        public void cookingDone()
        {
            this.coocked = true;
        }
    }
}
