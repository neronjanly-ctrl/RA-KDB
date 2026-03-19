using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace CommonTools;

public static class XmlConvert
{
    public static T DeserializeObject<T>(string value)
    {
        try
        {
            using (StringReader stringReader = new(value))
            {
                XmlSerializer serializer = new(typeof(T));
                return (T)serializer.Deserialize(stringReader);
            }
        }
        catch (Exception)
        {
        }

        return default;
    }

    public static string SerializeObject<T>(object value)
    {
        try
        {
            StringBuilder sb = new();
            using (StringWriter stringWriter = new(sb))
            {
                XmlSerializer serializer = new(typeof(T));
                serializer.Serialize(stringWriter, value);
                return sb.ToString();
            }
        }
        catch (Exception)
        {
        }

        return default;
    }
}
