// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using AnomalyDetector;
using Azure;
using Azure.Core.Extensions;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="AnomalyDetectorClient"/> to client builder. </summary>
    public static partial class AnomalyDetectorClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="AnomalyDetectorClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint">
        /// Supported Cognitive Services endpoints (protocol and hostname, for example:
        /// https://westus2.api.cognitive.microsoft.com).
        /// </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        public static IAzureClientBuilder<AnomalyDetectorClient, AnomalyDetectorClientOptions> AddAnomalyDetectorClient<TBuilder>(this TBuilder builder, Uri endpoint, AzureKeyCredential credential)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<AnomalyDetectorClient, AnomalyDetectorClientOptions>((options) => new AnomalyDetectorClient(endpoint, credential, options));
        }

        /// <summary> Registers a <see cref="AnomalyDetectorClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<AnomalyDetectorClient, AnomalyDetectorClientOptions> AddAnomalyDetectorClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<AnomalyDetectorClient, AnomalyDetectorClientOptions>(configuration);
        }
    }
}
