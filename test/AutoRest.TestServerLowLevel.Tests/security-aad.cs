using System;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure.Core;
using NUnit.Framework;
using security_aad_LowLevel;

namespace AutoRest.TestServer.Tests
{
    public class SecurityAadTest : TestServerLowLevelTestBase
    {
        [Test]
        public Task SecurityAad() => Test(async (host) =>
        {
            await new AutorestSecurityAadClient(new MockCredential()).HeadAsync();
        });

        public class MockCredential : TokenCredential
        {
            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                return new(GetToken(requestContext, cancellationToken));
            }

            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                return new AccessToken(string.Join(" ", requestContext.Scopes), DateTimeOffset.MaxValue);
            }
        }
    }
}
