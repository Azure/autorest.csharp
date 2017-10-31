// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>

namespace Fixtures.Azure.AcceptanceTestsAzureParameterGrouping
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
        void PostRequired(ParameterGroupingPostRequiredParameters parameterGroupingPostRequiredParameters);

        /// <summary>
        /// Post a bunch of required parameters grouped
        /// </summary>
        /// <param name='parameterGroupingPostRequiredParameters'>
        /// Additional parameters for the operation
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task PostRequiredAsync(ParameterGroupingPostRequiredParameters parameterGroupingPostRequiredParameters, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Post a bunch of optional parameters grouped
        /// </summary>
        /// <param name='parameterGroupingPostOptionalParameters'>
        /// Additional parameters for the operation
        /// </param>
        void PostOptional(ParameterGroupingPostOptionalParameters parameterGroupingPostOptionalParameters = default(ParameterGroupingPostOptionalParameters));

        /// <summary>
        /// Post a bunch of optional parameters grouped
        /// </summary>
        /// <param name='parameterGroupingPostOptionalParameters'>
        /// Additional parameters for the operation
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task PostOptionalAsync(ParameterGroupingPostOptionalParameters parameterGroupingPostOptionalParameters = default(ParameterGroupingPostOptionalParameters), CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Post parameters from multiple different parameter groups
        /// </summary>
        /// <param name='firstParameterGroup'>
        /// Additional parameters for the operation
        /// </param>
        /// <param name='parameterGroupingPostMultiParamGroupsSecondParamGroup'>
        /// Additional parameters for the operation
        /// </param>
        void PostMultiParamGroups(FirstParameterGroup firstParameterGroup = default(FirstParameterGroup), ParameterGroupingPostMultiParamGroupsSecondParamGroup parameterGroupingPostMultiParamGroupsSecondParamGroup = default(ParameterGroupingPostMultiParamGroupsSecondParamGroup));

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
        Task PostMultiParamGroupsAsync(FirstParameterGroup firstParameterGroup = default(FirstParameterGroup), ParameterGroupingPostMultiParamGroupsSecondParamGroup parameterGroupingPostMultiParamGroupsSecondParamGroup = default(ParameterGroupingPostMultiParamGroupsSecondParamGroup), CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Post parameters with a shared parameter group object
        /// </summary>
        /// <param name='firstParameterGroup'>
        /// Additional parameters for the operation
        /// </param>
        void PostSharedParameterGroupObject(FirstParameterGroup firstParameterGroup = default(FirstParameterGroup));

        /// <summary>
        /// Post parameters with a shared parameter group object
        /// </summary>
        /// <param name='firstParameterGroup'>
        /// Additional parameters for the operation
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task PostSharedParameterGroupObjectAsync(FirstParameterGroup firstParameterGroup = default(FirstParameterGroup), CancellationToken cancellationToken = default(CancellationToken));
    }
}
