using System;
using System.Collections.Generic;
using System.Text;

namespace BlitzModIslanders
{
    public class TupleFloatInt
    {
        private int _value;
        private float _floatValue;
        public TupleFloatInt(int value, float floatValue)
        {
            _value = Math.Abs(value);
            _floatValue = Math.Abs(floatValue);
        }

        //getters
        public int getIntVal() {  return _value; }
        public float getFloatVal() { return _floatValue;}

        //setters
        public void setIntVal(int value) {
            if (value < 0)
            {
                _value = value;
            }
        }
        public void setFloatVal(float value) {
            if (value > 0)
            {
                _floatValue = value;
            }
        }
    }
}
