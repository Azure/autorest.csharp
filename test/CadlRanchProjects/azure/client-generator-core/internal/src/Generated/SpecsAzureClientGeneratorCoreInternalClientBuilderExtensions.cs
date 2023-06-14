// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core.Extensions;
using _Specs_.Azure.ClientGenerator.Core.Internal;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="InternalClient"/> to client builder. </summary>
    public static partial class SpecsAzureClientGeneratorCoreInternalClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="InternalClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> TestServer endpoint. </param>
        public static IAzureClientBuilder<InternalClient, InternalClientOptions> AddInternalClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<InternalClient, InternalClientOptions>((options) => new InternalClient(endpoint, options));
        }

        /// <summary> Registers a <see cref="InternalClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<InternalClient, InternalClientOptions> AddInternalClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<InternalClient, InternalClientOptions>(configuration);
        }
    }
}
