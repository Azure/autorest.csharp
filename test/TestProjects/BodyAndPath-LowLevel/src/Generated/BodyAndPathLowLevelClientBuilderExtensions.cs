// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Diagnostics.CodeAnalysis;
using Azure;
using Azure.Core.Extensions;
using BodyAndPath_LowLevel;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="BodyAndPathClient"/> to client builder. </summary>
    public static partial class BodyAndPathLowLevelClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="BodyAndPathClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        public static IAzureClientBuilder<BodyAndPathClient, BodyAndPathClientOptions> AddBodyAndPathClient<TBuilder>(this TBuilder builder, Uri endpoint, AzureKeyCredential credential)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<BodyAndPathClient, BodyAndPathClientOptions>((options) => new BodyAndPathClient(endpoint, credential, options));
        }

        /// <summary> Registers a <see cref="BodyAndPathClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        [RequiresUnreferencedCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        [RequiresDynamicCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        public static IAzureClientBuilder<BodyAndPathClient, BodyAndPathClientOptions> AddBodyAndPathClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<BodyAndPathClient, BodyAndPathClientOptions>(configuration);
        }
    }
}
