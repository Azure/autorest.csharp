// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace MgmtScopeResource.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmMgmtScopeResourceModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="MgmtScopeResource.FakePolicyAssignmentData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="location"> The location of the policy assignment. Only required when utilizing managed identity. </param>
        /// <param name="identity"> The managed identity associated with the policy assignment. Current supported identity types: None, SystemAssigned. </param>
        /// <param name="displayName"> The display name of the policy assignment. </param>
        /// <param name="policyDefinitionId"> The ID of the policy definition or policy set definition being assigned. </param>
        /// <param name="scope"> The scope for the policy assignment. </param>
        /// <param name="notScopes"> The policy's excluded scopes. </param>
        /// <param name="parameters"> The parameter values for the assigned policy rule. The keys are the parameter names. </param>
        /// <param name="description"> This message will be part of response in case of policy violation. </param>
        /// <param name="metadata"> The policy assignment metadata. Metadata is an open ended object and is typically a collection of key value pairs. </param>
        /// <param name="enforcementMode"> The policy assignment enforcement mode. Possible values are Default and DoNotEnforce. </param>
        /// <param name="nonComplianceMessages"> The messages that describe why a resource is non-compliant with the policy. </param>
        /// <returns> A new <see cref="MgmtScopeResource.FakePolicyAssignmentData"/> instance for mocking. </returns>
        public static FakePolicyAssignmentData FakePolicyAssignmentData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, AzureLocation? location = null, ManagedServiceIdentity identity = null, string displayName = null, string policyDefinitionId = null, string scope = null, IEnumerable<string> notScopes = null, IDictionary<string, ParameterValuesValue> parameters = null, string description = null, BinaryData metadata = null, EnforcementMode? enforcementMode = null, IEnumerable<NonComplianceMessage> nonComplianceMessages = null)
        {
            notScopes ??= new List<string>();
            parameters ??= new Dictionary<string, ParameterValuesValue>();
            nonComplianceMessages ??= new List<NonComplianceMessage>();

            return new FakePolicyAssignmentData(
                id,
                name,
                resourceType,
                systemData,
                location,
                identity,
                displayName,
                policyDefinitionId,
                scope,
                notScopes?.ToList(),
                parameters,
                description,
                metadata,
                enforcementMode,
                nonComplianceMessages?.ToList());
        }

        /// <summary> Initializes a new instance of <see cref="MgmtScopeResource.DeploymentExtendedData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="location"> the location of the deployment. </param>
        /// <param name="properties"> Deployment properties. </param>
        /// <param name="tags"> Deployment tags. </param>
        /// <returns> A new <see cref="MgmtScopeResource.DeploymentExtendedData"/> instance for mocking. </returns>
        public static DeploymentExtendedData DeploymentExtendedData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, AzureLocation? location = null, DeploymentPropertiesExtended properties = null, IReadOnlyDictionary<string, string> tags = null)
        {
            tags ??= new Dictionary<string, string>();

            return new DeploymentExtendedData(
                id,
                name,
                resourceType,
                systemData,
                location,
                properties,
                tags);
        }

        /// <summary> Initializes a new instance of <see cref="Models.DeploymentPropertiesExtended"/>. </summary>
        /// <param name="provisioningState"> Denotes the state of provisioning. </param>
        /// <param name="correlationId"> The correlation ID of the deployment. </param>
        /// <param name="timestamp"> The timestamp of the template deployment. </param>
        /// <param name="duration"> The duration of the template deployment. </param>
        /// <param name="outputs"> Key/value pairs that represent deployment output. </param>
        /// <param name="parameters"> Deployment parameters. </param>
        /// <param name="mode"> The mode that is used to deploy resources. This value can be either Incremental or Complete. In Incremental mode, resources are deployed without deleting existing resources that are not included in the template. In Complete mode, resources are deployed and existing resources in the resource group that are not included in the template are deleted. Be careful when using Complete mode as you may unintentionally delete resources. </param>
        /// <param name="error"> The deployment error. </param>
        /// <returns> A new <see cref="Models.DeploymentPropertiesExtended"/> instance for mocking. </returns>
        public static DeploymentPropertiesExtended DeploymentPropertiesExtended(ProvisioningState? provisioningState = null, string correlationId = null, DateTimeOffset? timestamp = null, TimeSpan? duration = null, BinaryData outputs = null, BinaryData parameters = null, DeploymentMode? mode = null, string error = null)
        {
            return new DeploymentPropertiesExtended(
                provisioningState,
                correlationId,
                timestamp,
                duration,
                outputs,
                parameters,
                mode,
                error != null ? new ErrorResponse(error) : null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.DeploymentValidateResult"/>. </summary>
        /// <param name="error"> The deployment validation error. </param>
        /// <param name="properties"> The template deployment properties. </param>
        /// <returns> A new <see cref="Models.DeploymentValidateResult"/> instance for mocking. </returns>
        public static DeploymentValidateResult DeploymentValidateResult(string error = null, DeploymentPropertiesExtended properties = null)
        {
            return new DeploymentValidateResult(error != null ? new ErrorResponse(error) : null, properties);
        }

        /// <summary> Initializes a new instance of <see cref="Models.DeploymentExportResult"/>. </summary>
        /// <param name="template"> The template content. </param>
        /// <returns> A new <see cref="Models.DeploymentExportResult"/> instance for mocking. </returns>
        public static DeploymentExportResult DeploymentExportResult(BinaryData template = null)
        {
            return new DeploymentExportResult(template);
        }

        /// <summary> Initializes a new instance of <see cref="Models.WhatIfOperationResult"/>. </summary>
        /// <param name="status"> Status of the What-If operation. </param>
        /// <param name="error"> Error when What-If operation fails. </param>
        /// <param name="changes"> List of resource changes predicted by What-If operation. </param>
        /// <returns> A new <see cref="Models.WhatIfOperationResult"/> instance for mocking. </returns>
        public static WhatIfOperationResult WhatIfOperationResult(string status = null, string error = null, IEnumerable<WhatIfChange> changes = null)
        {
            changes ??= new List<WhatIfChange>();

            return new WhatIfOperationResult(status, error != null ? new ErrorResponse(error) : null, changes?.ToList());
        }

        /// <summary> Initializes a new instance of <see cref="Models.WhatIfChange"/>. </summary>
        /// <param name="resourceId"> Resource ID. </param>
        /// <param name="changeType"> Type of change that will be made to the resource when the deployment is executed. </param>
        /// <param name="unsupportedReason"> The explanation about why the resource is unsupported by What-If. </param>
        /// <param name="before"> The snapshot of the resource before the deployment is executed. </param>
        /// <param name="after"> The predicted snapshot of the resource after the deployment is executed. </param>
        /// <returns> A new <see cref="Models.WhatIfChange"/> instance for mocking. </returns>
        public static WhatIfChange WhatIfChange(string resourceId = null, ChangeType changeType = default, string unsupportedReason = null, BinaryData before = null, BinaryData after = null)
        {
            return new WhatIfChange(resourceId, changeType, unsupportedReason, before, after);
        }

        /// <summary> Initializes a new instance of <see cref="Models.DeploymentOperation"/>. </summary>
        /// <param name="id"> Full deployment operation ID. </param>
        /// <param name="operationId"> Deployment operation ID. </param>
        /// <param name="properties"> Deployment properties. </param>
        /// <returns> A new <see cref="Models.DeploymentOperation"/> instance for mocking. </returns>
        public static DeploymentOperation DeploymentOperation(string id = null, string operationId = null, DeploymentOperationProperties properties = null)
        {
            return new DeploymentOperation(id, operationId, properties);
        }

        /// <summary> Initializes a new instance of <see cref="Models.DeploymentOperationProperties"/>. </summary>
        /// <param name="provisioningOperation"> The name of the current provisioning operation. </param>
        /// <param name="provisioningState"> The state of the provisioning. </param>
        /// <param name="timestamp"> The date and time of the operation. </param>
        /// <param name="duration"> The duration of the operation. </param>
        /// <param name="anotherDuration"> Another duration of the operation. </param>
        /// <param name="serviceRequestId"> Deployment operation service request id. </param>
        /// <param name="statusCode"> Operation status code from the resource provider. This property may not be set if a response has not yet been received. </param>
        /// <param name="statusMessage"> Operation status message from the resource provider. This property is optional.  It will only be provided if an error was received from the resource provider. </param>
        /// <param name="requestContent"> The HTTP request message. </param>
        /// <param name="responseContent"> The HTTP response message. </param>
        /// <returns> A new <see cref="Models.DeploymentOperationProperties"/> instance for mocking. </returns>
        public static DeploymentOperationProperties DeploymentOperationProperties(ProvisioningOperation? provisioningOperation = null, string provisioningState = null, DateTimeOffset? timestamp = null, TimeSpan? duration = null, TimeSpan? anotherDuration = null, string serviceRequestId = null, string statusCode = null, StatusMessage statusMessage = null, BinaryData requestContent = null, BinaryData responseContent = null)
        {
            return new DeploymentOperationProperties(
                provisioningOperation,
                provisioningState,
                timestamp,
                duration,
                anotherDuration,
                serviceRequestId,
                statusCode,
                statusMessage,
                requestContent != null ? new HttpMessage(requestContent) : null,
                responseContent != null ? new HttpMessage(responseContent) : null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.StatusMessage"/>. </summary>
        /// <param name="status"> Status of the deployment operation. </param>
        /// <param name="error"> The error reported by the operation. </param>
        /// <returns> A new <see cref="Models.StatusMessage"/> instance for mocking. </returns>
        public static StatusMessage StatusMessage(string status = null, string error = null)
        {
            return new StatusMessage(status, error != null ? new ErrorResponse(error) : null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.TemplateHashResult"/>. </summary>
        /// <param name="minifiedTemplate"> The minified template string. </param>
        /// <param name="templateHash"> The template hash. </param>
        /// <returns> A new <see cref="Models.TemplateHashResult"/> instance for mocking. </returns>
        public static TemplateHashResult TemplateHashResult(string minifiedTemplate = null, string templateHash = null)
        {
            return new TemplateHashResult(minifiedTemplate, templateHash);
        }

        /// <summary> Initializes a new instance of <see cref="MgmtScopeResource.ResourceLinkData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="properties"> Properties for resource link. </param>
        /// <returns> A new <see cref="MgmtScopeResource.ResourceLinkData"/> instance for mocking. </returns>
        public static ResourceLinkData ResourceLinkData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, ResourceLinkProperties properties = null)
        {
            return new ResourceLinkData(id, name, resourceType, systemData, properties);
        }

        /// <summary> Initializes a new instance of <see cref="Models.ResourceLinkProperties"/>. </summary>
        /// <param name="sourceId"> The fully qualified ID of the source resource in the link. </param>
        /// <param name="targetId"> The fully qualified ID of the target resource in the link. </param>
        /// <param name="notes"> Notes about the resource link. </param>
        /// <returns> A new <see cref="Models.ResourceLinkProperties"/> instance for mocking. </returns>
        public static ResourceLinkProperties ResourceLinkProperties(string sourceId = null, string targetId = null, string notes = null)
        {
            return new ResourceLinkProperties(sourceId, targetId, notes);
        }

        /// <summary> Initializes a new instance of <see cref="MgmtScopeResource.VmInsightsOnboardingStatusData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="resourceId"> Azure Resource Manager identifier of the resource whose onboarding status is being represented. </param>
        /// <param name="onboardingStatus"> The onboarding status for the resource. Note that, a higher level scope, e.g., resource group or subscription, is considered onboarded if at least one resource under it is onboarded. </param>
        /// <param name="dataStatus"> The status of VM Insights data from the resource. When reported as `present` the data array will contain information about the data containers to which data for the specified resource is being routed. </param>
        /// <param name="data"> Containers that currently store VM Insights data for the specified resource. </param>
        /// <returns> A new <see cref="MgmtScopeResource.VmInsightsOnboardingStatusData"/> instance for mocking. </returns>
        public static VmInsightsOnboardingStatusData VmInsightsOnboardingStatusData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, string resourceId = null, OnboardingStatus? onboardingStatus = null, DataStatus? dataStatus = null, IEnumerable<DataContainer> data = null)
        {
            data ??= new List<DataContainer>();

            return new VmInsightsOnboardingStatusData(
                id,
                name,
                resourceType,
                systemData,
                resourceId,
                onboardingStatus,
                dataStatus,
                data?.ToList());
        }

        /// <summary> Initializes a new instance of <see cref="Models.DataContainer"/>. </summary>
        /// <param name="workspace"> Log Analytics workspace information. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="workspace"/> is null. </exception>
        /// <returns> A new <see cref="Models.DataContainer"/> instance for mocking. </returns>
        public static DataContainer DataContainer(WorkspaceInfo workspace = null)
        {
            if (workspace == null)
            {
                throw new ArgumentNullException(nameof(workspace));
            }

            return new DataContainer(workspace);
        }

        /// <summary> Initializes a new instance of <see cref="Models.WorkspaceInfo"/>. </summary>
        /// <param name="id"> Azure Resource Manager identifier of the Log Analytics Workspace. </param>
        /// <param name="location"> Location of the Log Analytics workspace. </param>
        /// <param name="customerId"> Log Analytics workspace identifier. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> or <paramref name="customerId"/> is null. </exception>
        /// <returns> A new <see cref="Models.WorkspaceInfo"/> instance for mocking. </returns>
        public static WorkspaceInfo WorkspaceInfo(string id = null, AzureLocation location = default, string customerId = null)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (customerId == null)
            {
                throw new ArgumentNullException(nameof(customerId));
            }

            return new WorkspaceInfo(id, location, customerId);
        }

        /// <summary> Initializes a new instance of <see cref="MgmtScopeResource.GuestConfigurationAssignmentData"/>. </summary>
        /// <param name="id"> ARM resource id of the guest configuration assignment. </param>
        /// <param name="name"> Name of the guest configuration assignment. </param>
        /// <param name="location"> Region where the VM is located. </param>
        /// <param name="resourceType"> The type of the resource. </param>
        /// <param name="properties"> Properties of the Guest configuration assignment. </param>
        /// <returns> A new <see cref="MgmtScopeResource.GuestConfigurationAssignmentData"/> instance for mocking. </returns>
        public static GuestConfigurationAssignmentData GuestConfigurationAssignmentData(string id = null, string name = null, AzureLocation? location = null, string resourceType = null, GuestConfigurationAssignmentProperties properties = null)
        {
            return new GuestConfigurationAssignmentData(id, name, location, resourceType, properties);
        }

        /// <summary> Initializes a new instance of <see cref="Models.GuestConfigurationAssignmentProperties"/>. </summary>
        /// <param name="targetResourceId"> VM resource Id. </param>
        /// <param name="complianceStatus"> A value indicating compliance status of the machine for the assigned guest configuration. </param>
        /// <param name="lastComplianceStatusChecked"> Date and time when last compliance status was checked. </param>
        /// <param name="latestReportId"> Id of the latest report for the guest configuration assignment. </param>
        /// <param name="parameterHash"> parameter hash for the guest configuration assignment. </param>
        /// <param name="context"> The source which initiated the guest configuration assignment. Ex: Azure Policy. </param>
        /// <param name="assignmentHash"> Combined hash of the configuration package and parameters. </param>
        /// <param name="provisioningState"> The provisioning state, which only appears in the response. </param>
        /// <param name="resourceType"> Type of the resource - VMSS / VM. </param>
        /// <returns> A new <see cref="Models.GuestConfigurationAssignmentProperties"/> instance for mocking. </returns>
        public static GuestConfigurationAssignmentProperties GuestConfigurationAssignmentProperties(string targetResourceId = null, ComplianceStatus? complianceStatus = null, DateTimeOffset? lastComplianceStatusChecked = null, string latestReportId = null, string parameterHash = null, string context = null, string assignmentHash = null, ProvisioningState? provisioningState = null, string resourceType = null)
        {
            return new GuestConfigurationAssignmentProperties(
                targetResourceId,
                complianceStatus,
                lastComplianceStatusChecked,
                latestReportId,
                parameterHash,
                context,
                assignmentHash,
                provisioningState,
                resourceType);
        }

        /// <summary> Initializes a new instance of <see cref="Models.GuestConfigurationBaseResource"/>. </summary>
        /// <param name="id"> ARM resource id of the guest configuration assignment. </param>
        /// <param name="name"> Name of the guest configuration assignment. </param>
        /// <param name="location"> Region where the VM is located. </param>
        /// <param name="resourceType"> The type of the resource. </param>
        /// <returns> A new <see cref="Models.GuestConfigurationBaseResource"/> instance for mocking. </returns>
        public static GuestConfigurationBaseResource GuestConfigurationBaseResource(string id = null, string name = null, AzureLocation? location = null, string resourceType = null)
        {
            return new GuestConfigurationBaseResource(id, name, location, resourceType);
        }

        /// <summary> Initializes a new instance of <see cref="Models.Marketplace"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="billingPeriodId"> The id of the billing period resource that the usage belongs to. </param>
        /// <param name="usageStart"> The start of the date time range covered by the usage detail. </param>
        /// <param name="usageEnd"> The end of the date time range covered by the usage detail. </param>
        /// <param name="resourceRate"> The marketplace resource rate. </param>
        /// <param name="offerName"> The type of offer. </param>
        /// <param name="resourceGroup"> The name of resource group. </param>
        /// <param name="additionalInfo"> Additional information. </param>
        /// <param name="orderNumber"> The order number. </param>
        /// <param name="instanceName"> The name of the resource instance that the usage is about. </param>
        /// <param name="instanceId"> The uri of the resource instance that the usage is about. </param>
        /// <param name="currency"> The ISO currency in which the meter is charged, for example, USD. </param>
        /// <param name="consumedQuantity"> The quantity of usage. </param>
        /// <param name="unitOfMeasure"> The unit of measure. </param>
        /// <param name="pretaxCost"> The amount of cost before tax. </param>
        /// <param name="isEstimated"> The estimated usage is subject to change. </param>
        /// <param name="meterId"> The meter id (GUID). </param>
        /// <param name="subscriptionGuid"> Subscription guid. </param>
        /// <param name="subscriptionName"> Subscription name. </param>
        /// <param name="accountName"> Account name. </param>
        /// <param name="departmentName"> Department name. </param>
        /// <param name="consumedService"> Consumed service name. </param>
        /// <param name="costCenter"> The cost center of this department if it is a department and a costcenter exists. </param>
        /// <param name="additionalProperties"> Additional details of this usage item. By default this is not populated, unless it's specified in $expand. </param>
        /// <param name="publisherName"> The name of publisher. </param>
        /// <param name="planName"> The name of plan. </param>
        /// <param name="isRecurringCharge"> Flag indicating whether this is a recurring charge or not. </param>
        /// <param name="eTag"> The etag for the resource. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <returns> A new <see cref="Models.Marketplace"/> instance for mocking. </returns>
        public static Marketplace Marketplace(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, string billingPeriodId = null, DateTimeOffset? usageStart = null, DateTimeOffset? usageEnd = null, decimal? resourceRate = null, string offerName = null, string resourceGroup = null, string additionalInfo = null, string orderNumber = null, string instanceName = null, string instanceId = null, string currency = null, decimal? consumedQuantity = null, string unitOfMeasure = null, decimal? pretaxCost = null, bool? isEstimated = null, Guid? meterId = null, Guid? subscriptionGuid = null, string subscriptionName = null, string accountName = null, string departmentName = null, string consumedService = null, string costCenter = null, string additionalProperties = null, string publisherName = null, string planName = null, bool? isRecurringCharge = null, ETag? eTag = null, IReadOnlyDictionary<string, string> tags = null)
        {
            tags ??= new Dictionary<string, string>();

            return new Marketplace(
                id,
                name,
                resourceType,
                systemData,
                billingPeriodId,
                usageStart,
                usageEnd,
                resourceRate,
                offerName,
                resourceGroup,
                additionalInfo,
                orderNumber,
                instanceName,
                instanceId,
                currency,
                consumedQuantity,
                unitOfMeasure,
                pretaxCost,
                isEstimated,
                meterId,
                subscriptionGuid,
                subscriptionName,
                accountName,
                departmentName,
                consumedService,
                costCenter,
                additionalProperties,
                publisherName,
                planName,
                isRecurringCharge,
                eTag,
                tags);
        }
    }
}
