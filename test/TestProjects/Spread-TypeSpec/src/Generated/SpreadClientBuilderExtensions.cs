// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core.Extensions;
using Spread;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="SpreadClient"/> to client builder. </summary>
    public static partial class SpreadClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="SpreadClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The Uri to use. </param>
        public static IAzureClientBuilder<SpreadClient, SpreadClientOptions> AddSpreadClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<SpreadClient, SpreadClientOptions>((options) => new SpreadClient(endpoint, options));
        }

        /// <summary> Registers a <see cref="SpreadClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<SpreadClient, SpreadClientOptions> AddSpreadClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<SpreadClient, SpreadClientOptions>(configuration);
        }
    }
}
