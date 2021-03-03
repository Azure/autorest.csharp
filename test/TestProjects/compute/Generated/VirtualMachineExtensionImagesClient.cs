// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using compute.Models;

namespace compute
{
    /// <summary> The VirtualMachineExtensionImages service client. </summary>
    public partial class VirtualMachineExtensionImagesClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal VirtualMachineExtensionImagesRestClient RestClient { get; }
        /// <summary> Initializes a new instance of VirtualMachineExtensionImagesClient for mocking. </summary>
        protected VirtualMachineExtensionImagesClient()
        {
        }
        /// <summary> Initializes a new instance of VirtualMachineExtensionImagesClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="apiVersion"> Api Version. </param>
        internal VirtualMachineExtensionImagesClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string subscriptionId, Uri endpoint = null, string apiVersion = "2020-06-01")
        {
            RestClient = new VirtualMachineExtensionImagesRestClient(clientDiagnostics, pipeline, subscriptionId, endpoint, apiVersion);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Gets a virtual machine extension image. </summary>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> The String to use. </param>
        /// <param name="type"> The String to use. </param>
        /// <param name="version"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<VirtualMachineExtensionImage>> GetAsync(string location, string publisherName, string type, string version, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineExtensionImagesClient.Get");
            scope.Start();
            try
            {
                return await RestClient.GetAsync(location, publisherName, type, version, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a virtual machine extension image. </summary>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> The String to use. </param>
        /// <param name="type"> The String to use. </param>
        /// <param name="version"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<VirtualMachineExtensionImage> Get(string location, string publisherName, string type, string version, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineExtensionImagesClient.Get");
            scope.Start();
            try
            {
                return RestClient.Get(location, publisherName, type, version, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a list of virtual machine extension image types. </summary>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<VirtualMachineExtensionImage>>> ListTypesAsync(string location, string publisherName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineExtensionImagesClient.ListTypes");
            scope.Start();
            try
            {
                return await RestClient.ListTypesAsync(location, publisherName, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a list of virtual machine extension image types. </summary>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<VirtualMachineExtensionImage>> ListTypes(string location, string publisherName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineExtensionImagesClient.ListTypes");
            scope.Start();
            try
            {
                return RestClient.ListTypes(location, publisherName, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a list of virtual machine extension image versions. </summary>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> The String to use. </param>
        /// <param name="type"> The String to use. </param>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="top"> The Integer to use. </param>
        /// <param name="orderby"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<VirtualMachineExtensionImage>>> ListVersionsAsync(string location, string publisherName, string type, string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineExtensionImagesClient.ListVersions");
            scope.Start();
            try
            {
                return await RestClient.ListVersionsAsync(location, publisherName, type, filter, top, orderby, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a list of virtual machine extension image versions. </summary>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> The String to use. </param>
        /// <param name="type"> The String to use. </param>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="top"> The Integer to use. </param>
        /// <param name="orderby"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<VirtualMachineExtensionImage>> ListVersions(string location, string publisherName, string type, string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineExtensionImagesClient.ListVersions");
            scope.Start();
            try
            {
                return RestClient.ListVersions(location, publisherName, type, filter, top, orderby, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
