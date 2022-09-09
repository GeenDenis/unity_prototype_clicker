using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace GeneDenis.Serialisation
{
    public static class Serializer
    {
        private static BinaryFormatter _binaryFormatter;

        public static string Serialize<T>(T obj)
        {
            if (_binaryFormatter is null)
            {
                _binaryFormatter = new BinaryFormatter();
            }
            
            if (obj is null || !obj.GetType().IsSerializable)
            {
                return "";
            }

            var stream = new MemoryStream();
            _binaryFormatter.Serialize(stream, obj);
            return Convert.ToBase64String(stream.ToArray());
        }
        
        public static T Deserialize<T>(string serializedData)
        {
            if (_binaryFormatter is null)
            {
                _binaryFormatter = new BinaryFormatter();
            }
            
            if (serializedData is null || serializedData.Length == 0)
            {
                return default;
            }
            
            var bytes = Convert.FromBase64String(serializedData);
            return (T) _binaryFormatter.Deserialize(new MemoryStream(bytes));
        }
    }
}