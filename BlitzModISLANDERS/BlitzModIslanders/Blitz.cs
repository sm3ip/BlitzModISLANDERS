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
        // the mod's main class takes care of all the logical and engine based parts
        // the code in its current state is mainly for testing purposes
        private CDAndRules? cd;
        private TupleFloatInt[] scoresLimits = { new TupleFloatInt(1, 1), new TupleFloatInt(2, 1.5f), new TupleFloatInt(3, 2.5f), new TupleFloatInt(6, 1) };
        private BasicCountdown loggingCD = new BasicCountdown(2,1,0);

        public override void OnInitializeMelon()
        {
            // called when the mod is initialized
            this.cd = new CDAndRules(scoresLimits,0f, 1f, 10f, 0f, 60f);
            this.loggingCD.UnFreezeCD();
        }
        public override void OnUpdate()
        {
            // called at every frame
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
                log("Countdown value : " + this.cd.GetCurrVal() + " Multi X"+ this.cd.GetMulti());
            }
        }

        public override void OnFixedUpdate()
        {
            //called at fixed intervals 
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
            // class to log on fixed intervals decided by a basicCountdown object
            if(loggingCD != null && msg!=null)
            {
                if (loggingCD.isDead())
                {
                    this.LoggerInstance.Msg(msg);
                    this.loggingCD = new BasicCountdown(2, 1, 0);
                    this.loggingCD.UnFreezeCD();
                }
            }
        }

        public void CDInfoLogs()
        {
            // a big chunk of data for debugging
            if (cd != null)
            {
                Debug.Log("maxVal : " + this.cd.getMaxVal());
                Debug.Log("value : " + this.cd.GetCurrVal());
                Debug.Log("decrease : " + this.cd.getDecrease());
                Debug.Log("minVal : " + this.cd.getMin());
                Debug.Log("isonGoing : " + this.cd.GetIsGoin());
                Debug.Log("increase : " + this.cd.getIncrease());
                Debug.Log("step : " + this.cd.getStep());
            }
        }
    }
}
