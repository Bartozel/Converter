using System;
using System.Collections.Generic;
using System.Text;

namespace Converter.Units
{
    [Unit(nameof(TemperatureUnit))]
    class Kelvin : TemperatureUnit
    {
        public override double GetShift => 273.15;
        protected override double UnitDevidedByCelsium => 1;

        public override string ToString()
        {
            return nameof(Kelvin);
        }
    }
}
