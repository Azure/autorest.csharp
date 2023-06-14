// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.ClientAndOperationGroupService;
using Azure.Core.Extensions;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="ClientAndOperationGroupServiceClient"/> to client builder. </summary>
    public static partial class AzureClientAndOperationGroupServiceClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="ClientAndOperationGroupServiceClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The Uri to use. </param>
        public static IAzureClientBuilder<ClientAndOperationGroupServiceClient, ClientAndOperationGroupServiceClientOptions> AddClientAndOperationGroupServiceClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<ClientAndOperationGroupServiceClient, ClientAndOperationGroupServiceClientOptions>((options) => new ClientAndOperationGroupServiceClient(endpoint, options));
        }

        /// <summary> Registers a <see cref="ClientAndOperationGroupServiceClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<ClientAndOperationGroupServiceClient, ClientAndOperationGroupServiceClientOptions> AddClientAndOperationGroupServiceClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<ClientAndOperationGroupServiceClient, ClientAndOperationGroupServiceClientOptions>(configuration);
        }
    }
}
