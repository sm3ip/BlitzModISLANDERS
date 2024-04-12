using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using UnityEngine;

namespace BlitzMod
{
    public class Blitz :MelonMod
    {

    }

    public class CountDown : MelonMod
    {
        private double value = 0.0f;
        private double decrease = 1f;
        private double increase = 10f;
        private double minVal = 0.0f;
        private double step = 60f;
        private double maxVal;

        public override void OnInitializeMelon()
        {
            this.maxVal = 6 * step; 
        }

        public override void OnFixedUpdate()
        {
            GoesDown();
        }

        private void GoesDown()
        {
            this.value =  Math.Max(this.value - this.decrease * Time.fixedDeltaTime,this.minVal);
        }

        public void GoesUp()
        {
            this.value = Math.Min(this.value + this.increase, this.maxVal);
        }

    }
}
