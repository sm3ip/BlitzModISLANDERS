using System;
using System.Collections.Generic;
using System.Text;

namespace BlitzModIslanders
{
    public class GameCountDown : BasicCountdown
    {
        // variables
        protected double increase;
        protected double step;
        protected double maxVal;

        public GameCountDown() { 
            this.increase = 0;
            this.step = 0;
            this.maxVal = 0;
        }

        // the cd's max val is relative to other variables so it's set at the start
        public GameCountDown(double val, double dec, double inc, double min, double step, double toMax)
            : base(val,dec,inc)
        {
            this.minVal = min;// base value 0
            this.step = step;// base value 60
            this.maxVal = toMax * step;
        }

        //how to increase its value
        public void GoesUp()
        {
            if (this.isOnGoing)
            {
                this.value = Math.Min(this.value + this.increase, this.maxVal);
            }
        }

        public double GetCurrVal()
        {
            return this.value;
        }
    }
}
