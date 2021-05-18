using System;
using System.Collections.Generic;
using System.Text;

namespace Converter.Units
{
    [Unit(nameof(TemperatureUnit))]
    abstract class TemperatureUnit : Unit
    {
        protected abstract double UnitDevidedByCelsium { get; }
        public override double GetRation => UnitDevidedByCelsium;
    }
}
