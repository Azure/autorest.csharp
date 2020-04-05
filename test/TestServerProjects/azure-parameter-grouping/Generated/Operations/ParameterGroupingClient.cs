// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using azure_parameter_grouping.Models;

namespace azure_parameter_grouping
{
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
        internal ParameterGroupingClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            RestClient = new ParameterGroupingRestClient(_clientDiagnostics, _pipeline, host);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Post a bunch of required parameters grouped. </summary>
        /// <param name="parameterGroupingPostRequiredParameters"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PostRequiredAsync(ParameterGroupingPostRequiredParameters parameterGroupingPostRequiredParameters, CancellationToken cancellationToken = default)
        {
            return await RestClient.PostRequiredAsync(parameterGroupingPostRequiredParameters, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Post a bunch of required parameters grouped. </summary>
        /// <param name="parameterGroupingPostRequiredParameters"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PostRequired(ParameterGroupingPostRequiredParameters parameterGroupingPostRequiredParameters, CancellationToken cancellationToken = default)
        {
            return RestClient.PostRequired(parameterGroupingPostRequiredParameters, cancellationToken);
        }

        /// <summary> Post a bunch of optional parameters grouped. </summary>
        /// <param name="parameterGroupingPostOptionalParameters"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PostOptionalAsync(ParameterGroupingPostOptionalParameters parameterGroupingPostOptionalParameters = null, CancellationToken cancellationToken = default)
        {
            return await RestClient.PostOptionalAsync(parameterGroupingPostOptionalParameters, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Post a bunch of optional parameters grouped. </summary>
        /// <param name="parameterGroupingPostOptionalParameters"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PostOptional(ParameterGroupingPostOptionalParameters parameterGroupingPostOptionalParameters = null, CancellationToken cancellationToken = default)
        {
            return RestClient.PostOptional(parameterGroupingPostOptionalParameters, cancellationToken);
        }

        /// <summary> Post parameters from multiple different parameter groups. </summary>
        /// <param name="firstParameterGroup"> Parameter group. </param>
        /// <param name="parameterGroupingPostMultiParamGroupsSecondParamGroup"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PostMultiParamGroupsAsync(FirstParameterGroup firstParameterGroup = null, ParameterGroupingPostMultiParamGroupsSecondParamGroup parameterGroupingPostMultiParamGroupsSecondParamGroup = null, CancellationToken cancellationToken = default)
        {
            return await RestClient.PostMultiParamGroupsAsync(firstParameterGroup, parameterGroupingPostMultiParamGroupsSecondParamGroup, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Post parameters from multiple different parameter groups. </summary>
        /// <param name="firstParameterGroup"> Parameter group. </param>
        /// <param name="parameterGroupingPostMultiParamGroupsSecondParamGroup"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PostMultiParamGroups(FirstParameterGroup firstParameterGroup = null, ParameterGroupingPostMultiParamGroupsSecondParamGroup parameterGroupingPostMultiParamGroupsSecondParamGroup = null, CancellationToken cancellationToken = default)
        {
            return RestClient.PostMultiParamGroups(firstParameterGroup, parameterGroupingPostMultiParamGroupsSecondParamGroup, cancellationToken);
        }

        /// <summary> Post parameters with a shared parameter group object. </summary>
        /// <param name="firstParameterGroup"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PostSharedParameterGroupObjectAsync(FirstParameterGroup firstParameterGroup = null, CancellationToken cancellationToken = default)
        {
            return await RestClient.PostSharedParameterGroupObjectAsync(firstParameterGroup, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Post parameters with a shared parameter group object. </summary>
        /// <param name="firstParameterGroup"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PostSharedParameterGroupObject(FirstParameterGroup firstParameterGroup = null, CancellationToken cancellationToken = default)
        {
            return RestClient.PostSharedParameterGroupObject(firstParameterGroup, cancellationToken);
        }
    }
}
