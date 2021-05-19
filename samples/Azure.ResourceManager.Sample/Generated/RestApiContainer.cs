// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Sample
{
    public partial class RestApiContainer : ContainerBase
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;

        /// <summary> Represents the REST operations. </summary>
        private RestOperations _restClient => new RestOperations(_clientDiagnostics, _pipeline);
        /// <summary> Initializes a new instance of the <see cref="RestApiContainer"/> class for mocking. </summary>
        protected RestApiContainer()
        {
        }

        /// <summary> Initializes a new instance of RestApiContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal RestApiContainer(ResourceOperationsBase parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _pipeline = ManagementPipelineBuilder.Build(Credential, BaseUri, ClientOptions);
        }

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceIdentifier.RootResourceIdentifier.ResourceType;
    }
}
