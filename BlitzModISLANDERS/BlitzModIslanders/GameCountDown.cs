using System;
using System.Collections.Generic;
using System.Text;

namespace BlitzModIslanders
{
    public class GameCountDown : BasicCountdown
    {
        // inherits the BasicCountdown class and adds the possibility to countUp (+ a maximum value)
        protected double increase;
        protected double step;
        protected double maxVal;

        public GameCountDown() { 
            // default constructor
            this.increase = 0;
            this.step = 0;
            this.maxVal = 0;
        }

        public GameCountDown(double val, double dec, double inc, double min, double step, double toMax)
            : base(val,dec,min)
        {
            // parameterized constructor which calls the base constructor as well
            this.increase = Math.Abs(inc);
            this.step = Math.Abs(step);
            this.maxVal = Math.Abs(toMax) * this.step;
        }

        public void GoesUp()
        {
            // increments the CountDown
            if (this.isOnGoing)
            {
                this.value = Math.Min(this.value + this.increase, this.maxVal);
            }
        }

        //getters
        public double getIncrease()
        {
            return this.increase;
        }

        public double getStep()
        {
            return this.step;
        }
        public double getMaxVal() 
        { 
            return this.maxVal; 
        }
    }
}
