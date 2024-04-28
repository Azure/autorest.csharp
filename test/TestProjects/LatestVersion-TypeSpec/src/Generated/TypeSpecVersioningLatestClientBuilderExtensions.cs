// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core.Extensions;
using TypeSpec.Versioning.Latest;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="LatestClient"/> to client builder. </summary>
    public static partial class TypeSpecVersioningLatestClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="LatestClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> Service endpoint. </param>
        public static IAzureClientBuilder<LatestClient, LatestClientOptions> AddLatestClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<LatestClient, LatestClientOptions>((options) => new LatestClient(endpoint, options));
        }

        /// <summary> Registers a <see cref="LatestClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<LatestClient, LatestClientOptions> AddLatestClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<LatestClient, LatestClientOptions>(configuration);
        }
    }
}
