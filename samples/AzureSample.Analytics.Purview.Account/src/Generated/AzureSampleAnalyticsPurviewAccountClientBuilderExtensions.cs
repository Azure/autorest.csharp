// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Diagnostics.CodeAnalysis;
using Azure.Analytics.Purview.Account;
using Azure.Core.Extensions;
using AzureSample.Analytics.Purview.Account;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="PurviewAccountsClient"/> to client builder. </summary>
    public static partial class AzureSampleAnalyticsPurviewAccountClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="PurviewAccountsClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The account endpoint of your Purview account. Example: https://{accountName}.purview.azure.com/account/. </param>
        public static IAzureClientBuilder<PurviewAccountsClient, PurviewAccountsClientOptions> AddPurviewAccountsClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<PurviewAccountsClient, PurviewAccountsClientOptions>((options, cred) => new PurviewAccountsClient(endpoint, cred, options));
        }

        /// <summary> Registers a <see cref="PurviewAccountsClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        [RequiresUnreferencedCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        [RequiresDynamicCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        public static IAzureClientBuilder<PurviewAccountsClient, PurviewAccountsClientOptions> AddPurviewAccountsClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<PurviewAccountsClient, PurviewAccountsClientOptions>(configuration);
        }
    }
}
