using System;
using System.Collections.Generic;
using System.Text;

namespace Converter.Units
{
    class Fahrenheit : TemperatureUnit
    {
        public override double GetShift => -32;

        protected override double HowManyInCelsium => 0.55555555;

        public override string ToString()
        {
            return nameof(Fahrenheit);
        }
    }
}
