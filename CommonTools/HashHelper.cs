using System;
using System.Security.Cryptography;
using System.Text;

namespace CommonTools;

public static class HashHelper
{
    public static Guid ComputeHashGuid(this string s)
    {
        s = s.Trim(' ', '\t', '\r', '\n', '\v');
        byte[] hash = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(s));
        return new Guid(hash);
    }

    public static long ComputeHashInt64(this string s)
    {
        s = s.Trim(' ', '\t', '\r', '\n', '\v');
        byte[] hash = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(s));
        long result = 0;
        for (int i = 0; i < 16; i++)
            result ^= (long)hash[i] << (i * 4);
        return result;
    }

    public static int ComputeHash(this string s)
    {
        s = s.Trim(' ', '\t', '\r', '\n', '\v');
        byte[] hash = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(s));
        int result = 0;
        for (int i = 0; i < 8; i++)
            result ^= hash[i] << (i * 4);
        return result;
    }
}
