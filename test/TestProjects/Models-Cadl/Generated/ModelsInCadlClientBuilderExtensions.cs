// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core.Extensions;
using ModelsInCadl;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add clients to client builder. </summary>
    public static partial class ModelsInCadlClientBuilderExtensions
    {
        /// <param name="builder"></param>
        public static IAzureClientBuilder<ModelsInCadlClient, ModelsInCadlClientOptions> AddModelsInCadlClient<TBuilder>(TBuilder builder)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<ModelsInCadlClient, ModelsInCadlClientOptions>((options) => new ModelsInCadlClient(options));
        }
    }
}
