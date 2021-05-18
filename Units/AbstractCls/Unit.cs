using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Converter.Units
{
    [Unit(nameof(Unit))]
    abstract class Unit : IUnit
    {
        /// <summary>
        /// How many times is 'main' unit in other units
        /// Implemented in Abs classes just to be clear what is main unit for specific unit type
        /// </summary>
        public abstract double GetRation { get; }

        /// <summary>
        /// Just for Temperature
        /// </summary>
        public abstract double GetShift { get; }
    }
}
