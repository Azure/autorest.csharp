// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure;
using Azure.Core.Extensions;
using body_complex_LowLevel;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="BasicClient"/>, <see cref="PrimitiveClient"/>, <see cref="ArrayClient"/>, <see cref="DictionaryClient"/>, <see cref="InheritanceClient"/>, <see cref="PolymorphismClient"/>, <see cref="PolymorphicrecursiveClient"/>, <see cref="ReadonlypropertyClient"/>, <see cref="FlattencomplexClient"/> to client builder. </summary>
    public static partial class AutoRestComplexTestServiceClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="BasicClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        public static IAzureClientBuilder<BasicClient, AutoRestComplexTestServiceClientOptions> AddBasicClient<TBuilder>(this TBuilder builder, AzureKeyCredential credential, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<BasicClient, AutoRestComplexTestServiceClientOptions>((options) => new BasicClient(credential, endpoint, options));
        }

        /// <summary> Registers a <see cref="PrimitiveClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        public static IAzureClientBuilder<PrimitiveClient, AutoRestComplexTestServiceClientOptions> AddPrimitiveClient<TBuilder>(this TBuilder builder, AzureKeyCredential credential, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<PrimitiveClient, AutoRestComplexTestServiceClientOptions>((options) => new PrimitiveClient(credential, endpoint, options));
        }

        /// <summary> Registers a <see cref="ArrayClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        public static IAzureClientBuilder<ArrayClient, AutoRestComplexTestServiceClientOptions> AddArrayClient<TBuilder>(this TBuilder builder, AzureKeyCredential credential, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<ArrayClient, AutoRestComplexTestServiceClientOptions>((options) => new ArrayClient(credential, endpoint, options));
        }

        /// <summary> Registers a <see cref="DictionaryClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        public static IAzureClientBuilder<DictionaryClient, AutoRestComplexTestServiceClientOptions> AddDictionaryClient<TBuilder>(this TBuilder builder, AzureKeyCredential credential, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<DictionaryClient, AutoRestComplexTestServiceClientOptions>((options) => new DictionaryClient(credential, endpoint, options));
        }

        /// <summary> Registers a <see cref="InheritanceClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        public static IAzureClientBuilder<InheritanceClient, AutoRestComplexTestServiceClientOptions> AddInheritanceClient<TBuilder>(this TBuilder builder, AzureKeyCredential credential, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<InheritanceClient, AutoRestComplexTestServiceClientOptions>((options) => new InheritanceClient(credential, endpoint, options));
        }

        /// <summary> Registers a <see cref="PolymorphismClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        public static IAzureClientBuilder<PolymorphismClient, AutoRestComplexTestServiceClientOptions> AddPolymorphismClient<TBuilder>(this TBuilder builder, AzureKeyCredential credential, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<PolymorphismClient, AutoRestComplexTestServiceClientOptions>((options) => new PolymorphismClient(credential, endpoint, options));
        }

        /// <summary> Registers a <see cref="PolymorphicrecursiveClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        public static IAzureClientBuilder<PolymorphicrecursiveClient, AutoRestComplexTestServiceClientOptions> AddPolymorphicrecursiveClient<TBuilder>(this TBuilder builder, AzureKeyCredential credential, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<PolymorphicrecursiveClient, AutoRestComplexTestServiceClientOptions>((options) => new PolymorphicrecursiveClient(credential, endpoint, options));
        }

        /// <summary> Registers a <see cref="ReadonlypropertyClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        public static IAzureClientBuilder<ReadonlypropertyClient, AutoRestComplexTestServiceClientOptions> AddReadonlypropertyClient<TBuilder>(this TBuilder builder, AzureKeyCredential credential, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<ReadonlypropertyClient, AutoRestComplexTestServiceClientOptions>((options) => new ReadonlypropertyClient(credential, endpoint, options));
        }

        /// <summary> Registers a <see cref="FlattencomplexClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        public static IAzureClientBuilder<FlattencomplexClient, AutoRestComplexTestServiceClientOptions> AddFlattencomplexClient<TBuilder>(this TBuilder builder, AzureKeyCredential credential, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<FlattencomplexClient, AutoRestComplexTestServiceClientOptions>((options) => new FlattencomplexClient(credential, endpoint, options));
        }

        /// <summary> Registers a <see cref="BasicClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<BasicClient, AutoRestComplexTestServiceClientOptions> AddBasicClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<BasicClient, AutoRestComplexTestServiceClientOptions>(configuration);
        }
        /// <summary> Registers a <see cref="PrimitiveClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<PrimitiveClient, AutoRestComplexTestServiceClientOptions> AddPrimitiveClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<PrimitiveClient, AutoRestComplexTestServiceClientOptions>(configuration);
        }
        /// <summary> Registers a <see cref="ArrayClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<ArrayClient, AutoRestComplexTestServiceClientOptions> AddArrayClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<ArrayClient, AutoRestComplexTestServiceClientOptions>(configuration);
        }
        /// <summary> Registers a <see cref="DictionaryClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<DictionaryClient, AutoRestComplexTestServiceClientOptions> AddDictionaryClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<DictionaryClient, AutoRestComplexTestServiceClientOptions>(configuration);
        }
        /// <summary> Registers a <see cref="InheritanceClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<InheritanceClient, AutoRestComplexTestServiceClientOptions> AddInheritanceClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<InheritanceClient, AutoRestComplexTestServiceClientOptions>(configuration);
        }
        /// <summary> Registers a <see cref="PolymorphismClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<PolymorphismClient, AutoRestComplexTestServiceClientOptions> AddPolymorphismClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<PolymorphismClient, AutoRestComplexTestServiceClientOptions>(configuration);
        }
        /// <summary> Registers a <see cref="PolymorphicrecursiveClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<PolymorphicrecursiveClient, AutoRestComplexTestServiceClientOptions> AddPolymorphicrecursiveClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<PolymorphicrecursiveClient, AutoRestComplexTestServiceClientOptions>(configuration);
        }
        /// <summary> Registers a <see cref="ReadonlypropertyClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<ReadonlypropertyClient, AutoRestComplexTestServiceClientOptions> AddReadonlypropertyClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<ReadonlypropertyClient, AutoRestComplexTestServiceClientOptions>(configuration);
        }
        /// <summary> Registers a <see cref="FlattencomplexClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<FlattencomplexClient, AutoRestComplexTestServiceClientOptions> AddFlattencomplexClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<FlattencomplexClient, AutoRestComplexTestServiceClientOptions>(configuration);
        }
    }
}
