using System.IO;
using System.Xml.Serialization;

public static class SaveDeserializer
{
    // Serialize
    public static string Serialize<S>(this S toSerialize)
    {
        XmlSerializer xml = new XmlSerializer(typeof(S));
        StringWriter writer = new StringWriter();
        xml.Serialize(writer, toSerialize);
        return writer.ToString();
    }

    // De-Serialize
    public static S Deserialize<S>(this string toDeserialize)
    {
        XmlSerializer xml = new XmlSerializer(typeof(S));
        StringReader reader = new StringReader(toDeserialize);
        return (S)xml.Deserialize(reader);
    }
}
