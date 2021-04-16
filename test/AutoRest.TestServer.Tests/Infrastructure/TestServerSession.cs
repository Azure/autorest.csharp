// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRest.TestServer.Tests.Infrastructure
{
    public class TestServerSession : IAsyncDisposable
    {
        private static readonly object _serverCacheLock = new object();
        private static TestServerV1 _serverV1Cache;

        private readonly string _scenario;
        private readonly bool _allowUnmatched;
        private readonly string[] _expectedCoverage;

        public TestServerV1 Server { get; private set; }
        public Uri Host => Server.Host;

        private TestServerSession(string scenario, bool allowUnmatched, string[] expectedCoverage)
        {
            _scenario = scenario;
            _allowUnmatched = allowUnmatched;
            _expectedCoverage = expectedCoverage;
            Server = GetServer();
        }

        public static TestServerSession Start(string scenario, bool allowUnmatched = false, params string[] expectedCoverage)
        {
            var server = new TestServerSession(scenario, allowUnmatched, expectedCoverage);
            return server;
        }

        private ref TestServerV1 GetServerCache()
        {
            return ref _serverV1Cache;
        }

        private TestServerV1 CreateServer()
        {
            return new TestServerV1();
        }

        private TestServerV1 GetServer()
        {
            TestServerV1 server;
            lock (_serverCacheLock)
            {
                ref var cache = ref GetServerCache();
                server = cache;
                cache = null;
            }

            if (server == null)
            {
                server = CreateServer();
            }

            return server;
        }

        public ValueTask DisposeAsync() => DisposeAsync(false);

        public async ValueTask DisposeAsync(bool ignoreChecks)
        {
            try
            {
                var matched = await Server.GetMatchedStubs(_scenario);

                if (!ignoreChecks && !_allowUnmatched)
                {
                    var requests = await Server.GetRequests();
                    if (requests.Any())
                    {
                        throw new InvalidOperationException($"Some requests were not matched {string.Join(Environment.NewLine, requests)}");
                    }
                }

                if (!ignoreChecks && _expectedCoverage != null)
                {
                    foreach (var expectedStub in _expectedCoverage)
                    {
                        if (!matched.Contains(expectedStub, StringComparer.InvariantCultureIgnoreCase))
                        {
                            throw new InvalidOperationException($"Expected stub {expectedStub} was not matched, matched: {string.Join(Environment.NewLine, matched)}");
                        }
                    }
                }
            }
            finally
            {
                await Server.ResetAsync();
                Return();
            }
        }

        private void Return()
        {
            bool disposeServer = true;
            lock (_serverCacheLock)
            {
                ref var cache = ref GetServerCache();
                if (cache == null)
                {
                    cache = Server;
                    Server = null;
                    disposeServer = false;
                }
            }

            if (disposeServer)
            {
                Server?.Dispose();
            }
        }
    }
}
