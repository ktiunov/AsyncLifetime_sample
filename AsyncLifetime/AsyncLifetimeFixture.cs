using AsyncLifetime.Payload;
using System.Threading.Tasks;
using Xunit;

namespace AsyncLifetime
{
    public class AsyncLifetimeFixture : IAsyncLifetime
    {
        public Task InitializeAsync()
        {
            return new AsyncService().InitializeAsync();
        }

        public Task DisposeAsync()
        {
            return new AsyncService().DisposeAsync();
        }
    }
}