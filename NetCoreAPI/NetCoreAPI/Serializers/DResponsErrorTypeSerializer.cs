using NetCoreAPI.Helpers;
using NetCoreAPI.Models;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NetCoreAPI.Serializers
{
    public class DResponsErrorTypeSerializer : JsonConverter<DResponse<dynamic>.ErrorType>
    {
        public override DResponse<dynamic>.ErrorType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string value = reader.GetString();

            return value.ToErrorType();
        }

        public override void Write(Utf8JsonWriter writer, DResponse<dynamic>.ErrorType value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToDescription());
        }
    }
}
