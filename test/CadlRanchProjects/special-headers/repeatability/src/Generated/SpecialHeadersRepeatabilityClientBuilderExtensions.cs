// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core.Extensions;
using SpecialHeaders.Repeatability;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="RepeatabilityClient"/> to client builder. </summary>
    public static partial class SpecialHeadersRepeatabilityClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="RepeatabilityClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The <see cref="Uri"/> to use. </param>
        public static IAzureClientBuilder<RepeatabilityClient, RepeatabilityClientOptions> AddRepeatabilityClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<RepeatabilityClient, RepeatabilityClientOptions>((options) => new RepeatabilityClient(endpoint, options));
        }

        /// <summary> Registers a <see cref="RepeatabilityClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<RepeatabilityClient, RepeatabilityClientOptions> AddRepeatabilityClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<RepeatabilityClient, RepeatabilityClientOptions>(configuration);
        }
    }
}
