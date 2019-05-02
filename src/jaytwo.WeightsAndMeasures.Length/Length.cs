using System;

namespace jaytwo.WeightsAndMeasures
{
    public struct Length : IComparable<Length>, IEquatable<Length>
    {
        private readonly decimal _value;
        private readonly LengthUnit _units;

        public decimal Millimeters => GetValueAs(LengthUnit.Millimeters);
        public decimal Centimeters => GetValueAs(LengthUnit.Centimeters);
        public decimal Meters => GetValueAs(LengthUnit.Meters);
        public decimal Kilometers => GetValueAs(LengthUnit.Kilometers);
        public decimal Inches => GetValueAs(LengthUnit.Inches);
        public decimal Feet => GetValueAs(LengthUnit.Feet);
        public decimal Yards => GetValueAs(LengthUnit.Yards);
        public decimal Miles => GetValueAs(LengthUnit.Miles);

        public decimal GetValueAs(LengthUnit targetUnits)
        {
            switch (targetUnits)
            {
                case LengthUnit.Millimeters:
                    return LengthConverter.ToMillimeters(_value, _units) / 1m; // divide by 1 to trim zeroes
                case LengthUnit.Centimeters:
                    return LengthConverter.ToCentimeters(_value, _units) / 1m;
                case LengthUnit.Meters:
                    return LengthConverter.ToMeters(_value, _units) / 1m;
                case LengthUnit.Kilometers:
                    return LengthConverter.ToKilometers(_value, _units) / 1m;
                case LengthUnit.Inches:
                    return LengthConverter.ToInches(_value, _units) / 1m;
                case LengthUnit.Feet:
                    return LengthConverter.ToFeet(_value, _units) / 1m;
                case LengthUnit.Yards:
                    return LengthConverter.ToYards(_value, _units) / 1m;
                case LengthUnit.Miles:
                    return LengthConverter.ToMiles(_value, _units) / 1m;
            }

            throw new InvalidOperationException($"Cannot convert unit {_units} to {targetUnits}");
        }

        public bool IsMetric
        {
            get
            {
                return _units == LengthUnit.Millimeters
                    || _units == LengthUnit.Centimeters
                    || _units == LengthUnit.Meters
                    || _units == LengthUnit.Kilometers
                    ;
            }
        }

        public Length(decimal value, LengthUnit units)
        {
            _value = value;
            _units = units;
        }

        public static Length FromMillimeters(decimal millimeters) => new Length(millimeters, LengthUnit.Millimeters);
        public static Length FromMillimeters(double millimeters) => FromMillimeters(Convert.ToDecimal(millimeters));
        public static Length FromMillimeters(long millimeters) => FromMillimeters(Convert.ToDecimal(millimeters));
        public static Length FromCentimeters(decimal centimeters) => new Length(centimeters, LengthUnit.Centimeters);
        public static Length FromCentimeters(double centimeters) => FromCentimeters(Convert.ToDecimal(centimeters));
        public static Length FromCentimeters(long centimeters) => FromCentimeters(Convert.ToDecimal(centimeters));
        public static Length FromMeters(decimal meters) => new Length(meters, LengthUnit.Meters);
        public static Length FromMeters(double meters) => FromMeters(Convert.ToDecimal(meters));
        public static Length FromMeters(long meters) => FromMeters(Convert.ToDecimal(meters));
        public static Length FromKilometers(decimal kilometers) => new Length(kilometers, LengthUnit.Kilometers);
        public static Length FromKilometers(double kilometers) => FromKilometers(Convert.ToDecimal(kilometers));
        public static Length FromKilometers(long kilometers) => FromKilometers(Convert.ToDecimal(kilometers));
        public static Length FromInches(decimal inches) => new Length(inches, LengthUnit.Inches);
        public static Length FromInches(double inches) => FromInches(Convert.ToDecimal(inches));
        public static Length FromInches(long inches) => FromInches(Convert.ToDecimal(inches));
        public static Length FromFeet(decimal feet) => new Length(feet, LengthUnit.Feet);
        public static Length FromFeet(double feet) => FromFeet(Convert.ToDecimal(feet));
        public static Length FromFeet(long feet) => FromFeet(Convert.ToDecimal(feet));
        public static Length FromYards(decimal yards) => new Length(yards, LengthUnit.Yards);
        public static Length FromYards(double yards) => FromYards(Convert.ToDecimal(yards));
        public static Length FromYards(long yards) => FromYards(Convert.ToDecimal(yards));
        public static Length FromMiles(decimal miles) => new Length(miles, LengthUnit.Miles);
        public static Length FromMiles(double miles) => FromMiles(Convert.ToDecimal(miles));
        public static Length FromMiles(long miles) => FromMiles(Convert.ToDecimal(miles));

        public static Length Zero = FromMeters(decimal.Zero);
        public static Length MinValue = FromMeters(decimal.MinValue);
        public static Length MaxValue = FromMeters(decimal.MaxValue);

