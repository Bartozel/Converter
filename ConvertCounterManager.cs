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
    static class ConvertCounterManager
    {
        public static string GetConvertionResult(string input, string output)
        {
            if (!InstanceManager.UnitesConvertible(input, output))
                throw new Exception($"Choosen units are not convertible.");

            IUnit inputUnit = InstanceManager.CreateUnitInstance(input);
            IUnit outputUnit = InstanceManager.CreateUnitInstance(output);

            var inputAmount = ParserManager.GetInputAmount(input);
            double outputAmount = CalculateOutputAmount(inputAmount, inputUnit, outputUnit);
            var outputPrefixAmount = ParserManager.GetInputAmount(output);
            var finAmount = outputAmount / outputPrefixAmount;

            return $"{input} -> {finAmount} {output}";
        }

        private static double CalculateOutputAmount(double inputAmount, IUnit imputUnit, IUnit outputUnit)
        {
            if (imputUnit.ToString() == outputUnit.ToString())
                return inputAmount;

            var imputToMainUnit = (inputAmount + imputUnit.GetShift) * imputUnit.GetRation; //change from imput to main unit
            double outputAmount = (imputToMainUnit / outputUnit.GetRation) + outputUnit.GetShift; //change from main unit to output
            return outputAmount;
        }
    }
}
