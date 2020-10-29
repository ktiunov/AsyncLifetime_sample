using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncLifetime.Payload
{
    public class AsyncService
    {
        private static int _counterToInitialize = 0;
        private static int _counterToDispose = 0;

        public int InitializeCount => _counterToInitialize;
        public int DisposeCount => _counterToDispose;

        public Task InitializeAsync()
        {
            return Task.Run(IncrementInitializer);
        }

        public Task DisposeAsync()
        {
            return Task.Run(IncrementDispose);
        }

        private static void IncrementInitializer()
        {
            Interlocked.Increment(ref _counterToInitialize);
        }

        private static void IncrementDispose()
        {
            Interlocked.Increment(ref _counterToDispose);
        }
    }
}