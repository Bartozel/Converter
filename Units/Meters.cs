using System;
using System.Collections.Generic;
using System.Text;

namespace Converter.Units
{
    [Unit(nameof(LenghtUnit))]
    class Meters : LenghtUnit
    {
        protected override double UnitDevidedByMeter => 1;

        public override string ToString()
        {
            return nameof(Meters);
        }
    }
}
