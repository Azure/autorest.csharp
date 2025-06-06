// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Diagnostics.CodeAnalysis;
using Azure.Core.Extensions;
using Versioning.ReturnTypeChangedFrom;
using Versioning.ReturnTypeChangedFrom.Models;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="ReturnTypeChangedFromClient"/> to client builder. </summary>
    public static partial class VersioningReturnTypeChangedFromClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="ReturnTypeChangedFromClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> Need to be set as 'http://localhost:3000' in client. </param>
        /// <param name="version"> Need to be set as 'v1' or 'v2' in client. </param>
        public static IAzureClientBuilder<ReturnTypeChangedFromClient, ReturnTypeChangedFromClientOptions> AddReturnTypeChangedFromClient<TBuilder>(this TBuilder builder, Uri endpoint, Versions version)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<ReturnTypeChangedFromClient, ReturnTypeChangedFromClientOptions>((options) => new ReturnTypeChangedFromClient(endpoint, version, options));
        }

        /// <summary> Registers a <see cref="ReturnTypeChangedFromClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        [RequiresUnreferencedCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        [RequiresDynamicCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        public static IAzureClientBuilder<ReturnTypeChangedFromClient, ReturnTypeChangedFromClientOptions> AddReturnTypeChangedFromClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<ReturnTypeChangedFromClient, ReturnTypeChangedFromClientOptions>(configuration);
        }
    }
}
