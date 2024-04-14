using System;
using System.Collections.Generic;
using System.Text;

namespace BlitzModIslanders
{

    public class BasicCountdown
    {
        // basic class to implement the basic functionalities of a countdown 
        protected double value;
        protected double decrease;
        protected double minVal;
        protected bool isOnGoing;

        public BasicCountdown()
        {
            // default constructor
            this.value = 1;
            this.decrease = 1;
            this.minVal = 0;
            this.isOnGoing = false;
        }

        public BasicCountdown(double val, double dec, double min)
        {
            // parameterized constructor
            this.value = val;
            this.decrease = Math.Abs(dec); // gotta make sure we don't actually increment with this var
            this.minVal = min;
            this.isOnGoing = false;
        }

        public void GoesDown(double time)
        {
            // decrements the countdown, the parameter time should represent the amount of time between 2 calls (ex time.deltatime)
            if (this.isOnGoing && time>0)
            {
                this.value = Math.Max(this.value - this.decrease * time, this.minVal);
            }
        }

        public void FreezeCD()
        {
            // pauses the countdown
            this.isOnGoing = false;
        }

        public void UnFreezeCD()
        {
            // unpauses the countdown
            this.isOnGoing = true;
        }

        public bool isDead()
        {
            // checks if the countdown is over
            return this.value <= this.minVal;
        }


        //getters
        public double getDecrease()
        {
            return this.decrease;
        }

        public double getMin()
        {
            return this.minVal;
        }

        public double GetCurrVal()
        {
            return this.value;
        }

        public bool GetIsGoin()
        {
            return this.isOnGoing;
        }
    }
}
