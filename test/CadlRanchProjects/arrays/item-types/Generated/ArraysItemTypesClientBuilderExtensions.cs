// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Arrays.ItemTypes;
using Azure.Core.Extensions;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="ItemTypesClient"/> to client builder. </summary>
    public static partial class ArraysItemTypesClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="ItemTypesClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> TestServer endpoint. </param>
        public static IAzureClientBuilder<ItemTypesClient, ItemTypesClientOptions> AddItemTypesClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<ItemTypesClient, ItemTypesClientOptions>((options) => new ItemTypesClient(endpoint, options));
        }

        /// <summary> Registers a <see cref="ItemTypesClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<ItemTypesClient, ItemTypesClientOptions> AddItemTypesClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<ItemTypesClient, ItemTypesClientOptions>(configuration);
        }
    }
}
