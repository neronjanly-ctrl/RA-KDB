using System;
using System.Drawing;
using System.Globalization;
using System.Linq;

namespace CommonTools;

public static class ColorHelper
{
    /// <summary>
    /// Convert a html color name or hex code to a <see cref="Color"/> object.
    /// </summary>
    /// <param name="htmlColor">#RGB, #RGBA, #RRGGBB, #RRGGBBAA or color name</param>
    /// <returns></returns>
    public static Color ToColor(string htmlColor)
    {
        if (htmlColor.StartsWith("#"))
        {
            htmlColor = htmlColor[1..];
            if (htmlColor.Length == 3)
                htmlColor = $"FF{htmlColor[0]}{htmlColor[0]}{htmlColor[1]}{htmlColor[1]}{htmlColor[2]}{htmlColor[2]}";
            else if (htmlColor.Length == 4)
                htmlColor = $"{htmlColor[3]}{htmlColor[3]}{htmlColor[0]}{htmlColor[0]}{htmlColor[1]}{htmlColor[1]}{htmlColor[2]}{htmlColor[2]}";
            else if (htmlColor.Length == 6)
                htmlColor = $"FF{htmlColor}";
            else if (htmlColor.Length != 8)
                return default;
            htmlColor = htmlColor.ToUpper();
            int[] arr = Enumerable.Range(0, 4).Select(i => int.Parse(htmlColor.Substring(i * 2, 2), NumberStyles.HexNumber)).ToArray();
            return Color.FromArgb(arr[0], arr[1], arr[2], arr[3]);
        }
        else
        {
            return Color.FromName(htmlColor);
        }
    }

    public static Color ToColor(double[] argb)
    {
        return Color.FromArgb((int)(argb[0] * 255), (int)(argb[1] * 255), (int)(argb[2] * 255), (int)(argb[3] * 255));
    }

    public static Color ToColor((double a, double r, double g, double b) color)
    {
        return Color.FromArgb((int)(color.a * 255), (int)(color.r * 255), (int)(color.g * 255), (int)(color.b * 255));
    }

    public static Color Lerp(Color color0, Color color1, double v)
    {
        return Color.FromArgb
        (
            (int)(color0.A * (1 - v) + color1.A * v),
            (int)(color0.R * (1 - v) + color1.R * v),
            (int)(color0.G * (1 - v) + color1.G * v),
            (int)(color0.B * (1 - v) + color1.B * v)
        );
    }

    public static double[] Lerp(double[] argb0, double[] argb1, double v)
    {
        return new[]
        {
            argb0[0] * (1 - v) + argb1[0] * v,
            argb0[1] * (1 - v) + argb1[1] * v,
            argb0[2] * (1 - v) + argb1[2] * v,
            argb0[3] * (1 - v) + argb1[3] * v,
        };
    }

    public static (double a, double r, double g, double b) Lerp((double a, double r, double g, double b) color0, (double a, double r, double g, double b) color1, double v)
    {
        return
        (
            color0.a * (1 - v) + color1.a * v,
            color0.r * (1 - v) + color1.r * v,
            color0.g * (1 - v) + color1.g * v,
            color0.b * (1 - v) + color1.b * v
        );
    }

    private static (int, double) LocalizeValue(int scales, double min, double max, double v)
    {
        v = Math.Min(Math.Max(v, min), max);

        double span = (max - min) / (scales - 1);
        int id = (int)((v - min) / span);
        return (id, (v - min - span * id) / span);
    }

    /// <summary>
    /// Map a value using the specific color scheme.
    /// Caution: all adjacent scheme scales must be in the same distance or wrong result will be returned.
    /// </summary>
    /// <param name="scheme">color scheme in ascending order</param>
    /// <param name="v"></param>
    /// <returns></returns>
    public static Color Map((double scale, Color color)[] scheme, double v)
    {
        (int id, double lv) = LocalizeValue(scheme.Length, scheme[0].scale, scheme.Last().scale, v);

        if (id == scheme.Length - 1)
            return scheme[id].color;

        return Lerp(scheme[id].color, scheme[id + 1].color, lv);
    }

