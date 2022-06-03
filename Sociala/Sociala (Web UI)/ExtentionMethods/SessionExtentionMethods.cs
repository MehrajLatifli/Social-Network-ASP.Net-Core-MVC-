using Newtonsoft.Json;

namespace Sociala__Web_UI_.ExtentionMethods
{
    public static class SessionExtentionMethods
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            string objectString = JsonConvert.SerializeObject(value);
            session.SetString(key, objectString);
        }
        public static T GetObject<T>(this ISession session, string key) where T : class
        {
            string objectString = session.GetString(key);
            if (string.IsNullOrEmpty(objectString)) return null;
            T valueDeserialize = JsonConvert.DeserializeObject<T>(objectString);
            return valueDeserialize;
        }
    }
}
