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
        private CountDown? cd;
        private basicCountDown loggingCD = new basicCountDown(2,1,0);

        public override void OnInitializeMelon()
        {
            this.cd = new CountDown(0f, 1f, 10f, 0f, 60f);
            this.loggingCD.UnFreezeCD();
        }
        public override void OnUpdate()
        {
            if (cd != null)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    this.cd.UnFreezeCD();
                    //GameObject mill = GameObject.Find("Mill(Clone)");
                    //mill.gameObject.transform.localScale = new Vector3(10.0f, 1.0f, 2.0f);
                    //mill.name = "Heyyyy";
                    //Debug.Log("this is a message");
                    //MelonEvents.OnGUI.Subscribe(DrawFrozenText, 100);
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

        //public static void DrawFrozenText()
        //{
        //    GUI.Label(new Rect(20, 20, 1000, 200), "<b><color=cyan><size=100>Frozen</size></color></b>");
        //}

    }

    public class basicCountDown
    {
        private double value;
        private double decrease;
        private double minVal;
        private bool isOnGoing;

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

    public class CountDown 
    {

        // variables
        private double value;
        private double decrease;
        private double increase;
        private double minVal;
        private double step;
        private double maxVal;
        private bool isOnGoing;

        // the cd's max val is relative to other variables so it's set at the start
        public CountDown(double val, double dec,double inc, double min, double step)
        {
            this.value = val; // base value 0
            this.decrease = dec;// base value 1
            this.increase = inc;// base value 10
            this.minVal = min;// base value 0
            this.step = step;// base value 60
            this.maxVal = 6 * step;
            this.isOnGoing = false;
        }

        public void FreezeCD()
        {
            this.isOnGoing = false;
        }

        public void UnFreezeCD()
        { 
            this.isOnGoing = true; 
        }

        // how to decrease its value
        public void GoesDown(double time)
        {
            if (this.isOnGoing)
            {
                this.value = Math.Max(this.value - this.decrease * time, this.minVal);
            }
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
