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
    }
}
