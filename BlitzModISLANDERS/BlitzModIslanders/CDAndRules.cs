using System;
using System.Collections.Generic;
using System.Text;

namespace BlitzModIslanders
{
    public class CDAndRules : GameCountDown
    {
        // a decorator class that implements the GameCountDown class and adds the recon of multiplicators
        private TupleFloatInt[] _tupleFloatInts;
        private double[] _scoreLimits;

        public CDAndRules(TupleFloatInt[] tupleFloatInts, double val, double dec, double inc, double min, double step)
            : base(val, dec, inc, min, step, 0)
        {
            // main constructor calling the base one
            this._tupleFloatInts = tupleFloatInts;
            double tempMax = 0;
            this._scoreLimits = new double[this._tupleFloatInts.Length];
            for (int i = 0; i < this._tupleFloatInts.Length; i++)
            {
                // stores the upper score bound of each multiplicator (storing this data might prove useless)
                tempMax += this._tupleFloatInts[i].getFloatVal();
                this._scoreLimits[i] = step * tempMax;
            }
            this.maxVal = tempMax * step;
        }

        public int GetMulti()
        {
            // return the multiplier based on the current countDown's value
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

        
        //getters
        public double getMaxVal()
        {
            return this.maxVal;
        }

    }

}

