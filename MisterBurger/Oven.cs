using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisterBurger
{
    public class Oven
    {
        private List<Burger> burgers;
        public static int MAX_CAPACITY = 3;
        private bool powerStatus;

        public Oven()
        {
            burgers = new List<Burger>();
          
        }
        public void turnOn()
        {
            this.powerStatus = true;
        }
        public void turnOff()
        {
            this.powerStatus = false;
        }
        public async Task<int> startCooking()
        {
            if (!this.powerStatus)
            {
                return -1;
            }
            await Task.Delay(3000);
            foreach (Burger burger in burgers)
            {
                burger.cookingDone();
            }
            turnOff();
            return 1;
        }
        public bool getPowerStatus()
        {
            return this.powerStatus;
        }
        public bool addBurger(Burger burger)
        {
            if (this.burgers.Count >= Oven.MAX_CAPACITY)
            {
                return false;
            }
            this.burgers.Add(burger);
            return true;
        }
        public int countBurger()
        {
            return this.burgers.Count();
        }
        public List<Burger> getBurgers()
        {
            return this.burgers;
        }
    }
}
