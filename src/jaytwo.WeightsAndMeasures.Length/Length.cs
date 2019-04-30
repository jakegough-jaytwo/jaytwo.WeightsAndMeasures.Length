using System;

namespace jaytwo.WeightsAndMeasures
{
    // as defined in the NIST Handbook 44
    // https://nvlpubs.nist.gov/nistpubs/hb/2019/NIST.HB.44-2019.pdf
    // page C-8

    public struct Length : IComparable<Length>, IEquatable<Length>
    {
        public const decimal MetersPerMillimeter = .001m;
        public const decimal MetersPerCentimeter = .01m;
        public const decimal MetersPerKilometer = 1000m;
        public const decimal MetersPerInch = 0.0254m;
        public const decimal MetersPerFoot = 0.3048m;
        public const decimal MetersPerYard = 0.9144m;
        public const decimal MetersPerMile = 1609.344m;

        public decimal Millimeters => Meters / MetersPerMillimeter;
        public decimal Centimeters => Meters / MetersPerCentimeter;
        public decimal Meters { get; }
        public decimal Kilometers => Meters / MetersPerKilometer;
        public decimal Inches => Meters / MetersPerInch;
        public decimal Feet => Meters / MetersPerFoot;
        public decimal Yards => Meters / MetersPerYard;
        public decimal Miles => Meters / MetersPerMile;

        private Length(decimal meters)
        {
            Meters = meters;
        }

        public static Length FromMillimeters(decimal millimeters) => FromMeters(millimeters * MetersPerMillimeter);
        public static Length FromMillimeters(double millimeters) => FromMillimeters(Convert.ToDecimal(millimeters));
        public static Length FromMillimeters(long millimeters) => FromMillimeters(Convert.ToDecimal(millimeters));
        public static Length FromCentimeters(decimal centimeters) => FromMeters(centimeters * MetersPerCentimeter);
        public static Length FromCentimeters(double centimeters) => FromCentimeters(Convert.ToDecimal(centimeters));
        public static Length FromCentimeters(long centimeters) => FromCentimeters(Convert.ToDecimal(centimeters));
        public static Length FromMeters(decimal meters) => new Length(meters);
        public static Length FromMeters(double meters) => FromMeters(Convert.ToDecimal(meters));
        public static Length FromMeters(long meters) => FromMeters(Convert.ToDecimal(meters));
        public static Length FromKilometers(decimal kilometers) => FromMeters(kilometers * MetersPerKilometer);
        public static Length FromKilometers(double kilometers) => FromKilometers(Convert.ToDecimal(kilometers));
        public static Length FromKilometers(long kilometers) => FromKilometers(Convert.ToDecimal(kilometers));
        public static Length FromInches(decimal inches) => FromMeters(inches * MetersPerInch);
        public static Length FromInches(double inches) => FromInches(Convert.ToDecimal(inches));
        public static Length FromInches(long inches) => FromInches(Convert.ToDecimal(inches));
        public static Length FromFeet(decimal feet) => FromMeters(feet * MetersPerFoot);
        public static Length FromFeet(double feet) => FromFeet(Convert.ToDecimal(feet));
        public static Length FromFeet(long feet) => FromFeet(Convert.ToDecimal(feet));
        public static Length FromYards(decimal yards) => FromMeters(yards * MetersPerYard);
        public static Length FromYards(double yards) => FromYards(Convert.ToDecimal(yards));
        public static Length FromYards(long yards) => FromYards(Convert.ToDecimal(yards));
        public static Length FromMiles(decimal miles) => FromMeters(miles * MetersPerMile);
        public static Length FromMiles(double miles) => FromMiles(Convert.ToDecimal(miles));
        public static Length FromMiles(long miles) => FromMiles(Convert.ToDecimal(miles));

        public static Length Zero = new Length(decimal.Zero);
        public static Length MinValue = new Length(decimal.MinValue);
        public static Length MaxValue = new Length(decimal.MaxValue);

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj is Length)
            {
                Length other = (Length)obj;

                return other.Meters == Meters;
            }

            return false;
        }

        public int CompareTo(Length other) => Meters.CompareTo(other.Meters);

        public Length MultiplyBy(decimal value) => this * value;
        public Length MultiplyBy(double value) => this * value;
        public Length MultiplyBy(long value) => this * value;
        public Length DivideBy(decimal value) => this / value;
        public Length DivideBy(double value) => this / value;
        public Length DivideBy(long value) => this / value;
        public Length Add(Length lengthToAdd) => this + lengthToAdd;
        public Length Subtract(Length lengthToSubtract) => this - lengthToSubtract;

        public bool Equals(Length other) => other.Meters == Meters;
        public static bool operator ==(Length left, Length right) => left.Equals(right);
        public static bool operator !=(Length left, Length right) => !left.Equals(right);
        public static bool operator >(Length left, Length right) => left.Meters > right.Meters;
        public static bool operator >=(Length left, Length right) => left.Meters >= right.Meters;
        public static bool operator <(Length left, Length right) => left.Meters < right.Meters;
        public static bool operator <=(Length left, Length right) => left.Meters <= right.Meters;
        public static Length operator +(Length left, Length right) => new Length(left.Meters + right.Meters);
        public static Length operator -(Length left, Length right) => new Length(left.Meters - right.Meters);
        public static Length operator *(Length left, decimal right) => new Length(left.Meters * right);
        public static Length operator *(Length left, double right) => new Length(left.Meters * Convert.ToDecimal(right));
        public static Length operator *(Length left, long right) => new Length(left.Meters * Convert.ToDecimal(right));
        public static Length operator /(Length left, decimal right) => new Length(left.Meters / right);
        public static Length operator /(Length left, double right) => new Length(left.Meters / Convert.ToDecimal(right));
        public static Length operator /(Length left, long right) => new Length(left.Meters / Convert.ToDecimal(right));
        public static implicit operator Length(decimal value) => FromMeters(value);
        public static implicit operator Length(double value) => FromMeters(value);
        public static implicit operator Length(long value) => FromMeters(value);
        public static implicit operator decimal(Length value) => value.Meters;
        public static implicit operator double(Length value) => Convert.ToDouble(value.Meters);
        public static implicit operator long(Length value) => Convert.ToInt64(value.Meters);
        public override int GetHashCode() => Meters.GetHashCode();
    }
}
