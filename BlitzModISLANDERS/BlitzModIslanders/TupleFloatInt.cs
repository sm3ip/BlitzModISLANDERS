using System;
using System.Collections.Generic;
using System.Text;

namespace BlitzModIslanders
{
    public class TupleFloatInt
    {
        // simple class to store a positive float and a positive int
        private int _intValue;
        private float _floatValue;
        public TupleFloatInt(int intValue, float floatValue)
        {
            _intValue = Math.Abs(intValue);
            _floatValue = Math.Abs(floatValue);
        }

        //getters
        public int getIntVal() {  return _intValue; }
        public float getFloatVal() { return _floatValue;}

        //setters
        public void setIntVal(int value) {
            if (value >= 0) // guard to keep the value positive
            {
                _intValue = value;
            }
        }
        public void setFloatVal(float value) {
            if (value >= 0) // guard to keep the value positive
            {
                _floatValue = value;
            }
        }
    }
}
