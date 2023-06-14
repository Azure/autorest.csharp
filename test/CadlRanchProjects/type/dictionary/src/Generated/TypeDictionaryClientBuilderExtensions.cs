// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core.Extensions;
using _Type._Dictionary;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="DictionaryClient"/> to client builder. </summary>
    public static partial class TypeDictionaryClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="DictionaryClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> TestServer endpoint. </param>
        public static IAzureClientBuilder<DictionaryClient, DictionaryClientOptions> AddDictionaryClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<DictionaryClient, DictionaryClientOptions>((options) => new DictionaryClient(endpoint, options));
        }

        /// <summary> Registers a <see cref="DictionaryClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<DictionaryClient, DictionaryClientOptions> AddDictionaryClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<DictionaryClient, DictionaryClientOptions>(configuration);
        }
    }
}
