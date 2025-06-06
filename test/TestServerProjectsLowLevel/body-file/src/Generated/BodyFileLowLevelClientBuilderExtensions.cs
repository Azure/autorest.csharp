// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Diagnostics.CodeAnalysis;
using Azure;
using Azure.Core.Extensions;
using body_file_LowLevel;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="FilesClient"/> to client builder. </summary>
    public static partial class BodyFileLowLevelClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="FilesClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        public static IAzureClientBuilder<FilesClient, FilesClientOptions> AddFilesClient<TBuilder>(this TBuilder builder, Uri endpoint, AzureKeyCredential credential)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<FilesClient, FilesClientOptions>((options) => new FilesClient(endpoint, credential, options));
        }

        /// <summary> Registers a <see cref="FilesClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        [RequiresUnreferencedCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        [RequiresDynamicCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        public static IAzureClientBuilder<FilesClient, FilesClientOptions> AddFilesClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<FilesClient, FilesClientOptions>(configuration);
        }
    }
}
