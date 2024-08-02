// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core.Extensions;
using _Type.Property.Nullable;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="NullableClient"/> to client builder. </summary>
    public static partial class TypePropertyNullableClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="NullableClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The <see cref="string"/> to use. </param>
        public static IAzureClientBuilder<NullableClient, NullableClientOptions> AddNullableClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<NullableClient, NullableClientOptions>((options) => new NullableClient(endpoint, options));
        }

        /// <summary> Registers a <see cref="NullableClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<NullableClient, NullableClientOptions> AddNullableClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<NullableClient, NullableClientOptions>(configuration);
        }
    }
}
