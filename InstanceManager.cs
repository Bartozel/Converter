using Converter.Units;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Converter
{
    static class InstanceManager
    {
         public static IUnit CreateUnitInstance(string imput)
        {
            var type = GetClassType(imput);

            var newInstace = Activator.CreateInstance(type);

            if (newInstace != null && newInstace is IUnit)
                return newInstace as IUnit;
            else
                throw new Exception($"Invalid imput type = {type.Name}");
        }

        public static Type GetClassType(string s)
        {
            var imputs = s.Split(' ').ToList();
            var parsedClassName = s;

            imputs.ForEach(x =>
            {
                if (double.TryParse(x, NumberStyles.Number, CultureInfo.InvariantCulture, out _))
                    parsedClassName = parsedClassName.Replace(x, "");

                else if (ParserManager.Prefixes.Keys.Any(k => x.StartsWith(k)))
                    parsedClassName = parsedClassName.Replace(ParserManager.Prefixes.Keys.FirstOrDefault(k => x.StartsWith(k)), "");
            });

            var existingUnitClases = GetUnitClasses();
            parsedClassName = parsedClassName.Trim();
            var res = existingUnitClases.FirstOrDefault(x => string.Compare(x.Name, parsedClassName, true) == 0) ?? throw new Exception($"Invalid imput type = {parsedClassName}");

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

        public static string GetUnitName(string imput)
        {
            var type = GetClassType(imput);
            if (type.GetCustomAttributes(typeof(UnitAttribute), true).FirstOrDefault() is UnitAttribute uAttr)
            {
                return uAttr.Name;
            }
            return type.Name;
        }

        public static bool UnitesConvertible(string imput, string output)
        {
            var imputUnitType = GetUnitName(imput);
            var outputUnitType = GetUnitName(output);

            return imputUnitType == outputUnitType;
        }
    }
}
