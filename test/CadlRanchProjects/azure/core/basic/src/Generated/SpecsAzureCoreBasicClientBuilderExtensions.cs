// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core.Extensions;
using _Specs_.Azure.Core.Basic;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="BasicClient"/> to client builder. </summary>
    public static partial class SpecsAzureCoreBasicClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="BasicClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> TestServer endpoint. </param>
        public static IAzureClientBuilder<BasicClient, BasicClientOptions> AddBasicClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<BasicClient, BasicClientOptions>((options) => new BasicClient(endpoint, options));
        }

        /// <summary> Registers a <see cref="BasicClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<BasicClient, BasicClientOptions> AddBasicClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<BasicClient, BasicClientOptions>(configuration);
        }
    }
}
