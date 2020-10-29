using AsyncLifetime.Payload;
using System.Threading.Tasks;
using Xunit;

namespace AsyncLifetime
{
    public class AsyncLifetimeTests : IClassFixture<AsyncLifetimeFixture>
    {
        private readonly AsyncLifetimeFixture _fixture;

        public AsyncLifetimeTests(AsyncLifetimeFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task FirstFact()
        {
            int actualInitializeCount = new AsyncService().InitializeCount;
            int actualDisposeCount = new AsyncService().DisposeCount;

            await Task.Delay(200);

            Assert.Equal(1, actualInitializeCount);
            Assert.Equal(0, actualDisposeCount);
        }

        [Fact]
        public async Task SecondFact()
        {
            int actualInitializeCount = new AsyncService().InitializeCount;
            int actualDisposeCount = new AsyncService().DisposeCount;

            await Task.Delay(200);

            Assert.Equal(1, actualInitializeCount);
            Assert.Equal(0, actualDisposeCount);
        }

        [Fact]
        public async Task ThirdFact()
        {
            int actualInitializeCount = new AsyncService().InitializeCount;
            int actualDisposeCount = new AsyncService().DisposeCount;

            await Task.Delay(200);

            Assert.Equal(1, actualInitializeCount);
            Assert.Equal(0, actualDisposeCount);
        }
    }
}