    /// <summary>
    /// Map a value using the specific color scheme.
    /// </summary>
    /// <param name="scheme">color scheme in ascending order</param>
    /// <param name="v"></param>
    /// <returns></returns>
    public static double[] Map((double scale, double[] argb)[] scheme, double v)
    {
        (int id, double lv) = LocalizeValue(scheme.Length, scheme[0].scale, scheme.Last().scale, v);

        if (id == scheme.Length - 1)
            return scheme[id].argb;

        return Lerp(scheme[id].argb, scheme[id + 1].argb, lv);
    }

    /// <summary>
    /// Map a value using the specific color scheme.
    /// </summary>
    /// <param name="scheme">color scheme in ascending order</param>
    /// <param name="v"></param>
    /// <returns></returns>
    public static (double a, double r, double g, double b) Map((double scale, (double a, double r, double g, double b) color)[] scheme, double v)
    {
        (int id, double lv) = LocalizeValue(scheme.Length, scheme[0].scale, scheme.Last().scale, v);

        if (id == scheme.Length - 1)
            return scheme[id].color;

        return Lerp(scheme[id].color, scheme[id + 1].color, lv);
    }

    public static Color Map(Color[] scheme, double min, double max, double v)
    {
        (int id, double lv) = LocalizeValue(scheme.Length, min, max, v);

        if (id == scheme.Length - 1)
            return scheme[id];

        return Lerp(scheme[id], scheme[id + 1], lv);
    }

    public static double[] Map(double[][] argbScheme, double min, double max, double v)
    {
        (int id, double lv) = LocalizeValue(argbScheme.Length, min, max, v);

        if (id == argbScheme.Length - 1)
            return argbScheme[id];

        return Lerp(argbScheme[id], argbScheme[id + 1], lv);
    }

    public static (double a, double r, double g, double b) Map((double a, double r, double g, double b)[] argbScheme, double min, double max, double v)
    {
        (int id, double lv) = LocalizeValue(argbScheme.Length, min, max, v);

        if (id == argbScheme.Length - 1)
            return argbScheme[id];

        return Lerp(argbScheme[id], argbScheme[id + 1], lv);
    }

    private static float HueToRgb(float p, float q, float t)
    {
        if (t < 0) t += 1;
        if (t > 1) t -= 1;
        if (t < 1f / 6) return p + (q - p) * 6 * t;
        if (t < 1f / 2) return q;
        if (t < 2f / 3) return p + (q - p) * (2f / 3 - t) * 6;
        return p;
    }

    // a, h, s, l components are in range [0, 1]
    public static Color FromAhsl(float a, float h, float s, float l)
    {
        (float r, float g, float b) = (l, l, l); // achromatic

        if (s != 0)
        {
            float q = l < 0.5f ? l * (1 + s) : l + s - l * s;
            float p = 2 * l - q;
            r = HueToRgb(p, q, h + 1f / 3);
            g = HueToRgb(p, q, h);
            b = HueToRgb(p, q, h - 1f / 3);
        }

        return Color.FromArgb((int)(a * 255), (int)(r * 255), (int)(g * 255), (int)(b * 255));
    }

    // a, h, s, l components are in range [0, 1]
    public static string HslToHex(float h, float s, float l)
    {
        (float r, float g, float b) = (l, l, l); // achromatic

        if (s != 0)
        {
            float q = l < 0.5f ? l * (1 + s) : l + s - l * s;
            float p = 2 * l - q;
            r = HueToRgb(p, q, h + 1f / 3);
            g = HueToRgb(p, q, h);
            b = HueToRgb(p, q, h - 1f / 3);
        }

        return $"#{(int)(r * 255):x2}{(int)(g * 255):x2}{(int)(b * 255):x2}";
    }
}
