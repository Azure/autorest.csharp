// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using ApiVersionInCadl;
using Azure;
using Azure.Core.Extensions;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add clients to client builder. </summary>
    public static partial class ApiVersionInCadlClientBuilderExtensions
    {
        /// <param name="builder"></param>
        /// <param name="endpoint">
        /// Supported Cognitive Services endpoints (protocol and hostname, for example:
        /// https://westus2.api.cognitive.microsoft.com).
        /// </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        public static IAzureClientBuilder<ApiVersionInCadlClient, ApiVersionInCadlClientOptions> AddApiVersionInCadlClient<TBuilder>(this TBuilder builder, Uri endpoint, AzureKeyCredential credential)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<ApiVersionInCadlClient, ApiVersionInCadlClientOptions>((options) => new ApiVersionInCadlClient(endpoint, credential, options));
        }

        /// <param name="builder"></param>
        /// <param name="configuration"></param>
        public static IAzureClientBuilder<ApiVersionInCadlClient, ApiVersionInCadlClientOptions> AddApiVersionInCadlClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<ApiVersionInCadlClient, ApiVersionInCadlClientOptions>(configuration);
        }
    }
}
