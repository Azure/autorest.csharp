// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace CadlFirstTest
{

    public partial class CadlFirstTestClient
    {
        /// <summary>
        /// Constructor for testing purpose. Bearer token check policy is removed.
        /// </summary>
        /// <param name="endpoint"></param>
        public CadlFirstTestClient(Uri endpoint)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            var options = new CadlFirstTestClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { }, new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }
    }
}
