// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core.Extensions;
using MultipleMediaTypes;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="MultipleMediaTypesClient"/> to client builder. </summary>
    public static partial class MultipleMediaTypesClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="MultipleMediaTypesClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The Uri to use. </param>
        public static IAzureClientBuilder<MultipleMediaTypesClient, MultipleMediaTypesClientOptions> AddMultipleMediaTypesClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<MultipleMediaTypesClient, MultipleMediaTypesClientOptions>((options) => new MultipleMediaTypesClient(endpoint, options));
        }

        /// <summary> Registers a <see cref="MultipleMediaTypesClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<MultipleMediaTypesClient, MultipleMediaTypesClientOptions> AddMultipleMediaTypesClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<MultipleMediaTypesClient, MultipleMediaTypesClientOptions>(configuration);
        }
    }
}
