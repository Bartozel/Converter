using Converter.Units;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Converter
{
    static class ParserManager
    {
        public static Dictionary<string, double> Prefixes
        {
            get
            {
                if (prefixes == null)
                    FillPrefixes();

                return prefixes;
            }
        }
        private static Dictionary<string, double> prefixes;

        public static double GetInputAmount(string input)
        {
            var inputs = input.Split(' ').ToList();

            double res = 1;
            inputs.ForEach(x =>
            {
                if (double.TryParse(x, NumberStyles.Number, CultureInfo.InvariantCulture, out var r))
                    res *= r;
            });

            inputs.ForEach(x =>
            {
                res *= CountPrefix(x);
            });

            return res;
        }


        private static double CountPrefix(string input)
        {
            var p = Prefixes.Keys;
            var usedPref = p.FirstOrDefault(x => input.StartsWith(x));
            var val = usedPref != null ? Prefixes[usedPref] : 1;

            return val;
        }

        private static void FillPrefixes()
        {
            if (prefixes == null)
            {
                prefixes = new Dictionary<string, double>();
                prefixes["nano"] = 0.000000001;
                prefixes["mikro"] = 0.000001;
                prefixes["mili"] = 0.001;
                prefixes["centi"] = 0.01;
                prefixes["deci"] = 0.1;

                prefixes["deka"] = 10;
                prefixes["hekto"] = 100;
                prefixes["kilo"] = 1000;
                prefixes["mega"] = 1000000;
                prefixes["giga"] = 1000000000;
            }
        }
    }
}
