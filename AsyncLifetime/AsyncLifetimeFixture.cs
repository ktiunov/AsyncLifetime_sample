using AsyncLifetime.Payload;
using System.Threading.Tasks;
using Xunit;

namespace AsyncLifetime
{
    public class AsyncLifetimeFixture : IAsyncLifetime
    {
        public async Task InitializeAsync()
        {
            await new AsyncService().InitializeAsync().ConfigureAwait(false);
        }

        public async Task DisposeAsync()
        {
            await new AsyncService().DisposeAsync().ConfigureAwait(false);
        }
    }
}