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
        private static ITestServer _serverV1Cache;
        private static ITestServer _serverV2Cache;

        private readonly string _scenario;
        private readonly TestServerVersion _version;
        private readonly bool _allowUnmatched;
        private readonly string[] _expectedCoverage;

        public ITestServer Server { get; private set; }
        public string Host => Server.Host;

        private TestServerSession(string scenario, TestServerVersion version, bool allowUnmatched, string[] expectedCoverage)
        {
            _scenario = scenario;
            _version = version;
            _allowUnmatched = allowUnmatched;
            _expectedCoverage = expectedCoverage;
            Server = GetServer();
        }

        public static TestServerSession Start(string scenario, TestServerVersion version, bool allowUnmatched = false, params string[] expectedCoverage)
        {
            if (version == TestServerVersion.V2)
            {
                // we only use v1 for coverage
                expectedCoverage = Array.Empty<string>();
            }
            var server = new TestServerSession(scenario, version, allowUnmatched, expectedCoverage);
            return server;
        }

        private ref ITestServer GetServerCache()
        {
            switch (_version)
            {
                case TestServerVersion.V1:
                    return ref _serverV1Cache;
                case TestServerVersion.V2:
                    return ref _serverV2Cache;
            }
            throw new NotImplementedException();
        }

        private ITestServer CreateServer()
        {
            switch (_version)
            {
                case TestServerVersion.V1:
                    return new TestServerV1();
                case TestServerVersion.V2:
                    return new TestServerV2();
            }
            throw new NotImplementedException();
        }

        private ITestServer GetServer()
        {
            ITestServer server;
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
