// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core.Extensions;
using _Type._Array;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="ArrayClient"/> to client builder. </summary>
    public static partial class TypeArrayClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="ArrayClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> TestServer endpoint. </param>
        public static IAzureClientBuilder<ArrayClient, ArrayClientOptions> AddArrayClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<ArrayClient, ArrayClientOptions>((options) => new ArrayClient(endpoint, options));
        }

        /// <summary> Registers a <see cref="ArrayClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<ArrayClient, ArrayClientOptions> AddArrayClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<ArrayClient, ArrayClientOptions>(configuration);
        }
    }
}
