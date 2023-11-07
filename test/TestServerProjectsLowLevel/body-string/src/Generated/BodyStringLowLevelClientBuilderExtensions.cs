// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure;
using Azure.Core.Extensions;
using body_string_LowLevel;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="StringClient"/>, <see cref="EnumClient"/> to client builder. </summary>
    public static partial class BodyStringLowLevelClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="StringClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        public static IAzureClientBuilder<StringClient, AutoRestSwaggerBATServiceClientOptions> AddStringClient<TBuilder>(this TBuilder builder, AzureKeyCredential credential)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<StringClient, AutoRestSwaggerBATServiceClientOptions>((options) => new StringClient(credential, options));
        }

        /// <summary> Registers a <see cref="EnumClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        public static IAzureClientBuilder<EnumClient, AutoRestSwaggerBATServiceClientOptions> AddEnumClient<TBuilder>(this TBuilder builder, AzureKeyCredential credential)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<EnumClient, AutoRestSwaggerBATServiceClientOptions>((options) => new EnumClient(credential, options));
        }

        /// <summary> Registers a <see cref="StringClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<StringClient, AutoRestSwaggerBATServiceClientOptions> AddStringClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<StringClient, AutoRestSwaggerBATServiceClientOptions>(configuration);
        }
        /// <summary> Registers a <see cref="EnumClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<EnumClient, AutoRestSwaggerBATServiceClientOptions> AddEnumClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<EnumClient, AutoRestSwaggerBATServiceClientOptions>(configuration);
        }
    }
}
