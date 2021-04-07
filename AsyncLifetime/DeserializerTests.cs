using AsyncLifetime.Payload;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xunit;

namespace AsyncLifetime
{
    public class DeserializerTests
    {
        private static string GetEmptyObjectDataJson() => @"{""id"":""object_id"", ""data"":{}}";
        private static string GetEmptyArrayDataJson() => @"{""id"":""object_id"", ""data"":[]}";
        private static string GetFilledArrayDataJson() => @"{""id"":""object_id"", ""data"":[{""one"":""1"",""two"":""2""}]}";

        [Fact]
        public void Deserialize_EmptyObject_Success()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                IgnoreNullValues = true,
                //DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
            };

            var result = JsonSerializer.Deserialize<TestModel>(GetEmptyObjectDataJson(), options);

            Assert.NotNull(result?.Data);
        }

        [Fact]
        public void Deserialize_EmptyArray_Success()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                //IgnoreNullValues = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
            };

            var result = JsonSerializer.Deserialize<TestModel>(GetEmptyArrayDataJson(), options);

            Assert.NotNull(result?.Data);
        }

        [Fact]
        public void Deserialize_FilledArray_Success()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                //IgnoreNullValues = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
            };

            var result = JsonSerializer.Deserialize<TestModel>(GetFilledArrayDataJson(), options);


            Assert.NotNull(result?.Data);
        }
    }
}