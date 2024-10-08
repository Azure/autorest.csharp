// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core.Extensions;
using _Type.Union;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="UnionClient"/> to client builder. </summary>
    public static partial class TypeUnionClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="UnionClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The <see cref="Uri"/> to use. </param>
        public static IAzureClientBuilder<UnionClient, UnionClientOptions> AddUnionClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<UnionClient, UnionClientOptions>((options) => new UnionClient(endpoint, options));
        }

        /// <summary> Registers a <see cref="UnionClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<UnionClient, UnionClientOptions> AddUnionClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<UnionClient, UnionClientOptions>(configuration);
        }
    }
}
