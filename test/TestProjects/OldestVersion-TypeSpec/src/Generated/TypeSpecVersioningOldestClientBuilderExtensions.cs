// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core.Extensions;
using TypeSpec.Versioning.Oldest;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="OldestClient"/> to client builder. </summary>
    public static partial class TypeSpecVersioningOldestClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="OldestClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> Service host. </param>
        public static IAzureClientBuilder<OldestClient, OldestClientOptions> AddOldestClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<OldestClient, OldestClientOptions>((options) => new OldestClient(endpoint, options));
        }

        /// <summary> Registers a <see cref="OldestClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<OldestClient, OldestClientOptions> AddOldestClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<OldestClient, OldestClientOptions>(configuration);
        }
    }
}
