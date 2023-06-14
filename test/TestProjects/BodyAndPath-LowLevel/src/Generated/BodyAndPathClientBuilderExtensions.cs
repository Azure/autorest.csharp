// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure;
using Azure.Core.Extensions;
using BodyAndPath_LowLevel;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="BodyAndPathClient"/> to client builder. </summary>
    public static partial class BodyAndPathClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="BodyAndPathClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        public static IAzureClientBuilder<BodyAndPathClient, BodyAndPathClientOptions> AddBodyAndPathClient<TBuilder>(this TBuilder builder, AzureKeyCredential credential, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<BodyAndPathClient, BodyAndPathClientOptions>((options) => new BodyAndPathClient(credential, endpoint, options));
        }

        /// <summary> Registers a <see cref="BodyAndPathClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<BodyAndPathClient, BodyAndPathClientOptions> AddBodyAndPathClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<BodyAndPathClient, BodyAndPathClientOptions>(configuration);
        }
    }
}
