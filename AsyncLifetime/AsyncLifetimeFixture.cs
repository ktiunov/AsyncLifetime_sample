using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AsyncLifetime
{
    public class AsyncLifetimeFixture : IAsyncLifetime
    {
        private IHost _host;

        public async Task InitializeAsync()
        {
            _host = AsyncWeb.Program.CreateHostBuilder(Array.Empty<string>()).Build();
            await _host.StartAsync().ConfigureAwait(false);
        }

        public async Task DisposeAsync()
        {
            await _host.StopAsync().ConfigureAwait(false);
        }
    }
}