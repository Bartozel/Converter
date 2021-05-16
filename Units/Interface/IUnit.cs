using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Converter
{
    public interface IUnit
    {
        double GetRation { get;}
        double GetShift { get; }
    }
}
