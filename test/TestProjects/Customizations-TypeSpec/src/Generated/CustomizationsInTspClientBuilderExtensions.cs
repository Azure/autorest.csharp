// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Diagnostics.CodeAnalysis;
using Azure.Core.Extensions;
using CustomizationsInTsp;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="CustomizationsInTspClient"/> to client builder. </summary>
    public static partial class CustomizationsInTspClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="CustomizationsInTspClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> Service host. </param>
        public static IAzureClientBuilder<CustomizationsInTspClient, CustomizationsInTspClientOptions> AddCustomizationsInTspClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<CustomizationsInTspClient, CustomizationsInTspClientOptions>((options) => new CustomizationsInTspClient(endpoint, options));
        }

        /// <summary> Registers a <see cref="CustomizationsInTspClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        [RequiresUnreferencedCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        [RequiresDynamicCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        public static IAzureClientBuilder<CustomizationsInTspClient, CustomizationsInTspClientOptions> AddCustomizationsInTspClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<CustomizationsInTspClient, CustomizationsInTspClientOptions>(configuration);
        }
    }
}
