// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace FirstTestTypeSpec
{

    public partial class FirstTestTypeSpecClient
    {
        /// <summary>
        /// Constructor for testing purpose. Bearer token check policy is removed.
        /// </summary>
        /// <param name="endpoint"></param>
        public FirstTestTypeSpecClient(Uri endpoint)
        {
            if (endpoint is null)
            {
                throw new ArgumentNullException(nameof(endpoint));
            }

            var options = new FirstTestTypeSpecClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { }, new ResponseClassifier());
            _endpoint = endpoint;
        }

        /// <summary>
        /// Constructor for testing purpose. See if we could include a constructor that takes an array as parameter
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="credential"></param>
        /// <param name="authorizationScopes"></param>
        public FirstTestTypeSpecClient(Uri endpoint, TokenCredential credential, string[] authorizationScopes)
        {}
    }
}
