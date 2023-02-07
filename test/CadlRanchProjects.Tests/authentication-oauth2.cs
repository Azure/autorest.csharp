// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using NUnit.Framework;
using Authentication.OAuth2;
using Azure.Core.Pipeline;
using Azure.Core;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System;
using System.Reflection;
using NUnit.Framework.Internal;

namespace CadlRanchProjects.Tests
{
    public class AuthenticationOAuth2Tests: CadlRanchTestBase
    {
        [Test]
        public Task Authentication_OAuth2_valid() => Test(async (host) =>
        {
            var options = new OAuth2ClientOptions();
            options.AddPolicy(new MockBearerTokenAuthenticationPolicy(new MockCredential(), OAuth2Client.TokenScopes, options.Transport), HttpPipelinePosition.PerCall);
            Response response = await new OAuth2Client(new MockCredential(), host, options).ValidAsync();
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Authentication_OAuth2_invalid() => Test((host) =>
        {
            var options = new OAuth2ClientOptions();
            options.AddPolicy(new MockBearerTokenAuthenticationPolicy(new MockCredential(), OAuth2Client.TokenScopes, options.Transport), HttpPipelinePosition.PerCall);

            var exception = Assert.ThrowsAsync<RequestFailedException>(() => new OAuth2Client(new MockCredential(), host, options).InvalidAsync());
            Assert.AreEqual(403, exception.Status);
            return Task.CompletedTask;
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

        // Only for bypassing HTTPS check purpose
        public class MockBearerTokenAuthenticationPolicy : BearerTokenAuthenticationPolicy
        {
            private readonly HttpPipelineTransport _transport;

            public MockBearerTokenAuthenticationPolicy(TokenCredential credential, IEnumerable<string> scopes, HttpPipelineTransport transport) : base(credential, scopes)
            {
                _transport = transport;
            }

            public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                return ProcessAsync(message, pipeline, true);
            }

            public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                ProcessAsync(message, pipeline, false).EnsureCompleted();
            }

            protected new async ValueTask ProcessNextAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                await _transport.ProcessAsync(message).ConfigureAwait(false);

                var response = message.Response;
                Type responseType = response.GetType();
                PropertyInfo propInfo = responseType.GetProperty("IsError", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                propInfo.SetValue(response, message.ResponseClassifier.IsErrorResponse(message));
            }

            protected new void ProcessNext(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                _transport.Process(message);
            }

            private async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
            {
                if (async)
                {
                    await AuthorizeRequestAsync(message).ConfigureAwait(false);
                    await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
                }
                else
                {
                    AuthorizeRequest(message);
                    ProcessNext(message, pipeline);
                }

                // Check if we have received a challenge or we have not yet issued the first request.
                if (message.Response.Status == (int)HttpStatusCode.Unauthorized && message.Response.Headers.Contains(HttpHeader.Names.WwwAuthenticate))
                {
                    // Attempt to get the TokenRequestContext based on the challenge.
                    // If we fail to get the context, the challenge was not present or invalid.
                    // If we succeed in getting the context, authenticate the request and pass it up the policy chain.
                    if (async)
                    {
                        if (await AuthorizeRequestOnChallengeAsync(message).ConfigureAwait(false))
                        {
                            await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
                        }
                    }
                    else
                    {
                        if (AuthorizeRequestOnChallenge(message))
                        {
                            ProcessNext(message, pipeline);
                        }
                    }
                }
            }
        }
    }
}
