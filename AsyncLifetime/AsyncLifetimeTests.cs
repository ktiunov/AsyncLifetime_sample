using System;
using AsyncLifetime.Payload;
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
        public void FirstFact()
        {
            int actualInitializeCount = new AsyncService().InitializeCount;
            int actualDisposeCount = new AsyncService().DisposeCount;

            Assert.Equal(1, actualInitializeCount);
            Assert.Equal(0, actualDisposeCount);
        }

        [Fact]
        public void SecondFact()
        {
            int actualInitializeCount = new AsyncService().InitializeCount;
            int actualDisposeCount = new AsyncService().DisposeCount;

            Assert.Equal(1, actualInitializeCount);
            Assert.Equal(0, actualDisposeCount);
        }

        [Fact]
        public void ThirdFact()
        {
            int actualInitializeCount = new AsyncService().InitializeCount;
            int actualDisposeCount = new AsyncService().DisposeCount;

            Assert.Equal(1, actualInitializeCount);
            Assert.Equal(0, actualDisposeCount);
        }
    }
}
