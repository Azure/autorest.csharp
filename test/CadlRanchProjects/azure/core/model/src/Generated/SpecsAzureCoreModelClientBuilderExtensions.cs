// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core.Extensions;
using _Specs_.Azure.Core.Model;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="ModelClient"/> to client builder. </summary>
    public static partial class SpecsAzureCoreModelClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="ModelClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> TestServer endpoint. </param>
        public static IAzureClientBuilder<ModelClient, ModelClientOptions> AddModelClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<ModelClient, ModelClientOptions>((options) => new ModelClient(endpoint, options));
        }

        /// <summary> Registers a <see cref="ModelClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<ModelClient, ModelClientOptions> AddModelClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<ModelClient, ModelClientOptions>(configuration);
        }
    }
}
