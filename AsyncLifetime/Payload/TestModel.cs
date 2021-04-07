using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AsyncLifetime.Payload
{
    public class TestModel
    {
        [JsonIgnore]
        public IReadOnlyList<Describer> Data
        {
            get
            {
                if (JsonData.ValueKind != JsonValueKind.Array)
                {
                    return Array.Empty<Describer>();
                }

                var bufferWriter = new ArrayBufferWriter<byte>();
                using var writer = new Utf8JsonWriter(bufferWriter);
                JsonData.WriteTo(writer);
                writer.Flush();

                var reader = new Utf8JsonReader(bufferWriter.WrittenSpan);
                return JsonSerializer.Deserialize<List<Describer>>(ref reader, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }
        }

        [JsonPropertyName("data")]
        public JsonElement JsonData { get; set; }
        public string Id { get; set; }
    }
}