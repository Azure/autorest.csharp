// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core.Extensions;
using Encode.Duration;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="DurationClient"/> to client builder. </summary>
    public static partial class EncodeDurationClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="DurationClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> TestServer endpoint. </param>
        public static IAzureClientBuilder<DurationClient, DurationClientOptions> AddDurationClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<DurationClient, DurationClientOptions>((options) => new DurationClient(endpoint, options));
        }

        /// <summary> Registers a <see cref="DurationClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<DurationClient, DurationClientOptions> AddDurationClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<DurationClient, DurationClientOptions>(configuration);
        }
    }
}
