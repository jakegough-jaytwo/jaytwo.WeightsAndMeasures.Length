using System;

namespace jaytwo.WeightsAndMeasures
{
    // as defined in the NIST Handbook 44
    // https://nvlpubs.nist.gov/nistpubs/hb/2019/NIST.HB.44-2019.pdf
    // page C-8

    internal static class LengthConverter
    {
        private const decimal MillimetersPerInch = 25.4m;
        private const decimal MillimetersPerFoot = MillimetersPerInch * InchesPerFoot;
        private const decimal MillimetersPerYard = MillimetersPerInch * InchesPerYard;
        private const decimal MillimetersPerMile = MillimetersPerInch * InchesPerMile;
        private const int MillimetersPerCentimeter = 10;
        private const int MillimetersPerMeter = 1000;
        private const int MillimetersPerKilometer = MillimetersPerMeter * MetersPerKilometer;

        private const decimal CentimetersPerInch = 2.54m;
        private const decimal CentimetersPerFoot = CentimetersPerInch * InchesPerFoot;
        private const decimal CentimetersPerYard = CentimetersPerInch * InchesPerYard;
        private const decimal CentimetersPerMile = CentimetersPerInch * InchesPerMile;
        private const int CentimetersPerMeter = 100;
        private const int CentimetersPerKilometer = CentimetersPerMeter * MetersPerKilometer;

        private const decimal MetersPerInch = 0.0254m;
        private const decimal MetersPerFoot = MetersPerInch * InchesPerFoot;
        private const decimal MetersPerYard = MetersPerInch * InchesPerYard;
        private const decimal MetersPerMile = MetersPerInch * InchesPerMile;
        private const int MetersPerKilometer = 1000;

        private const decimal KilometersPerInch = MetersPerInch / MetersPerKilometer;
        private const decimal KilometersPerFoot = KilometersPerInch * InchesPerFoot;
        private const decimal KilometersPerYard = KilometersPerInch * InchesPerYard;
        private const decimal KilometersPerMile = KilometersPerInch * InchesPerMile;

        private const int InchesPerFoot = 12;
        private const int InchesPerYard = InchesPerFoot * FeetPerYard;
        private const int InchesPerMile = InchesPerFoot * FeetPerMile;

        private const int FeetPerYard = 3;
        private const int FeetPerMile = FeetPerYard * YardsPerMile;

        private const int YardsPerMile = 1760;

        public static decimal ToMillimeters(decimal value, LengthUnit units)
        {
            switch (units)
            {
                case LengthUnit.Millimeters:
                    return value;
                case LengthUnit.Centimeters:
                    return value * MillimetersPerCentimeter;
                case LengthUnit.Meters:
                    return value * MillimetersPerMeter;
                case LengthUnit.Kilometers:
                    return value * MillimetersPerKilometer;
                case LengthUnit.Inches:
                    return value * MillimetersPerInch;
                case LengthUnit.Feet:
                    return value * MillimetersPerFoot;
                case LengthUnit.Yards:
                    return value * MillimetersPerYard;
                case LengthUnit.Miles:
                    return value * MillimetersPerMile;
            }

            throw new InvalidOperationException($"Cannot convert unit {units} to {nameof(LengthUnit.Millimeters)}");
        }

        public static decimal ToCentimeters(decimal value, LengthUnit units)
        {
            switch (units)
            {
                case LengthUnit.Millimeters:
                    return value / MillimetersPerCentimeter;
                case LengthUnit.Centimeters:
                    return value;
                case LengthUnit.Meters:
                    return value * CentimetersPerMeter;
                case LengthUnit.Kilometers:
                    return value * CentimetersPerKilometer;
                case LengthUnit.Inches:
                    return value * CentimetersPerInch;
                case LengthUnit.Feet:
                    return value * CentimetersPerFoot;
                case LengthUnit.Yards:
                    return value * CentimetersPerYard;
                case LengthUnit.Miles:
                    return value * CentimetersPerMile;
            }

            throw new InvalidOperationException($"Cannot convert unit {units} to {nameof(LengthUnit.Centimeters)}");
        }

