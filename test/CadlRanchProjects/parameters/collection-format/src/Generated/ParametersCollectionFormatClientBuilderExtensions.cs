// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core.Extensions;
using Parameters.CollectionFormat;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="CollectionFormatClient"/> to client builder. </summary>
    public static partial class ParametersCollectionFormatClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="CollectionFormatClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> TestServer endpoint. </param>
        public static IAzureClientBuilder<CollectionFormatClient, CollectionFormatClientOptions> AddCollectionFormatClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<CollectionFormatClient, CollectionFormatClientOptions>((options) => new CollectionFormatClient(endpoint, options));
        }

        /// <summary> Registers a <see cref="CollectionFormatClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<CollectionFormatClient, CollectionFormatClientOptions> AddCollectionFormatClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<CollectionFormatClient, CollectionFormatClientOptions>(configuration);
        }
    }
}
