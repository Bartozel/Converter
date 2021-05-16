using System;
using System.Collections.Generic;
using System.Text;

namespace Converter.Units
{
    public class UnitAttribute : Attribute
    {
        public string Name { get; }
        public UnitAttribute(string name)
        {
            Name = name;
        }
    }
}
