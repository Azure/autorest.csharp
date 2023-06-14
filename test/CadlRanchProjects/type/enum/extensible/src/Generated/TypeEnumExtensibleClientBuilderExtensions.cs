// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core.Extensions;
using _Type._Enum.Extensible;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="ExtensibleClient"/> to client builder. </summary>
    public static partial class TypeEnumExtensibleClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="ExtensibleClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> TestServer endpoint. </param>
        public static IAzureClientBuilder<ExtensibleClient, ExtensibleClientOptions> AddExtensibleClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<ExtensibleClient, ExtensibleClientOptions>((options) => new ExtensibleClient(endpoint, options));
        }

        /// <summary> Registers a <see cref="ExtensibleClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<ExtensibleClient, ExtensibleClientOptions> AddExtensibleClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<ExtensibleClient, ExtensibleClientOptions>(configuration);
        }
    }
}
