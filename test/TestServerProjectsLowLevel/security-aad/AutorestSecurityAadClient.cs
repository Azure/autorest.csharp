// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace security_aad_LowLevel
{
    [CodeGenSuppress("AutorestSecurityAadClient", typeof(TokenCredential), typeof(Uri), typeof(AutorestSecurityAadClientOptions))]
    public partial class AutorestSecurityAadClient
    {
        /// <summary> Initializes a new instance of AutorestSecurityAadClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> or <paramref name="endpoint"/> is null. </exception>
        public AutorestSecurityAadClient(TokenCredential credential, Uri endpoint, AutorestSecurityAadClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new AutorestSecurityAadClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _tokenCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new MockBearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes) }, new ResponseClassifier());
            _endpoint = endpoint;
        }

        // Only for bypassing HTTPS check purpose
        public class MockBearerTokenAuthenticationPolicy : BearerTokenAuthenticationPolicy
        {
            public MockBearerTokenAuthenticationPolicy(TokenCredential credential, IEnumerable<string> scopes) : base(credential, scopes) { }

            public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                return ProcessAsync(message, pipeline, true);
            }

            public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                ProcessAsync(message, pipeline, false).EnsureCompleted();
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
