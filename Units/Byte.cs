using System;
using System.Collections.Generic;
using System.Text;

namespace Converter.Units
{
    class Byte : DataUnit
    {
        protected override double HowManyInByte => 1;

        public override string ToString()
        {
            return nameof(Byte);
        }
    }
}
