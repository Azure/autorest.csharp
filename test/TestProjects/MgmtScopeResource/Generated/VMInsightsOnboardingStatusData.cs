// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtScopeResource.Models;

namespace MgmtScopeResource
{
    /// <summary>
    /// A class representing the VMInsightsOnboardingStatus data model.
    /// VM Insights onboarding status for a resource.
    /// </summary>
    public partial class VMInsightsOnboardingStatusData : ResourceData
    {
        /// <summary> Initializes a new instance of VMInsightsOnboardingStatusData. </summary>
        internal VMInsightsOnboardingStatusData()
        {
            Data = new ChangeTrackingList<DataContainer>();
        }

        /// <summary> Initializes a new instance of VMInsightsOnboardingStatusData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="resourceId"> Azure Resource Manager identifier of the resource whose onboarding status is being represented. </param>
        /// <param name="onboardingStatus"> The onboarding status for the resource. Note that, a higher level scope, e.g., resource group or subscription, is considered onboarded if at least one resource under it is onboarded. </param>
        /// <param name="dataStatus"> The status of VM Insights data from the resource. When reported as `present` the data array will contain information about the data containers to which data for the specified resource is being routed. </param>
        /// <param name="data"> Containers that currently store VM Insights data for the specified resource. </param>
        internal VMInsightsOnboardingStatusData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string resourceId, OnboardingStatus? onboardingStatus, DataStatus? dataStatus, IReadOnlyList<DataContainer> data) : base(id, name, resourceType, systemData)
        {
            ResourceId = resourceId;
            OnboardingStatus = onboardingStatus;
            DataStatus = dataStatus;
            Data = data;
        }

        /// <summary> Azure Resource Manager identifier of the resource whose onboarding status is being represented. </summary>
        public string ResourceId { get; }
        /// <summary> The onboarding status for the resource. Note that, a higher level scope, e.g., resource group or subscription, is considered onboarded if at least one resource under it is onboarded. </summary>
        public OnboardingStatus? OnboardingStatus { get; }
        /// <summary> The status of VM Insights data from the resource. When reported as `present` the data array will contain information about the data containers to which data for the specified resource is being routed. </summary>
        public DataStatus? DataStatus { get; }
        /// <summary> Containers that currently store VM Insights data for the specified resource. </summary>
        public IReadOnlyList<DataContainer> Data { get; }
    }
}
