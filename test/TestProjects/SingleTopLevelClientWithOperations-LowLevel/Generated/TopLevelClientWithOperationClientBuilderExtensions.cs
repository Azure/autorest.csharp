// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure;
using Azure.Core.Extensions;
using SingleTopLevelClientWithOperations_LowLevel;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="TopLevelClientWithOperationClient"/> to client builder. </summary>
    public static partial class TopLevelClientWithOperationClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="TopLevelClientWithOperationClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        public static IAzureClientBuilder<TopLevelClientWithOperationClient, TopLevelClientWithOperationClientOptions> AddTopLevelClientWithOperationClient<TBuilder>(this TBuilder builder, AzureKeyCredential credential, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<TopLevelClientWithOperationClient, TopLevelClientWithOperationClientOptions>((options) => new TopLevelClientWithOperationClient(credential, endpoint, options));
        }

        /// <summary> Registers a <see cref="TopLevelClientWithOperationClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<TopLevelClientWithOperationClient, TopLevelClientWithOperationClientOptions> AddTopLevelClientWithOperationClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<TopLevelClientWithOperationClient, TopLevelClientWithOperationClientOptions>(configuration);
        }
    }
}
