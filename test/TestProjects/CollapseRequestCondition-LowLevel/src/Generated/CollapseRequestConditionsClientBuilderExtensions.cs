// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure;
using Azure.Core.Extensions;
using CollapseRequestCondition_LowLevel;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="RequestConditionCollapseClient"/>, <see cref="MatchConditionCollapseClient"/>, <see cref="NonCollapseClient"/> to client builder. </summary>
    public static partial class CollapseRequestConditionsClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="RequestConditionCollapseClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        public static IAzureClientBuilder<RequestConditionCollapseClient, CollapseRequestConditionsClientOptions> AddRequestConditionCollapseClient<TBuilder>(this TBuilder builder, AzureKeyCredential credential, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<RequestConditionCollapseClient, CollapseRequestConditionsClientOptions>((options) => new RequestConditionCollapseClient(credential, endpoint, options));
        }

        /// <summary> Registers a <see cref="MatchConditionCollapseClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        public static IAzureClientBuilder<MatchConditionCollapseClient, CollapseRequestConditionsClientOptions> AddMatchConditionCollapseClient<TBuilder>(this TBuilder builder, AzureKeyCredential credential, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<MatchConditionCollapseClient, CollapseRequestConditionsClientOptions>((options) => new MatchConditionCollapseClient(credential, endpoint, options));
        }

        /// <summary> Registers a <see cref="NonCollapseClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        public static IAzureClientBuilder<NonCollapseClient, CollapseRequestConditionsClientOptions> AddNonCollapseClient<TBuilder>(this TBuilder builder, AzureKeyCredential credential, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<NonCollapseClient, CollapseRequestConditionsClientOptions>((options) => new NonCollapseClient(credential, endpoint, options));
        }

        /// <summary> Registers a <see cref="RequestConditionCollapseClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<RequestConditionCollapseClient, CollapseRequestConditionsClientOptions> AddRequestConditionCollapseClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<RequestConditionCollapseClient, CollapseRequestConditionsClientOptions>(configuration);
        }
        /// <summary> Registers a <see cref="MatchConditionCollapseClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<MatchConditionCollapseClient, CollapseRequestConditionsClientOptions> AddMatchConditionCollapseClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<MatchConditionCollapseClient, CollapseRequestConditionsClientOptions>(configuration);
        }
        /// <summary> Registers a <see cref="NonCollapseClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<NonCollapseClient, CollapseRequestConditionsClientOptions> AddNonCollapseClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<NonCollapseClient, CollapseRequestConditionsClientOptions>(configuration);
        }
    }
}
