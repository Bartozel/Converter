using System;
using System.Collections.Generic;
using System.Text;

namespace Converter.Units
{
    class Celsium : TemperatureUnit
    {
        public override double GetShift => 0;

        protected override double UnitDevidedByCelsium => 1;

        public override string ToString()
        {
            return nameof(Celsium);
        }
    }
}
