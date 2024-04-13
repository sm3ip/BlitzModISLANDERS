using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace BlitzModIslanders
{
    public class Blitz : MelonMod
    {
        private GameCountDown? cd;
        private basicCountDown loggingCD = new basicCountDown(2,1,0);

        public override void OnInitializeMelon()
        {
            this.cd = new GameCountDown(0f, 1f, 10f, 0f, 60f);
            this.loggingCD.UnFreezeCD();
        }
        public override void OnUpdate()
        {
            if (cd != null)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    this.cd.UnFreezeCD();
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    this.cd.GoesUp();
                }
                log("Countdown value : " + this.cd.GetCurrVal());
            }
        }

        public override void OnFixedUpdate()
        {
            if (this.cd != null)
            {
                this.cd.GoesDown(Time.deltaTime);   
            }
            if(this.loggingCD != null)
            {
                this.loggingCD.GoesDown(Time.deltaTime);
            }
        }

        public void log(string msg)
        {
            if(loggingCD != null && msg!=null)
            {
                if (loggingCD.isDead())
                {
                    this.LoggerInstance.Msg(msg);
                    this.loggingCD = new basicCountDown(2, 1, 0);
                    this.loggingCD.UnFreezeCD();
                }
            }
        }
    }

    public class basicCountDown
    {
        protected double value;
        protected double decrease;
        protected double minVal;
        protected bool isOnGoing;

        public basicCountDown()
        {
            this.value = 1;
            this.decrease = 1;
            this.minVal = 0;
            this.isOnGoing = false;
        }

        public basicCountDown(double val, double dec, double min)
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
            return this.value <= 0;
        }
    }

    public class GameCountDown : basicCountDown
    {

        // variables
        protected double increase;
        protected double step;
        protected double maxVal;

        public GameCountDown() { }

        // the cd's max val is relative to other variables so it's set at the start
        public GameCountDown(double val, double dec,double inc, double min, double step)
        {

            this.value = val; // base value 0
            this.decrease = dec;// base value 1
            this.increase = inc;// base value 10
            this.minVal = min;// base value 0
            this.step = step;// base value 60
            this.maxVal = 6 * step;
            this.isOnGoing = false;
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
