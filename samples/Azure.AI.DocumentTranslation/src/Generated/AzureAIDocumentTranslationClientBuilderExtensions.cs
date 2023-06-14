// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;
using Azure.AI.DocumentTranslation;
using Azure.Core.Extensions;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="DocumentTranslationClient"/> to client builder. </summary>
    public static partial class AzureAIDocumentTranslationClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="DocumentTranslationClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> Supported Cognitive Services endpoints (protocol and hostname, for example: https://westus.api.cognitive.microsoft.com). </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        public static IAzureClientBuilder<DocumentTranslationClient, DocumentTranslationClientOptions> AddDocumentTranslationClient<TBuilder>(this TBuilder builder, string endpoint, AzureKeyCredential credential)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<DocumentTranslationClient, DocumentTranslationClientOptions>((options) => new DocumentTranslationClient(endpoint, credential, options));
        }

        /// <summary> Registers a <see cref="DocumentTranslationClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<DocumentTranslationClient, DocumentTranslationClientOptions> AddDocumentTranslationClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<DocumentTranslationClient, DocumentTranslationClientOptions>(configuration);
        }
    }
}
