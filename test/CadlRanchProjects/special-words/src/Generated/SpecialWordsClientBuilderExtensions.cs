// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core.Extensions;
using SpecialWords;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="SpecialWordsClient"/> to client builder. </summary>
    public static partial class SpecialWordsClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="SpecialWordsClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> TestServer endpoint. </param>
        public static IAzureClientBuilder<SpecialWordsClient, SpecialWordsClientOptions> AddSpecialWordsClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<SpecialWordsClient, SpecialWordsClientOptions>((options) => new SpecialWordsClient(endpoint, options));
        }

        /// <summary> Registers a <see cref="SpecialWordsClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<SpecialWordsClient, SpecialWordsClientOptions> AddSpecialWordsClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<SpecialWordsClient, SpecialWordsClientOptions>(configuration);
        }
    }
}
