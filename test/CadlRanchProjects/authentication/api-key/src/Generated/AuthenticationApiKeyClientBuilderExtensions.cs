// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Authentication.ApiKey;
using Azure;
using Azure.Core.Extensions;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="ApiKeyClient"/> to client builder. </summary>
    public static partial class AuthenticationApiKeyClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="ApiKeyClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> TestServer endpoint. </param>
        public static IAzureClientBuilder<ApiKeyClient, ApiKeyClientOptions> AddApiKeyClient<TBuilder>(this TBuilder builder, AzureKeyCredential credential, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<ApiKeyClient, ApiKeyClientOptions>((options) => new ApiKeyClient(credential, endpoint, options));
        }

        /// <summary> Registers a <see cref="ApiKeyClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<ApiKeyClient, ApiKeyClientOptions> AddApiKeyClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<ApiKeyClient, ApiKeyClientOptions>(configuration);
        }
    }
}
