using System;
using System.Collections.Generic;
using System.Text;

namespace Converter.Units
{
    [Unit(nameof(LenghtUnit))]
    class Feet : LenghtUnit
    {
        protected override double UnitDevidedByMeter => 0.3048;

        public override string ToString()
        {
            return nameof(Feet);
        }
    }
}
