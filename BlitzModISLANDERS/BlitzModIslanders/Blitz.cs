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
        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                GameObject mill = GameObject.Find("Mill(Clone)");
                mill.gameObject.transform.localScale = new Vector3(10.0f, 1.0f, 2.0f);
                mill.name = "Heyyyy";
                Debug.Log("this is a message");
            }
        }

    }

    public class CountDown : MelonMod
    {

        //logging shit
        private static string CDTAG = "the countdown";
        //public static CountDown instance;
        // basic values to test implementation
        private double value = 0.0f;
        private double decrease = 1f;
        private double increase = 10f;
        private double minVal = 0.0f;
        private double step = 60f;
        private double maxVal;
        //private GameObject randoFolder;

        // the cd's max val is relative to other variables so it's set at the start
        public override void OnInitializeMelon()
        {
            //instance = this;
            this.maxVal = 6 * step;
            Debug.Log("THIS ISSSSS THE START");
            //randoFolder = GameObject.Find("Level");
        }

        // automatically goes down as time passes
        public override void OnFixedUpdate()
        {
            GoesDown();
            Debug.Log("please work");
            // console and GUI logging 
            //instance.LoggerInstance.Msg("HEYYYYYYYYYYYYYYYYYYY");
            //MelonEvents.OnGUI.Unsubscribe(DrawCDValue);
            //MelonEvents.OnGUI.Subscribe(DrawCDValue, 100);

        }

        // to test the build up
        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                this.GoesUp();
                // randoFolder.gameObject.name = "Hello";
            }
        }

        // public static void DrawCDValue()
        //{
        //    GUI.Label(new Rect(20, 20, 1000, 200), "<b><color=cyan><size=100>"+"HEYO"+"</size></color></b>");
        //}

        // how to decrease its value
        private void GoesDown()
        {
            this.value = Math.Max(this.value - this.decrease * Time.fixedDeltaTime, this.minVal);
        }

        //how to increase its value
        public void GoesUp()
        {
            this.value = Math.Min(this.value + this.increase, this.maxVal);
        }

    }



}
