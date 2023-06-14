// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core.Extensions;
using _Type.Property.Optional;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="OptionalClient"/> to client builder. </summary>
    public static partial class TypePropertyOptionalClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="OptionalClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> TestServer endpoint. </param>
        public static IAzureClientBuilder<OptionalClient, OptionalClientOptions> AddOptionalClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<OptionalClient, OptionalClientOptions>((options) => new OptionalClient(endpoint, options));
        }

        /// <summary> Registers a <see cref="OptionalClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<OptionalClient, OptionalClientOptions> AddOptionalClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<OptionalClient, OptionalClientOptions>(configuration);
        }
    }
}
