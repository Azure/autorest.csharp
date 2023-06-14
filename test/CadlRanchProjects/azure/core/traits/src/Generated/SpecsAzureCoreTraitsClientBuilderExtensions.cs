// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core.Extensions;
using _Specs_.Azure.Core.Traits;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="TraitsClient"/> to client builder. </summary>
    public static partial class SpecsAzureCoreTraitsClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="TraitsClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> TestServer endpoint. </param>
        public static IAzureClientBuilder<TraitsClient, TraitsClientOptions> AddTraitsClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<TraitsClient, TraitsClientOptions>((options) => new TraitsClient(endpoint, options));
        }

        /// <summary> Registers a <see cref="TraitsClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<TraitsClient, TraitsClientOptions> AddTraitsClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<TraitsClient, TraitsClientOptions>(configuration);
        }
    }
}
