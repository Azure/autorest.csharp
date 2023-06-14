// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure;
using Azure.Core.Extensions;
using SecurityDefinition_LowLevel;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="SecurityDefinitionClient"/> to client builder. </summary>
    public static partial class SecurityDefinitionClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="SecurityDefinitionClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        public static IAzureClientBuilder<SecurityDefinitionClient, SecurityDefinitionClientOptions> AddSecurityDefinitionClient<TBuilder>(this TBuilder builder, Uri endpoint, AzureKeyCredential credential)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<SecurityDefinitionClient, SecurityDefinitionClientOptions>((options) => new SecurityDefinitionClient(endpoint, credential, options));
        }

        /// <summary> Registers a <see cref="SecurityDefinitionClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> server parameter. </param>
        public static IAzureClientBuilder<SecurityDefinitionClient, SecurityDefinitionClientOptions> AddSecurityDefinitionClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<SecurityDefinitionClient, SecurityDefinitionClientOptions>((options, cred) => new SecurityDefinitionClient(endpoint, cred, options));
        }

        /// <summary> Registers a <see cref="SecurityDefinitionClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<SecurityDefinitionClient, SecurityDefinitionClientOptions> AddSecurityDefinitionClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<SecurityDefinitionClient, SecurityDefinitionClientOptions>(configuration);
        }
    }
}
