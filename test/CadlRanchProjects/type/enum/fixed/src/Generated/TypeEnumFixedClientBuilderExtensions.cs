// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core.Extensions;
using _Type._Enum.Fixed;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="FixedClient"/> to client builder. </summary>
    public static partial class TypeEnumFixedClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="FixedClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> TestServer endpoint. </param>
        public static IAzureClientBuilder<FixedClient, FixedClientOptions> AddFixedClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<FixedClient, FixedClientOptions>((options) => new FixedClient(endpoint, options));
        }

        /// <summary> Registers a <see cref="FixedClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<FixedClient, FixedClientOptions> AddFixedClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<FixedClient, FixedClientOptions>(configuration);
        }
    }
}
