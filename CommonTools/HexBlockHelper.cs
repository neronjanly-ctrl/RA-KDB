using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CommonTools;

public static class HexBlockHelper
{
    public static string ToHexString(this byte[] bytes)
    {
        StringBuilder sb = new();

        for (int i = 0; i < bytes.Length; i++)
        {
            sb.Append(bytes[i].ToString("x2"));
        }

        return sb.ToString();
    }

    public static string ToHexString(this byte[] bytes, int blockBytes, int rowBlocks)
    {
        StringBuilder sb = new();
        int rowBytes = blockBytes * rowBlocks;

        for (int i = 0; i < bytes.Length; i++)
        {
            sb.Append(bytes[i].ToString("x2"));
            if (i % rowBytes == rowBytes - 1)
                sb.AppendLine();
            else if (i % blockBytes == blockBytes - 1)
                sb.Append(' ');
        }

        return sb.ToString();
    }

    public static byte[] ToBytes(this string hexString)
    {
        List<byte> bytes = new();

        using (IEnumerator<char> it = hexString.Where(char.IsLetterOrDigit).GetEnumerator())
        {
            it.MoveNext();

            while (true)
            {
                char a = it.Current;

                it.MoveNext();

                char b = it.Current;

                bytes.Add(byte.Parse($"{a}{b}", NumberStyles.HexNumber));

                if (!it.MoveNext())
                    break;
            }
        }

        return bytes.ToArray();
    }
}
