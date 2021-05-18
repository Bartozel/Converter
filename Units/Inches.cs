using System;
using System.Collections.Generic;
using System.Text;

namespace Converter.Units
{
    [Unit(nameof(LenghtUnit))]
    class Inches : LenghtUnit
    {
        protected override double UnitDevidedByMeter => 0.0254;

        public override string ToString()
        {
            return nameof(Inches);
        }
    }
}
