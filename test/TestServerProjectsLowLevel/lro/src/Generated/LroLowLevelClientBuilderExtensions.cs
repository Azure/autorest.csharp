// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Diagnostics.CodeAnalysis;
using Azure;
using Azure.Core.Extensions;
using lro_LowLevel;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="LROsClient"/>, <see cref="LRORetrysClient"/>, <see cref="LrosaDsClient"/>, <see cref="LROsCustomHeaderClient"/> to client builder. </summary>
    public static partial class LroLowLevelClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="LROsClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        public static IAzureClientBuilder<LROsClient, AutoRestLongRunningOperationTestServiceClientOptions> AddLROsClient<TBuilder>(this TBuilder builder, Uri endpoint, AzureKeyCredential credential)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<LROsClient, AutoRestLongRunningOperationTestServiceClientOptions>((options) => new LROsClient(endpoint, credential, options));
        }

        /// <summary> Registers a <see cref="LRORetrysClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        public static IAzureClientBuilder<LRORetrysClient, AutoRestLongRunningOperationTestServiceClientOptions> AddLRORetrysClient<TBuilder>(this TBuilder builder, Uri endpoint, AzureKeyCredential credential)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<LRORetrysClient, AutoRestLongRunningOperationTestServiceClientOptions>((options) => new LRORetrysClient(endpoint, credential, options));
        }

        /// <summary> Registers a <see cref="LrosaDsClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        public static IAzureClientBuilder<LrosaDsClient, AutoRestLongRunningOperationTestServiceClientOptions> AddLrosaDsClient<TBuilder>(this TBuilder builder, Uri endpoint, AzureKeyCredential credential)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<LrosaDsClient, AutoRestLongRunningOperationTestServiceClientOptions>((options) => new LrosaDsClient(endpoint, credential, options));
        }

        /// <summary> Registers a <see cref="LROsCustomHeaderClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        public static IAzureClientBuilder<LROsCustomHeaderClient, AutoRestLongRunningOperationTestServiceClientOptions> AddLROsCustomHeaderClient<TBuilder>(this TBuilder builder, Uri endpoint, AzureKeyCredential credential)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<LROsCustomHeaderClient, AutoRestLongRunningOperationTestServiceClientOptions>((options) => new LROsCustomHeaderClient(endpoint, credential, options));
        }

        /// <summary> Registers a <see cref="LROsClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        [RequiresUnreferencedCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        [RequiresDynamicCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        public static IAzureClientBuilder<LROsClient, AutoRestLongRunningOperationTestServiceClientOptions> AddLROsClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<LROsClient, AutoRestLongRunningOperationTestServiceClientOptions>(configuration);
        }
        /// <summary> Registers a <see cref="LRORetrysClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        [RequiresUnreferencedCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        [RequiresDynamicCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        public static IAzureClientBuilder<LRORetrysClient, AutoRestLongRunningOperationTestServiceClientOptions> AddLRORetrysClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<LRORetrysClient, AutoRestLongRunningOperationTestServiceClientOptions>(configuration);
        }
        /// <summary> Registers a <see cref="LrosaDsClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        [RequiresUnreferencedCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        [RequiresDynamicCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        public static IAzureClientBuilder<LrosaDsClient, AutoRestLongRunningOperationTestServiceClientOptions> AddLrosaDsClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<LrosaDsClient, AutoRestLongRunningOperationTestServiceClientOptions>(configuration);
        }
        /// <summary> Registers a <see cref="LROsCustomHeaderClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        [RequiresUnreferencedCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        [RequiresDynamicCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        public static IAzureClientBuilder<LROsCustomHeaderClient, AutoRestLongRunningOperationTestServiceClientOptions> AddLROsCustomHeaderClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<LROsCustomHeaderClient, AutoRestLongRunningOperationTestServiceClientOptions>(configuration);
        }
    }
}
