// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure;
using Azure.Core.Extensions;
using httpInfrastructure_LowLevel;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="HttpFailureClient"/>, <see cref="HttpSuccessClient"/>, <see cref="HttpRedirectsClient"/>, <see cref="HttpClientFailureClient"/>, <see cref="HttpServerFailureClient"/>, <see cref="HttpRetryClient"/>, <see cref="MultipleResponsesClient"/> to client builder. </summary>
    public static partial class AutoRestHttpInfrastructureTestServiceClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="HttpFailureClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        public static IAzureClientBuilder<HttpFailureClient, AutoRestHttpInfrastructureTestServiceClientOptions> AddHttpFailureClient<TBuilder>(this TBuilder builder, AzureKeyCredential credential, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<HttpFailureClient, AutoRestHttpInfrastructureTestServiceClientOptions>((options) => new HttpFailureClient(credential, endpoint, options));
        }

        /// <summary> Registers a <see cref="HttpSuccessClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        public static IAzureClientBuilder<HttpSuccessClient, AutoRestHttpInfrastructureTestServiceClientOptions> AddHttpSuccessClient<TBuilder>(this TBuilder builder, AzureKeyCredential credential, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<HttpSuccessClient, AutoRestHttpInfrastructureTestServiceClientOptions>((options) => new HttpSuccessClient(credential, endpoint, options));
        }

        /// <summary> Registers a <see cref="HttpRedirectsClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        public static IAzureClientBuilder<HttpRedirectsClient, AutoRestHttpInfrastructureTestServiceClientOptions> AddHttpRedirectsClient<TBuilder>(this TBuilder builder, AzureKeyCredential credential, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<HttpRedirectsClient, AutoRestHttpInfrastructureTestServiceClientOptions>((options) => new HttpRedirectsClient(credential, endpoint, options));
        }

        /// <summary> Registers a <see cref="HttpClientFailureClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        public static IAzureClientBuilder<HttpClientFailureClient, AutoRestHttpInfrastructureTestServiceClientOptions> AddHttpClientFailureClient<TBuilder>(this TBuilder builder, AzureKeyCredential credential, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<HttpClientFailureClient, AutoRestHttpInfrastructureTestServiceClientOptions>((options) => new HttpClientFailureClient(credential, endpoint, options));
        }

        /// <summary> Registers a <see cref="HttpServerFailureClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        public static IAzureClientBuilder<HttpServerFailureClient, AutoRestHttpInfrastructureTestServiceClientOptions> AddHttpServerFailureClient<TBuilder>(this TBuilder builder, AzureKeyCredential credential, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<HttpServerFailureClient, AutoRestHttpInfrastructureTestServiceClientOptions>((options) => new HttpServerFailureClient(credential, endpoint, options));
        }

        /// <summary> Registers a <see cref="HttpRetryClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        public static IAzureClientBuilder<HttpRetryClient, AutoRestHttpInfrastructureTestServiceClientOptions> AddHttpRetryClient<TBuilder>(this TBuilder builder, AzureKeyCredential credential, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<HttpRetryClient, AutoRestHttpInfrastructureTestServiceClientOptions>((options) => new HttpRetryClient(credential, endpoint, options));
        }

        /// <summary> Registers a <see cref="MultipleResponsesClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        public static IAzureClientBuilder<MultipleResponsesClient, AutoRestHttpInfrastructureTestServiceClientOptions> AddMultipleResponsesClient<TBuilder>(this TBuilder builder, AzureKeyCredential credential, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<MultipleResponsesClient, AutoRestHttpInfrastructureTestServiceClientOptions>((options) => new MultipleResponsesClient(credential, endpoint, options));
        }

        /// <summary> Registers a <see cref="HttpFailureClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<HttpFailureClient, AutoRestHttpInfrastructureTestServiceClientOptions> AddHttpFailureClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<HttpFailureClient, AutoRestHttpInfrastructureTestServiceClientOptions>(configuration);
        }
        /// <summary> Registers a <see cref="HttpSuccessClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<HttpSuccessClient, AutoRestHttpInfrastructureTestServiceClientOptions> AddHttpSuccessClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<HttpSuccessClient, AutoRestHttpInfrastructureTestServiceClientOptions>(configuration);
        }
        /// <summary> Registers a <see cref="HttpRedirectsClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<HttpRedirectsClient, AutoRestHttpInfrastructureTestServiceClientOptions> AddHttpRedirectsClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<HttpRedirectsClient, AutoRestHttpInfrastructureTestServiceClientOptions>(configuration);
        }
        /// <summary> Registers a <see cref="HttpClientFailureClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<HttpClientFailureClient, AutoRestHttpInfrastructureTestServiceClientOptions> AddHttpClientFailureClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<HttpClientFailureClient, AutoRestHttpInfrastructureTestServiceClientOptions>(configuration);
        }
        /// <summary> Registers a <see cref="HttpServerFailureClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<HttpServerFailureClient, AutoRestHttpInfrastructureTestServiceClientOptions> AddHttpServerFailureClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<HttpServerFailureClient, AutoRestHttpInfrastructureTestServiceClientOptions>(configuration);
        }
        /// <summary> Registers a <see cref="HttpRetryClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<HttpRetryClient, AutoRestHttpInfrastructureTestServiceClientOptions> AddHttpRetryClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<HttpRetryClient, AutoRestHttpInfrastructureTestServiceClientOptions>(configuration);
        }
        /// <summary> Registers a <see cref="MultipleResponsesClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<MultipleResponsesClient, AutoRestHttpInfrastructureTestServiceClientOptions> AddMultipleResponsesClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<MultipleResponsesClient, AutoRestHttpInfrastructureTestServiceClientOptions>(configuration);
        }
    }
}
