using System;
using System.Collections.Generic;
using System.Text;

namespace Converter.Units
{
    [Unit(nameof(LenghtUnit))]
    abstract class LenghtUnit : Unit
    {
        protected abstract double UnitDevidedByMeter { get; }
        public override double GetShift => 0;
        public override double GetRation => UnitDevidedByMeter;
    }
}
