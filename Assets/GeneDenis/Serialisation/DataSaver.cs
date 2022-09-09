using UnityEngine;

namespace GeneDenis.Serialisation
{
    public static class DataSaver
    {
        public static bool Has(string key)
        {
            return PlayerPrefs.HasKey(key);
        }

        public static T Load<T>(string key)
        {
            return Load<T>(key, default);
        }

        public static T Load<T>(string key, T defaultValue)
        {
            if (TryLoad(key, out T value))
            {
                return value;
            }

            return defaultValue;
        }

        public static bool TryLoad<T>(string key, out T value)
        {
            value = default;
            var result = Has(key);
            if (result)
            {
                var data = PlayerPrefs.GetString(key);
                value = Serializer.Deserialize<T>(data);
            }
            return result;
        }

        public static void Save<T>(string key, T value)
        {
            var data = Serializer.Serialize(value);
            PlayerPrefs.SetString(key, data);
        }
    }
}