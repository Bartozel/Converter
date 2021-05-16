using Converter.Units;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Converter
{
    static class ConvertManager
    {
        private static Dictionary<string, double> prefixes;

        public static string Convert(string imput, string output)
        {
            FillPrefixes();
            if (!UnitesConvertible(imput, output))
                throw new Exception($"Choosen units are not convertible.");

            IUnit imputUnit = CreateUnitInstance(imput);
            IUnit outputUnit = CreateUnitInstance(output);

            var imputAmount = GetImputPrefixAmount(imput);
            double outputAmount = CalculateOutputAmount(imputAmount, imputUnit, outputUnit);
            var outputPrefixAmount = GetOutputPrefixAmount(output);
            var finAmount = outputAmount / outputPrefixAmount;

            return $"{imput} -> {finAmount} {output}";
        }

        private static bool UnitesConvertible(string imput, string output)
        {
            var imputUnitType = GetUnitName(imput);
            var outputUnitType = GetUnitName(output);

            return imputUnitType == outputUnitType;
        }

        private static double CalculateOutputAmount(double imputAmount, IUnit imputUnit, IUnit outputUnit)
        {
            if (imputUnit.ToString() == outputUnit.ToString())
                return imputAmount;

            var imputToMainUnit = (imputAmount + imputUnit.GetShift) * imputUnit.GetRation;
            double outputAmount = (imputToMainUnit / outputUnit.GetRation) + outputUnit.GetShift;
            return outputAmount;
        }

        private static IUnit CreateUnitInstance(string imput)
        {
            var type = GetClassInfo(imput);

            var newInstace = Activator.CreateInstance(type);

            if (newInstace != null && newInstace is IUnit)
                return newInstace as IUnit;
            else
                throw new Exception($"Invalid imput type = {type.Name}");
        }

        private static Type GetClassInfo(string s)
        {
            var imputs = s.Split(' ').ToList();
            var r = s;

            imputs.ForEach(x =>
            {
                if (double.TryParse(x, NumberStyles.Number, CultureInfo.InvariantCulture, out _))
                    r = r.Replace(x, "");

                else if (prefixes.Keys.Any(k => x.StartsWith(k)))
                    r = r.Replace(prefixes.Keys.FirstOrDefault(k => x.StartsWith(k)), "");
            });

            var existingUnitClases = GetUnitClasses();

            var res = existingUnitClases.FirstOrDefault(x => string.Compare(x.Name, r.Trim(), true) == 0) ?? throw new Exception($"Invalid imput type = {r}");

            return res;
        }

        private static IEnumerable<Type> GetUnitClasses()
        {
            var n = Assembly.GetExecutingAssembly()
                 .GetTypes()
                 .Where(x =>
                     x.IsClass &&
                     !x.IsAbstract &&
                     x.Namespace == "Converter.Units"
                 );

            return n;
        }

        private static double GetOutputPrefixAmount(string output)
        {
            var outputs = output.Split(' ').ToList();

            double res = 1;
            outputs.ForEach(x =>
            {
                res *= CountPrefix(output);
            });

            return res;
        }

        private static double GetImputPrefixAmount(string imput)
        {
            var imputs = imput.Split(' ').ToList();

            double res = 1;
            imputs.ForEach(x =>
            {
                if (double.TryParse(x, NumberStyles.Number, CultureInfo.InvariantCulture, out var r))
                    res *= r;
                else
                    res *= CountPrefix(x);
            });

            return res;
        }

        private static double CountPrefix(string imput)
        {
            var p = prefixes.Keys;
            var usedPref = p.FirstOrDefault(x => imput.StartsWith(x));
            var val = usedPref != null && prefixes.ContainsKey(usedPref) ? prefixes[usedPref] : 1;

            return val;
        }
        public static string GetUnitName(string imput)
        {
            var type = GetClassInfo(imput);
            if (type.GetCustomAttributes(typeof(UnitAttribute), true).FirstOrDefault() is UnitAttribute uAttr)
            {
                return uAttr.Name;
            }
            return type.Name;
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
