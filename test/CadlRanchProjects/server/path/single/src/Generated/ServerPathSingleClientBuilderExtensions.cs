// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core.Extensions;
using Server.Path.Single;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="SingleClient"/> to client builder. </summary>
    public static partial class ServerPathSingleClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="SingleClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> Need to be set as 'http://localhost:3000' in client. </param>
        public static IAzureClientBuilder<SingleClient, SingleClientOptions> AddSingleClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<SingleClient, SingleClientOptions>((options) => new SingleClient(endpoint, options));
        }

        /// <summary> Registers a <see cref="SingleClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<SingleClient, SingleClientOptions> AddSingleClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<SingleClient, SingleClientOptions>(configuration);
        }
    }
}
