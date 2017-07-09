using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Core.Utils
{
    /// <summary>
    /// Binary serialization helper
    /// </summary>
    public static class SerializationHelper
    {
        public static byte[] Serialize<T>(T obj, bool compression = false)
        {
            var stream = new MemoryStream();
            BinaryFormatter bformatter = new BinaryFormatter();
            bformatter.Serialize(stream, obj);
            stream.Close();
            return stream.GetBuffer();
        }

        public static T Deserialize<T>(byte[] bytes, bool compression = false)
        {
            var stream = new MemoryStream(bytes);
            BinaryFormatter bformatter = new BinaryFormatter();
            var obj = (T)bformatter.Deserialize(stream);
            stream.Close();
            return obj;
        }
    }
}
