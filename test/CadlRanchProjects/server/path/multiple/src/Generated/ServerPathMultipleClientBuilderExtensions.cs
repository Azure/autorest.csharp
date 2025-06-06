// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Diagnostics.CodeAnalysis;
using Azure.Core.Extensions;
using Server.Path.Multiple;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="MultipleClient"/> to client builder. </summary>
    public static partial class ServerPathMultipleClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="MultipleClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> Pass in http://localhost:3000 for endpoint. </param>
        public static IAzureClientBuilder<MultipleClient, MultipleClientOptions> AddMultipleClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<MultipleClient, MultipleClientOptions>((options) => new MultipleClient(endpoint, options));
        }

        /// <summary> Registers a <see cref="MultipleClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        [RequiresUnreferencedCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        [RequiresDynamicCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        public static IAzureClientBuilder<MultipleClient, MultipleClientOptions> AddMultipleClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<MultipleClient, MultipleClientOptions>(configuration);
        }
    }
}
