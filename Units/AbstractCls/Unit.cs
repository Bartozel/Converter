using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Converter.Units
{
    [Unit(nameof(Unit))]
    abstract class Unit : IUnit
    {
        public abstract double GetRation { get; }
        public abstract double GetShift { get; }


        public string GetUnitType<T>()
        {
            var uAttr = typeof(T).GetCustomAttributes(typeof(UnitAttribute), true).FirstOrDefault() as UnitAttribute;
            if (uAttr != null)
            {
                return uAttr.Name;
            }
            return string.Empty;
        }
    }
}
