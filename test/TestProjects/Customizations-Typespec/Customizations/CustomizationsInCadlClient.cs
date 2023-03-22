// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace CustomizationsInCadl
{
    // Data plane generated client.
    /// <summary> CADL project to test various types of models. </summary>
    public partial class CustomizationsInCadlClient
    {
        /// <summary>
        /// Initializes a new instance of CustomizationsInCadlClient.
        /// We make this constructor internal here only to show how it would change the generated code
        /// </summary>
        internal CustomizationsInCadlClient() : this(new CustomizationsInCadlClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of CustomizationsInCadlClient.
        /// We make this constructor internal here only to show how it would change the generated code
        /// </summary>
        /// <param name="options"> The options for configuring the client. </param>
        internal CustomizationsInCadlClient(CustomizationsInCadlClientOptions options)
        {
            options ??= new CustomizationsInCadlClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _apiVersion = options.Version;
        }
    }
}
