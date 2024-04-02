// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Analytics.Purview.Account;
using Azure.Core.Extensions;
using AzureSample.Analytics.Purview.Account;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="PurviewAccountsClient"/>, <see cref="PurviewAccountCollections"/>, <see cref="PurviewAccountResourceSetRules"/> to client builder. </summary>
    public static partial class AzureSampleAnalyticsPurviewAccountClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="PurviewAccountsClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The account endpoint of your Purview account. Example: https://{accountName}.purview.azure.com/account/. </param>
        public static IAzureClientBuilder<PurviewAccountsClient, PurviewAccountClientOptions> AddPurviewAccountsClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<PurviewAccountsClient, PurviewAccountClientOptions>((options, cred) => new PurviewAccountsClient(endpoint, cred, options));
        }

        /// <summary> Registers a <see cref="PurviewAccountCollections"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The account endpoint of your Purview account. Example: https://{accountName}.purview.azure.com/account/. </param>
        /// <param name="collectionName"> The <see cref="string"/> to use. </param>
        public static IAzureClientBuilder<PurviewAccountCollections, PurviewAccountClientOptions> AddPurviewAccountCollections<TBuilder>(this TBuilder builder, Uri endpoint, string collectionName)
        where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<PurviewAccountCollections, PurviewAccountClientOptions>((options, cred) => new PurviewAccountCollections(endpoint, collectionName, cred, options));
        }

        /// <summary> Registers a <see cref="PurviewAccountResourceSetRules"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The account endpoint of your Purview account. Example: https://{accountName}.purview.azure.com/account/. </param>
        public static IAzureClientBuilder<PurviewAccountResourceSetRules, PurviewAccountClientOptions> AddPurviewAccountResourceSetRules<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<PurviewAccountResourceSetRules, PurviewAccountClientOptions>((options, cred) => new PurviewAccountResourceSetRules(endpoint, cred, options));
        }

        /// <summary> Registers a <see cref="PurviewAccountsClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<PurviewAccountsClient, PurviewAccountClientOptions> AddPurviewAccountsClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<PurviewAccountsClient, PurviewAccountClientOptions>(configuration);
        }
        /// <summary> Registers a <see cref="PurviewAccountCollections"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<PurviewAccountCollections, PurviewAccountClientOptions> AddPurviewAccountCollections<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<PurviewAccountCollections, PurviewAccountClientOptions>(configuration);
        }
        /// <summary> Registers a <see cref="PurviewAccountResourceSetRules"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<PurviewAccountResourceSetRules, PurviewAccountClientOptions> AddPurviewAccountResourceSetRules<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<PurviewAccountResourceSetRules, PurviewAccountClientOptions>(configuration);
        }
    }
}