        public Length MultiplyBy(decimal value) => new Length(_value * value, _units);
        public Length MultiplyBy(double value) => new Length(_value * Convert.ToDecimal(value), _units);
        public Length MultiplyBy(long value) => new Length(_value * value, _units);
        public Length DivideBy(decimal value) => new Length(_value / value, _units);
        public Length DivideBy(double value) => new Length(_value / Convert.ToDecimal(value), _units);
        public Length DivideBy(long value) => new Length(_value / value, _units);

        public Length Add(Length other)
        {
            if (_units == other._units)
            {
                return new Length(_value + other._value, _units);
            }
            else if (!IsMetric && !other.IsMetric)
            {
                var sumInches = FromInches(Inches + other.Inches);
                var sumSourceUnits = sumInches.GetValueAs(_units);
                return new Length(sumSourceUnits, _units);
            }
            else
            {
                var sumMeters = FromMeters(Meters + other.Meters);
                var sumSourceUnits = sumMeters.GetValueAs(_units);
                return new Length(sumSourceUnits, _units);
            }
        }

        public Length Subtract(Length other)
        {
            if (_units == other._units)
            {
                return new Length(_value - other._value, _units);
            }
            else if (!IsMetric && !other.IsMetric)
            {
                var differenceInches = FromInches(Inches - other.Inches);
                var differenceSourceUnits = differenceInches.GetValueAs(_units);
                return new Length(differenceSourceUnits, _units);
            }
            else
            {
                var differenceMeters = FromMeters(Meters - other.Meters);
                var differenceSourceUnits = differenceMeters.GetValueAs(_units);
                return new Length(differenceSourceUnits, _units);
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj is Length)
            {
                return Equals((Length)obj);
            }

            return false;
        }

        public int CompareTo(Length other)
        {
            if (Equals(other))
            {
                return 0;
            }
            else if (IsGreaterThan(other))
            {
                return 1;
            }
            else if (IsLessThan(other))
            {
                return -1;
            }

            throw new InvalidOperationException($"{this} is neither greater than, less than, nor equal to {other}");
        }

        public bool Equals(Length other)
        {
            if (_units == other._units)
            {
                return _value == other._value;
            }
            else if (!IsMetric && !other.IsMetric)
            {
                return Inches == other.Inches;
            }
            else
            {
                return Meters == other.Meters;
            }
        }

        public bool IsLessThan(Length other)
        {
            if (_units == other._units)
            {
                return _value < other._value;
            }
            else if (!IsMetric && !other.IsMetric)
            {
                return Inches < other.Inches;
            }
            else
            {
                return Meters < other.Meters;
            }
        }

        public bool IsGreaterThan(Length other)
        {
            if (_units == other._units)
            {
                return _value > other._value;
            }
            else if (!IsMetric && !other.IsMetric)
            {
                return Inches > other.Inches;
            }
            else
            {
                return Meters > other.Meters;
            }
        }

        public static bool operator ==(Length left, Length right) => left.Equals(right);
        public static bool operator !=(Length left, Length right) => !left.Equals(right);
        public static bool operator >(Length left, Length right) => left.IsGreaterThan(right);
        public static bool operator >=(Length left, Length right) => left.IsGreaterThan(right) || left.Equals(right);
        public static bool operator <(Length left, Length right) => left.IsLessThan(right);
        public static bool operator <=(Length left, Length right) => left.IsLessThan(right) || left.Equals(right);
        public static Length operator +(Length left, Length right) => left.Add(right);
        public static Length operator -(Length left, Length right) => left.Subtract(right);
        public static Length operator *(Length left, decimal right) => left.MultiplyBy(right);
        public static Length operator *(Length left, double right) => left.MultiplyBy(right);
        public static Length operator *(Length left, long right) => left.MultiplyBy(right);
        public static Length operator /(Length left, decimal right) => left.DivideBy(right);
        public static Length operator /(Length left, double right) => left.DivideBy(right);
        public static Length operator /(Length left, long right) => left.DivideBy(right);
        public static implicit operator Length(decimal value) => FromMeters(value);
        public static implicit operator Length(double value) => FromMeters(value);
        public static implicit operator Length(long value) => FromMeters(value);
        public static implicit operator decimal(Length value) => value.Meters;
        public static implicit operator double(Length value) => Convert.ToDouble(value.Meters);
        public static implicit operator long(Length value) => Convert.ToInt64(value.Meters);
        public override int GetHashCode() => Meters.GetHashCode();
        public override string ToString() => $"{_value / 1m} {GetAbbreviation(_units)}".Trim();
        public string ToString(LengthUnit units) => $"{GetValueAs(units)} {GetAbbreviation(_units)}";

        internal static string GetAbbreviation(LengthUnit units)
        {
            switch (units)
            {
                case LengthUnit.Millimeters:
                    return "mm";
                case LengthUnit.Centimeters:
                    return "cm";
                case LengthUnit.Meters:
                    return "m";
                case LengthUnit.Kilometers:
                    return "km";
                case LengthUnit.Inches:
                    return "in";
                case LengthUnit.Feet:
                    return "ft";
                case LengthUnit.Yards:
                    return "yd";
                case LengthUnit.Miles:
                    return "mi";
            }

            return string.Empty;
        }
    }
}
