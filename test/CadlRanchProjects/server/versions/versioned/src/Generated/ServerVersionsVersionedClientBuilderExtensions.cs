// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core.Extensions;
using Server.Versions.Versioned;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="VersionedClient"/> to client builder. </summary>
    public static partial class ServerVersionsVersionedClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="VersionedClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The <see cref="Uri"/> to use. </param>
        public static IAzureClientBuilder<VersionedClient, VersionedClientOptions> AddVersionedClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<VersionedClient, VersionedClientOptions>((options) => new VersionedClient(endpoint, options));
        }

        /// <summary> Registers a <see cref="VersionedClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<VersionedClient, VersionedClientOptions> AddVersionedClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<VersionedClient, VersionedClientOptions>(configuration);
        }
    }
}
