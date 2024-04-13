using System;
using System.Collections.Generic;
using System.Text;

namespace BlitzModIslanders
{
    public class CDAndRules
    {
        private GameCountDown _cd;
        private TupleFloatInt[] _tupleFloatInts;
        private double[] _scoreLimits;

        public CDAndRules ( TupleFloatInt[] tupleFloatInts, double val, double dec, double inc, double min, double step)
        {
            this._tupleFloatInts = tupleFloatInts;
            double tempMax = 0;
            this._scoreLimits = new double[this._tupleFloatInts.Length];
            for (int i = 0; i < this._tupleFloatInts.Length; i++)
            {
                tempMax += this._tupleFloatInts[i].getFloatVal();
                this._scoreLimits[i] = step * tempMax;
            }

            this._cd = new GameCountDown(val,dec,inc,min,step,tempMax);
        }

        public void CDGoesUp()
        {
            this._cd.GoesUp();
        }

        public void CDGoesDown(double time)
        {
            this._cd.GoesDown(time);
        }

        public double GetCdVal()
        {
            return this._cd.GetCurrVal();
        }

        public void FreezeCD()
        {
            this._cd.FreezeCD();
        }

        public void UnFreezeCD()
        {
            this._cd.UnFreezeCD();
        }

        public void isDone()
        {
            this._cd.isDead();
        }

    }
}
