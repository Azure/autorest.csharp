// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core.Extensions;
using LroBasicTypeSpec;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="LroBasicTypeSpecClient"/> to client builder. </summary>
    public static partial class LroBasicTypeSpecClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="LroBasicTypeSpecClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The Uri to use. </param>
        public static IAzureClientBuilder<LroBasicTypeSpecClient, LroBasicTypeSpecClientOptions> AddLroBasicTypeSpecClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<LroBasicTypeSpecClient, LroBasicTypeSpecClientOptions>((options) => new LroBasicTypeSpecClient(endpoint, options));
        }

        /// <summary> Registers a <see cref="LroBasicTypeSpecClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<LroBasicTypeSpecClient, LroBasicTypeSpecClientOptions> AddLroBasicTypeSpecClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<LroBasicTypeSpecClient, LroBasicTypeSpecClientOptions>(configuration);
        }
    }
}
