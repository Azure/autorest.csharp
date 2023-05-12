// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core.Extensions;
using endpoint;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="EndpointClient"/> to client builder. </summary>
    public static partial class EndpointClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="EndpointClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The Uri to use. </param>
        public static IAzureClientBuilder<EndpointClient, EndpointClientOptions> AddEndpointClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<EndpointClient, EndpointClientOptions>((options) => new EndpointClient(endpoint, options));
        }

        /// <summary> Registers a <see cref="EndpointClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<EndpointClient, EndpointClientOptions> AddEndpointClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<EndpointClient, EndpointClientOptions>(configuration);
        }
    }
}
