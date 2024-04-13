using System;
using System.Collections.Generic;
using System.Text;

namespace BlitzModIslanders
{
    public class BasicCountdown
    {
        protected double value;
        protected double decrease;
        protected double minVal;
        protected bool isOnGoing;

        public BasicCountdown()
        {
            this.value = 1;
            this.decrease = 1;
            this.minVal = 0;
            this.isOnGoing = false;
        }

        public BasicCountdown(double val, double dec, double min)
        {
            this.value = val;
            this.decrease = dec;
            this.minVal = min;
            this.isOnGoing = false;
        }

        public void GoesDown(double time)
        {
            if (this.isOnGoing)
            {
                this.value = Math.Max(this.value - this.decrease * time, this.minVal);
            }
        }

        public void FreezeCD()
        {
            this.isOnGoing = false;
        }

        public void UnFreezeCD()
        {
            this.isOnGoing = true;
        }

        public bool isDead()
        {
            return this.value <= this.minVal;
        }
    }
}
