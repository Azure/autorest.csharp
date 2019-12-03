// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AutoRest.TestServer.Tests
{
    public class TestServerSession : IAsyncDisposable
    {
        private static readonly object _serverCacheLock = new object();
        private static TestServer _serverCache;

        private readonly bool _allowUnmatched;
        private readonly string[] _expectedCoverage;

        public TestServer Server { get; private set; }
        public string Host => Server.Host;

        private TestServerSession(TestServer server, bool allowUnmatched, string[] expectedCoverage)
        {
            Server = server;
            _allowUnmatched = allowUnmatched;
            _expectedCoverage = expectedCoverage;
        }

        public static TestServerSession Start(params string[] expectedCoverage)
        {
            return Start(false, expectedCoverage);
        }

        public static TestServerSession Start(bool allowUnmatched, params string[] expectedCoverage)
        {
            var server = new TestServerSession(GetServer(), allowUnmatched, expectedCoverage);
            return server;
        }

        private static TestServer GetServer()
        {
            TestServer server;
            lock (_serverCacheLock)
            {
                server = _serverCache;
                _serverCache = null;
            }

            if (server == null)
            {
                server = new TestServer();
                server.StartProcess();
            }

            return server;
        }

        public ValueTask DisposeAsync() => DisposeAsync(false);

        public async ValueTask DisposeAsync(bool ignoreChecks)
        {
            try
            {
                if (!ignoreChecks && !_allowUnmatched)
                {
                    var unmatched = await Server.GetUnmatchedRequests();
                    if (unmatched.Any())
                    {
                        throw new InvalidOperationException($"Unexpected unmatched requests {string.Join(Environment.NewLine, unmatched)}");
                    }
                }

                if (!ignoreChecks && _expectedCoverage != null)
                {
                    var matched = await Server.GetMatchedStubs();
                    foreach (var expectedStub in _expectedCoverage)
                    {
                        if (!matched.Contains(expectedStub))
                        {
                            throw new InvalidOperationException($"Expected stub {expectedStub} was not matched, matched: {string.Join(Environment.NewLine, matched)}");
                        }
                    }
                }
            }
            finally
            {

                await Server.ResetAsync();
                bool disposeServer = true;
                lock (_serverCacheLock)
                {
                    if (_serverCache == null)
                    {
                        _serverCache = Server;
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
}
