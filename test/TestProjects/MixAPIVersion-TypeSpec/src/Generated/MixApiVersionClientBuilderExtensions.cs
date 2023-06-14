// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core.Extensions;
using MixApiVersion;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="MixApiVersionClient"/> to client builder. </summary>
    public static partial class MixApiVersionClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="MixApiVersionClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The Uri to use. </param>
        public static IAzureClientBuilder<MixApiVersionClient, MixApiVersionClientOptions> AddMixApiVersionClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<MixApiVersionClient, MixApiVersionClientOptions>((options) => new MixApiVersionClient(endpoint, options));
        }

        /// <summary> Registers a <see cref="MixApiVersionClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<MixApiVersionClient, MixApiVersionClientOptions> AddMixApiVersionClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<MixApiVersionClient, MixApiVersionClientOptions>(configuration);
        }
    }
}
