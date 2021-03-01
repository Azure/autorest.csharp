// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using azure_parameter_grouping.Models;

namespace azure_parameter_grouping
{
    /// <summary> The ParameterGrouping service client. </summary>
    public partial class ParameterGroupingClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal ParameterGroupingRestClient RestClient { get; }

        /// <summary> Initializes a new instance of ParameterGroupingClient for mocking. </summary>
        protected ParameterGroupingClient()
        {
        }

        /// <summary> Initializes a new instance of ParameterGroupingClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        internal ParameterGroupingClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            RestClient = new ParameterGroupingRestClient(clientDiagnostics, pipeline, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Post a bunch of required parameters grouped. </summary>
        /// <param name="parameterGroupingPostRequiredParameters"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PostRequiredAsync(ParameterGroupingPostRequiredParameters parameterGroupingPostRequiredParameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ParameterGroupingClient.PostRequired");
            scope.Start();
            try
            {
                return await RestClient.PostRequiredAsync(parameterGroupingPostRequiredParameters, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Post a bunch of required parameters grouped. </summary>
        /// <param name="parameterGroupingPostRequiredParameters"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PostRequired(ParameterGroupingPostRequiredParameters parameterGroupingPostRequiredParameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ParameterGroupingClient.PostRequired");
            scope.Start();
            try
            {
                return RestClient.PostRequired(parameterGroupingPostRequiredParameters, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Post a bunch of optional parameters grouped. </summary>
        /// <param name="parameterGroupingPostOptionalParameters"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PostOptionalAsync(ParameterGroupingPostOptionalParameters parameterGroupingPostOptionalParameters = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ParameterGroupingClient.PostOptional");
            scope.Start();
            try
            {
                return await RestClient.PostOptionalAsync(parameterGroupingPostOptionalParameters, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Post a bunch of optional parameters grouped. </summary>
        /// <param name="parameterGroupingPostOptionalParameters"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PostOptional(ParameterGroupingPostOptionalParameters parameterGroupingPostOptionalParameters = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ParameterGroupingClient.PostOptional");
            scope.Start();
            try
            {
                return RestClient.PostOptional(parameterGroupingPostOptionalParameters, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Post parameters from multiple different parameter groups. </summary>
        /// <param name="firstParameterGroup"> Parameter group. </param>
        /// <param name="parameterGroupingPostMultiParamGroupsSecondParamGroup"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PostMultiParamGroupsAsync(FirstParameterGroup firstParameterGroup = null, ParameterGroupingPostMultiParamGroupsSecondParamGroup parameterGroupingPostMultiParamGroupsSecondParamGroup = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ParameterGroupingClient.PostMultiParamGroups");
            scope.Start();
            try
            {
                return await RestClient.PostMultiParamGroupsAsync(firstParameterGroup, parameterGroupingPostMultiParamGroupsSecondParamGroup, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Post parameters from multiple different parameter groups. </summary>
        /// <param name="firstParameterGroup"> Parameter group. </param>
        /// <param name="parameterGroupingPostMultiParamGroupsSecondParamGroup"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PostMultiParamGroups(FirstParameterGroup firstParameterGroup = null, ParameterGroupingPostMultiParamGroupsSecondParamGroup parameterGroupingPostMultiParamGroupsSecondParamGroup = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ParameterGroupingClient.PostMultiParamGroups");
            scope.Start();
            try
            {
                return RestClient.PostMultiParamGroups(firstParameterGroup, parameterGroupingPostMultiParamGroupsSecondParamGroup, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Post parameters with a shared parameter group object. </summary>
        /// <param name="firstParameterGroup"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PostSharedParameterGroupObjectAsync(FirstParameterGroup firstParameterGroup = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ParameterGroupingClient.PostSharedParameterGroupObject");
            scope.Start();
            try
            {
                return await RestClient.PostSharedParameterGroupObjectAsync(firstParameterGroup, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Post parameters with a shared parameter group object. </summary>
        /// <param name="firstParameterGroup"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PostSharedParameterGroupObject(FirstParameterGroup firstParameterGroup = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ParameterGroupingClient.PostSharedParameterGroupObject");
            scope.Start();
            try
            {
                return RestClient.PostSharedParameterGroupObject(firstParameterGroup, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
