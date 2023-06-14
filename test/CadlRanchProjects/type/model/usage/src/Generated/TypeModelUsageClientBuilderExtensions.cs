// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core.Extensions;
using _Type.Model.Usage;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="UsageClient"/> to client builder. </summary>
    public static partial class TypeModelUsageClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="UsageClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> TestServer endpoint. </param>
        public static IAzureClientBuilder<UsageClient, UsageClientOptions> AddUsageClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<UsageClient, UsageClientOptions>((options) => new UsageClient(endpoint, options));
        }

        /// <summary> Registers a <see cref="UsageClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<UsageClient, UsageClientOptions> AddUsageClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<UsageClient, UsageClientOptions>(configuration);
        }
    }
}
