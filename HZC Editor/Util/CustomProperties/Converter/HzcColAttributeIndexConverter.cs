using Horizon;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;

public class HzcColAttributeIndexConverter : Int32Converter
{
    public override bool GetStandardValuesSupported(ITypeDescriptorContext? context) => true;
    public override bool GetStandardValuesExclusive(ITypeDescriptorContext? context) => false;

    public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext? context)
    {
        List<int> values = new List<int> { -1 };
        if (context?.Instance is ColTriangle triangle && triangle.Hzc != null)
        {
            for (int i = 0; i < triangle.Hzc.Attributes.Count; i++)
            {
                values.Add(i);
            }
        }

        return new StandardValuesCollection(values);
    }

    public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
    {
        return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
    }

    public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType)
    {
        return destinationType == typeof(string) || base.CanConvertTo(context, destinationType);
    }

    public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
    {
        if (destinationType == typeof(string) && value is int index)
        {
            if (index < 0)
                return "(none)";

            if (context?.Instance is ColTriangle triangle && triangle.Hzc != null && index < triangle.Hzc.Attributes.Count)
                return $"[{index}] {triangle.Hzc.Attributes[index].Key}";

            return index.ToString();
        }

        return base.ConvertTo(context, culture, value, destinationType);
    }

    public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
    {
        if (value is string s)
        {
            s = s.Trim();
            if (s.Length == 0 || s.StartsWith("(none", StringComparison.OrdinalIgnoreCase))
                return -1;

            Match match = Regex.Match(s, @"^\[(-?\d+)\]");
            if (match.Success && int.TryParse(match.Groups[1].Value, out int indexFromBracket))
                return indexFromBracket;

            if (context?.Instance is ColTriangle triangle && triangle.Hzc != null)
            {
                int found = triangle.Hzc.Attributes.FindIndex(p => string.Equals(p.Key, s, StringComparison.OrdinalIgnoreCase));
                if (found >= 0)
                    return found;
            }

            if (int.TryParse(s, out int rawValue))
                return rawValue;
        }

        return base.ConvertFrom(context, culture, value);
    }
}
