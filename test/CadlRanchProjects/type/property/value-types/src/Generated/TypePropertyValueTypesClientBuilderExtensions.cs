// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core.Extensions;
using _Type.Property.ValueTypes;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="ValueTypesClient"/> to client builder. </summary>
    public static partial class TypePropertyValueTypesClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="ValueTypesClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> TestServer endpoint. </param>
        public static IAzureClientBuilder<ValueTypesClient, ValueTypesClientOptions> AddValueTypesClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<ValueTypesClient, ValueTypesClientOptions>((options) => new ValueTypesClient(endpoint, options));
        }

        /// <summary> Registers a <see cref="ValueTypesClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<ValueTypesClient, ValueTypesClientOptions> AddValueTypesClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<ValueTypesClient, ValueTypesClientOptions>(configuration);
        }
    }
}
