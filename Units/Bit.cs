﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Converter.Units
{
    class Bit : DataUnit
    {
        protected override double HowManyInByte => 0.125;

        public override string ToString()
        {
            return nameof(Bit);
        }
    }
}
