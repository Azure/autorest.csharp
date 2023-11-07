// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core.Extensions;
using Projection.ProjectedName;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="ProjectedNameClient"/> to client builder. </summary>
    public static partial class ProjectionProjectedNameClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="ProjectedNameClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        public static IAzureClientBuilder<ProjectedNameClient, ProjectedNameClientOptions> AddProjectedNameClient<TBuilder>(this TBuilder builder)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<ProjectedNameClient, ProjectedNameClientOptions>((options) => new ProjectedNameClient(options));
        }

        /// <summary> Registers a <see cref="ProjectedNameClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<ProjectedNameClient, ProjectedNameClientOptions> AddProjectedNameClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<ProjectedNameClient, ProjectedNameClientOptions>(configuration);
        }
    }
}