        public static decimal ToMeters(decimal value, LengthUnit units)
        {
            switch (units)
            {
                case LengthUnit.Millimeters:
                    return value / MillimetersPerMeter;
                case LengthUnit.Centimeters:
                    return value / CentimetersPerMeter;
                case LengthUnit.Meters:
                    return value;
                case LengthUnit.Kilometers:
                    return value * MetersPerKilometer;
                case LengthUnit.Inches:
                    return value * MetersPerInch;
                case LengthUnit.Feet:
                    return value * MetersPerFoot;
                case LengthUnit.Yards:
                    return value * MetersPerYard;
                case LengthUnit.Miles:
                    return value * MetersPerMile;
            }

            throw new InvalidOperationException($"Cannot convert unit {units} to {nameof(LengthUnit.Meters)}");
        }

        public static decimal ToKilometers(decimal value, LengthUnit units)
        {
            switch (units)
            {
                case LengthUnit.Millimeters:
                    return value / MillimetersPerKilometer;
                case LengthUnit.Centimeters:
                    return value / CentimetersPerKilometer;
                case LengthUnit.Meters:
                    return value / MetersPerKilometer;
                case LengthUnit.Kilometers:
                    return value;
                case LengthUnit.Inches:
                    return value * KilometersPerInch;
                case LengthUnit.Feet:
                    return value * KilometersPerFoot;
                case LengthUnit.Yards:
                    return value * KilometersPerYard;
                case LengthUnit.Miles:
                    return value * KilometersPerMile;
            }

            throw new InvalidOperationException($"Cannot convert unit {units} to {nameof(LengthUnit.Kilometers)}");
        }

        public static decimal ToInches(decimal value, LengthUnit units)
        {
            switch (units)
            {
                case LengthUnit.Millimeters:
                    return value / MillimetersPerInch;
                case LengthUnit.Centimeters:
                    return value / CentimetersPerInch;
                case LengthUnit.Meters:
                    return value / MetersPerInch;
                case LengthUnit.Kilometers:
                    return value / KilometersPerInch;
                case LengthUnit.Inches:
                    return value;
                case LengthUnit.Feet:
                    return value * InchesPerFoot;
                case LengthUnit.Yards:
                    return value * InchesPerYard;
                case LengthUnit.Miles:
                    return value * InchesPerMile;
            }

            throw new InvalidOperationException($"Cannot convert unit {units} to {nameof(LengthUnit.Inches)}");
        }

        public static decimal ToFeet(decimal value, LengthUnit units)
        {
            switch (units)
            {
                case LengthUnit.Millimeters:
                    return value / MillimetersPerFoot;
                case LengthUnit.Centimeters:
                    return value / CentimetersPerFoot;
                case LengthUnit.Meters:
                    return value / MetersPerFoot;
                case LengthUnit.Kilometers:
                    return value / KilometersPerFoot;
                case LengthUnit.Inches:
                    return value / InchesPerFoot;
                case LengthUnit.Feet:
                    return value;
                case LengthUnit.Yards:
                    return value * FeetPerYard;
                case LengthUnit.Miles:
                    return value * FeetPerMile;
            }

            throw new InvalidOperationException($"Cannot convert unit {units} to {nameof(LengthUnit.Feet)}");
        }

        public static decimal ToYards(decimal value, LengthUnit units)
        {
            switch (units)
            {
                case LengthUnit.Millimeters:
                    return value / MillimetersPerYard;
                case LengthUnit.Centimeters:
                    return value / CentimetersPerYard;
                case LengthUnit.Meters:
                    return value / MetersPerYard;
                case LengthUnit.Kilometers:
                    return value / KilometersPerYard;
                case LengthUnit.Inches:
                    return value / InchesPerYard;
                case LengthUnit.Feet:
                    return value / FeetPerYard;
                case LengthUnit.Yards:
                    return value;
                case LengthUnit.Miles:
                    return value * YardsPerMile;
            }

            throw new InvalidOperationException($"Cannot convert unit {units} to {nameof(LengthUnit.Yards)}");
        }

        public static decimal ToMiles(decimal value, LengthUnit units)
        {
            switch (units)
            {
                case LengthUnit.Millimeters:
                    return value / MillimetersPerMile;
                case LengthUnit.Centimeters:
                    return value / CentimetersPerMile;
                case LengthUnit.Meters:
                    return value / MetersPerMile;
                case LengthUnit.Kilometers:
                    return value / KilometersPerMile;
                case LengthUnit.Inches:
                    return value / InchesPerMile;
                case LengthUnit.Feet:
                    return value / FeetPerMile;
                case LengthUnit.Yards:
                    return value / YardsPerMile;
                case LengthUnit.Miles:
                    return value;
            }

            throw new InvalidOperationException($"Cannot convert unit {units} to {nameof(LengthUnit.Miles)}");
        }
    }
}
