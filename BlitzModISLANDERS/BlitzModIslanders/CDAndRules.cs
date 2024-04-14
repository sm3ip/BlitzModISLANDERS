using System;
using System.Collections.Generic;
using System.Text;

namespace BlitzModIslanders
{
    public class CDAndRules : GameCountDown
    {
        private TupleFloatInt[] _tupleFloatInts;
        private double[] _scoreLimits;

        public CDAndRules(TupleFloatInt[] tupleFloatInts, double val, double dec, double inc, double min, double step)
            : base(val, dec, inc, min, step, 0)
        {
            this._tupleFloatInts = tupleFloatInts;
            double tempMax = 0;
            this._scoreLimits = new double[this._tupleFloatInts.Length];
            for (int i = 0; i < this._tupleFloatInts.Length; i++)
            {
                tempMax += this._tupleFloatInts[i].getFloatVal();
                this._scoreLimits[i] = step * tempMax;
            }
            this.maxVal = tempMax * step;
        }

        public int GetMulti()
        {
            double temp = this.GetCurrVal();
            for (int i = 0; i < this._tupleFloatInts.Length; i++)
            {
                temp -= this._tupleFloatInts[i].getFloatVal()*this.step;
                if (temp < 0)
                {
                    return this._tupleFloatInts[i].getIntVal();
                }
            }
            return this._tupleFloatInts[^1].getIntVal();
        }

        

        public double getMaxVal()
        {
            return this.maxVal;
        }

    }

}

