using System;
using System.Collections.Generic;
using System.Text;

namespace Converter.Units
{
    [Unit(nameof(DataUnit))]
    abstract class DataUnit : Unit
    {
        protected abstract double HowManyInByte { get; }
        public override double GetShift => 0;
        public override double GetRation => HowManyInByte;
    }
}
