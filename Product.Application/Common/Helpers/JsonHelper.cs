using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Product.Application.Common.Helpers
{
    public static class JsonHelper
    {
        private static readonly JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore,
            Converters = new List<JsonConverter> { new StringEnumConverter() },
            Formatting = Formatting.None
        };

        // Serialize Dictionary<string, object>
        public static string Serialize(this Dictionary<string, object> dict)
        {
            return JsonConvert.SerializeObject(dict, _settings);
        }

        // Deserialize into any type
        public static T? Deserialize<T>(this string? json)
        {
            if (string.IsNullOrWhiteSpace(json))
                return default;

            return JsonConvert.DeserializeObject<T>(json, _settings);
        }
    }
}
