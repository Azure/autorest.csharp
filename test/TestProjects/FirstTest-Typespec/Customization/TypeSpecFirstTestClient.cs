// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace TypeSpecFirstTest
{

    public partial class TypeSpecFirstTestClient
    {
        /// <summary>
        /// Constructor for testing purpose. Bearer token check policy is removed.
        /// </summary>
        /// <param name="endpoint"></param>
        public TypeSpecFirstTestClient(Uri endpoint)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            var options = new TypeSpecFirstTestClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { }, new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }
    }
}
