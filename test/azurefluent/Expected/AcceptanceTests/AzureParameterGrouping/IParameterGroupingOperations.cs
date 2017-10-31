// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>

namespace Fixtures.Azure.Fluent.AcceptanceTestsAzureParameterGrouping
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// ParameterGroupingOperations operations.
    /// </summary>
    public partial interface IParameterGroupingOperations
    {
        IParameterGroupingOperationsWithHttpMessages WithHttpMessages();

        /// <summary>
        /// Post a bunch of required parameters grouped
        /// </summary>
        /// <param name='parameterGroupingPostRequiredParameters'>
        /// Additional parameters for the operation
        /// </param>
        void PostRequired(ParameterGroupingPostRequiredParametersInner parameterGroupingPostRequiredParameters);

        /// <summary>
        /// Post a bunch of required parameters grouped
        /// </summary>
        /// <param name='parameterGroupingPostRequiredParameters'>
        /// Additional parameters for the operation
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task PostRequiredAsync(ParameterGroupingPostRequiredParametersInner parameterGroupingPostRequiredParameters, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Post a bunch of optional parameters grouped
        /// </summary>
        /// <param name='parameterGroupingPostOptionalParameters'>
        /// Additional parameters for the operation
        /// </param>
        void PostOptional(ParameterGroupingPostOptionalParametersInner parameterGroupingPostOptionalParameters = default(ParameterGroupingPostOptionalParametersInner));

        /// <summary>
        /// Post a bunch of optional parameters grouped
        /// </summary>
        /// <param name='parameterGroupingPostOptionalParameters'>
        /// Additional parameters for the operation
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task PostOptionalAsync(ParameterGroupingPostOptionalParametersInner parameterGroupingPostOptionalParameters = default(ParameterGroupingPostOptionalParametersInner), CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Post parameters from multiple different parameter groups
        /// </summary>
        /// <param name='firstParameterGroup'>
        /// Additional parameters for the operation
        /// </param>
        /// <param name='parameterGroupingPostMultiParamGroupsSecondParamGroup'>
        /// Additional parameters for the operation
        /// </param>
        void PostMultiParamGroups(FirstParameterGroupInner firstParameterGroup = default(FirstParameterGroupInner), ParameterGroupingPostMultiParamGroupsSecondParamGroupInner parameterGroupingPostMultiParamGroupsSecondParamGroup = default(ParameterGroupingPostMultiParamGroupsSecondParamGroupInner));

        /// <summary>
        /// Post parameters from multiple different parameter groups
        /// </summary>
        /// <param name='firstParameterGroup'>
        /// Additional parameters for the operation
        /// </param>
        /// <param name='parameterGroupingPostMultiParamGroupsSecondParamGroup'>
        /// Additional parameters for the operation
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task PostMultiParamGroupsAsync(FirstParameterGroupInner firstParameterGroup = default(FirstParameterGroupInner), ParameterGroupingPostMultiParamGroupsSecondParamGroupInner parameterGroupingPostMultiParamGroupsSecondParamGroup = default(ParameterGroupingPostMultiParamGroupsSecondParamGroupInner), CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Post parameters with a shared parameter group object
        /// </summary>
        /// <param name='firstParameterGroup'>
        /// Additional parameters for the operation
        /// </param>
        void PostSharedParameterGroupObject(FirstParameterGroupInner firstParameterGroup = default(FirstParameterGroupInner));

        /// <summary>
        /// Post parameters with a shared parameter group object
        /// </summary>
        /// <param name='firstParameterGroup'>
        /// Additional parameters for the operation
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task PostSharedParameterGroupObjectAsync(FirstParameterGroupInner firstParameterGroup = default(FirstParameterGroupInner), CancellationToken cancellationToken = default(CancellationToken));
    }
}
