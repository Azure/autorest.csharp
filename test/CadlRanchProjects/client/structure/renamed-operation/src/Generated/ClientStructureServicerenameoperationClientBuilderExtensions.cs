// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Diagnostics.CodeAnalysis;
using Azure.Core.Extensions;
using Client.Structure.Service.rename.operation;
using Client.Structure.Service.rename.operation.Models;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="RenamedOperationClient"/> to client builder. </summary>
    public static partial class ClientStructureServicerenameoperationClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="RenamedOperationClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> Need to be set as 'http://localhost:3000' in client. </param>
        /// <param name="client"> Need to be set as 'default', 'multi-client', 'renamed-operation', 'two-operation-group' in client. </param>
        public static IAzureClientBuilder<RenamedOperationClient, RenamedOperationClientOptions> AddRenamedOperationClient<TBuilder>(this TBuilder builder, Uri endpoint, ClientType client)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<RenamedOperationClient, RenamedOperationClientOptions>((options) => new RenamedOperationClient(endpoint, client, options));
        }

        /// <summary> Registers a <see cref="RenamedOperationClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        [RequiresUnreferencedCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        [RequiresDynamicCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        public static IAzureClientBuilder<RenamedOperationClient, RenamedOperationClientOptions> AddRenamedOperationClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<RenamedOperationClient, RenamedOperationClientOptions>(configuration);
        }
    }
}
