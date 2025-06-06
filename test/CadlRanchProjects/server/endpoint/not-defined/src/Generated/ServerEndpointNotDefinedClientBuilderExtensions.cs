// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Diagnostics.CodeAnalysis;
using Azure.Core.Extensions;
using Server.Endpoint.NotDefined;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="NotDefinedClient"/> to client builder. </summary>
    public static partial class ServerEndpointNotDefinedClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="NotDefinedClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> Service host. </param>
        public static IAzureClientBuilder<NotDefinedClient, NotDefinedClientOptions> AddNotDefinedClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<NotDefinedClient, NotDefinedClientOptions>((options) => new NotDefinedClient(endpoint, options));
        }

        /// <summary> Registers a <see cref="NotDefinedClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        [RequiresUnreferencedCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        [RequiresDynamicCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        public static IAzureClientBuilder<NotDefinedClient, NotDefinedClientOptions> AddNotDefinedClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<NotDefinedClient, NotDefinedClientOptions>(configuration);
        }
    }
}
