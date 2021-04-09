using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AsyncLifetime
{
    public class AsyncLifetimeTests : IClassFixture<AsyncLifetimeFixture>
    {
        private readonly AsyncLifetimeFixture _fixture;
        private static readonly HttpClient _httpClient = new HttpClient();

        public AsyncLifetimeTests(AsyncLifetimeFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Get_WaitResponse_AllDataRecieved()
        {
            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5000");
            using var response = await _httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead);

            response.EnsureSuccessStatusCode();

            using Stream responseContent = await response.Content.ReadAsStreamAsync();
            using var reader = new StreamReader(responseContent);
            var buffer = new char[10];
            var builder = new StringBuilder(20);
            while (!reader.EndOfStream)
            {
                await reader.ReadAsync(buffer.AsMemory());
                builder.Append(buffer);
            }

            var responseString = builder.ToString();


            Assert.NotEmpty(responseString);
        }
    }
}
