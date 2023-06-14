// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core.Extensions;
using ModelsTypeSpec;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="ModelsTypeSpecClient"/> to client builder. </summary>
    public static partial class ModelsTypeSpecClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="ModelsTypeSpecClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The Uri to use. </param>
        public static IAzureClientBuilder<ModelsTypeSpecClient, ModelsTypeSpecClientOptions> AddModelsTypeSpecClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<ModelsTypeSpecClient, ModelsTypeSpecClientOptions>((options) => new ModelsTypeSpecClient(endpoint, options));
        }

        /// <summary> Registers a <see cref="ModelsTypeSpecClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<ModelsTypeSpecClient, ModelsTypeSpecClientOptions> AddModelsTypeSpecClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<ModelsTypeSpecClient, ModelsTypeSpecClientOptions>(configuration);
        }
    }
}
