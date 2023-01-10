// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using Azure.Core;
using System;

namespace Pagination
{
    public partial class PaginationClient
    {
        public static string[] TokenScopes => AuthorizationScopes;

        public PaginationClient(Uri endpoint, TokenCredential credential, PaginationClientOptions options, BearerTokenAuthenticationPolicy tokenPolicy)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new PaginationClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _tokenCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { tokenPolicy }, new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }
    }
}
