// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtScopeResource;

namespace MgmtScopeResource.Models
{
    /// <summary> Model factory for generated models. </summary>
    public static partial class MgmtScopeResourceModelFactory
    {
        /// <summary> Initializes a new instance of FakePolicyAssignmentData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="location"> The location of the policy assignment. Only required when utilizing managed identity. </param>
        /// <param name="identity"> The managed identity associated with the policy assignment. Current supported identity types: None, SystemAssigned. </param>
        /// <param name="displayName"> The display name of the policy assignment. </param>
        /// <param name="policyDefinitionId"> The ID of the policy definition or policy set definition being assigned. </param>
        /// <param name="scope"> The scope for the policy assignment. </param>
        /// <param name="notScopes"> The policy&apos;s excluded scopes. </param>
        /// <param name="parameters"> The parameter values for the assigned policy rule. The keys are the parameter names. </param>
        /// <param name="description"> This message will be part of response in case of policy violation. </param>
        /// <param name="metadata"> The policy assignment metadata. Metadata is an open ended object and is typically a collection of key value pairs. </param>
        /// <param name="enforcementMode"> The policy assignment enforcement mode. Possible values are Default and DoNotEnforce. </param>
        /// <param name="nonComplianceMessages"> The messages that describe why a resource is non-compliant with the policy. </param>
        /// <returns> A new <see cref="MgmtScopeResource.FakePolicyAssignmentData"/> instance for mocking. </returns>
        public static FakePolicyAssignmentData FakePolicyAssignmentData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, string location = null, ManagedServiceIdentity identity = null, string displayName = null, string policyDefinitionId = null, string scope = null, IEnumerable<string> notScopes = null, IDictionary<string, ParameterValuesValue> parameters = null, string description = null, BinaryData metadata = null, EnforcementMode? enforcementMode = null, IEnumerable<NonComplianceMessage> nonComplianceMessages = null)
        {
            notScopes ??= new List<string>();
            parameters ??= new Dictionary<string, ParameterValuesValue>();
            nonComplianceMessages ??= new List<NonComplianceMessage>();

            return new FakePolicyAssignmentData(id, name, resourceType, systemData, location, identity, displayName, policyDefinitionId, scope, notScopes?.ToList(), parameters, description, metadata, enforcementMode, nonComplianceMessages?.ToList());
        }

        /// <summary> Initializes a new instance of DeploymentExtendedData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="location"> the location of the deployment. </param>
        /// <param name="properties"> Deployment properties. </param>
        /// <param name="tags"> Deployment tags. </param>
        /// <returns> A new <see cref="MgmtScopeResource.DeploymentExtendedData"/> instance for mocking. </returns>
        public static DeploymentExtendedData DeploymentExtendedData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, string location = null, DeploymentPropertiesExtended properties = null, IReadOnlyDictionary<string, string> tags = null)
        {
            tags ??= new Dictionary<string, string>();

            return new DeploymentExtendedData(id, name, resourceType, systemData, location, properties, tags);
        }

        /// <summary> Initializes a new instance of DeploymentPropertiesExtended. </summary>
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
            return new DeploymentPropertiesExtended(provisioningState, correlationId, timestamp, duration, outputs, parameters, mode, error != null ? new ErrorResponse(error) : null);
        }

        /// <summary> Initializes a new instance of DeploymentValidateResult. </summary>
        /// <param name="error"> The deployment validation error. </param>
        /// <param name="properties"> The template deployment properties. </param>
        /// <returns> A new <see cref="Models.DeploymentValidateResult"/> instance for mocking. </returns>
        public static DeploymentValidateResult DeploymentValidateResult(string error = null, DeploymentPropertiesExtended properties = null)
        {
            return new DeploymentValidateResult(error != null ? new ErrorResponse(error) : null, properties);
        }

        /// <summary> Initializes a new instance of DeploymentExportResult. </summary>
        /// <param name="template"> The template content. </param>
        /// <returns> A new <see cref="Models.DeploymentExportResult"/> instance for mocking. </returns>
        public static DeploymentExportResult DeploymentExportResult(BinaryData template = null)
        {
            return new DeploymentExportResult(template);
        }

        /// <summary> Initializes a new instance of WhatIfOperationResult. </summary>
        /// <param name="status"> Status of the What-If operation. </param>
        /// <param name="error"> Error when What-If operation fails. </param>
        /// <param name="changes"> List of resource changes predicted by What-If operation. </param>
        /// <returns> A new <see cref="Models.WhatIfOperationResult"/> instance for mocking. </returns>
        public static WhatIfOperationResult WhatIfOperationResult(string status = null, string error = null, IEnumerable<WhatIfChange> changes = null)
        {
            changes ??= new List<WhatIfChange>();

            return new WhatIfOperationResult(status, error != null ? new ErrorResponse(error) : null, changes?.ToList());
        }

        /// <summary> Initializes a new instance of WhatIfChange. </summary>
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

        /// <summary> Initializes a new instance of DeploymentOperation. </summary>
        /// <param name="id"> Full deployment operation ID. </param>
        /// <param name="operationId"> Deployment operation ID. </param>
        /// <param name="properties"> Deployment properties. </param>
        /// <returns> A new <see cref="Models.DeploymentOperation"/> instance for mocking. </returns>
        public static DeploymentOperation DeploymentOperation(string id = null, string operationId = null, DeploymentOperationProperties properties = null)
        {
            return new DeploymentOperation(id, operationId, properties);
        }

        /// <summary> Initializes a new instance of DeploymentOperationProperties. </summary>
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
            return new DeploymentOperationProperties(provisioningOperation, provisioningState, timestamp, duration, anotherDuration, serviceRequestId, statusCode, statusMessage, requestContent != null ? new HttpMessage(requestContent) : null, responseContent != null ? new HttpMessage(responseContent) : null);
        }

        /// <summary> Initializes a new instance of StatusMessage. </summary>
        /// <param name="status"> Status of the deployment operation. </param>
        /// <param name="error"> The error reported by the operation. </param>
        /// <returns> A new <see cref="Models.StatusMessage"/> instance for mocking. </returns>
        public static StatusMessage StatusMessage(string status = null, string error = null)
        {
            return new StatusMessage(status, error != null ? new ErrorResponse(error) : null);
        }

        /// <summary> Initializes a new instance of TemplateHashResult. </summary>
        /// <param name="minifiedTemplate"> The minified template string. </param>
        /// <param name="templateHash"> The template hash. </param>
        /// <returns> A new <see cref="Models.TemplateHashResult"/> instance for mocking. </returns>
        public static TemplateHashResult TemplateHashResult(string minifiedTemplate = null, string templateHash = null)
        {
            return new TemplateHashResult(minifiedTemplate, templateHash);
        }

        /// <summary> Initializes a new instance of ResourceLinkData. </summary>
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

        /// <summary> Initializes a new instance of ResourceLinkProperties. </summary>
        /// <param name="sourceId"> The fully qualified ID of the source resource in the link. </param>
        /// <param name="targetId"> The fully qualified ID of the target resource in the link. </param>
        /// <param name="notes"> Notes about the resource link. </param>
        /// <returns> A new <see cref="Models.ResourceLinkProperties"/> instance for mocking. </returns>
        public static ResourceLinkProperties ResourceLinkProperties(string sourceId = null, string targetId = null, string notes = null)
        {
            return new ResourceLinkProperties(sourceId, targetId, notes);
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
        /// <returns> A new <see cref="MgmtScopeResource.VMInsightsOnboardingStatusData"/> instance for mocking. </returns>
        public static VMInsightsOnboardingStatusData VMInsightsOnboardingStatusData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, string resourceId = null, OnboardingStatus? onboardingStatus = null, DataStatus? dataStatus = null, IEnumerable<DataContainer> data = null)
        {
            data ??= new List<DataContainer>();

            return new VMInsightsOnboardingStatusData(id, name, resourceType, systemData, resourceId, onboardingStatus, dataStatus, data?.ToList());
        }

        /// <summary> Initializes a new instance of DataContainer. </summary>
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

        /// <summary> Initializes a new instance of WorkspaceInfo. </summary>
        /// <param name="id"> Azure Resource Manager identifier of the Log Analytics Workspace. </param>
        /// <param name="location"> Location of the Log Analytics workspace. </param>
        /// <param name="customerId"> Log Analytics workspace identifier. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="location"/> or <paramref name="customerId"/> is null. </exception>
        /// <returns> A new <see cref="Models.WorkspaceInfo"/> instance for mocking. </returns>
        public static WorkspaceInfo WorkspaceInfo(string id = null, string location = null, string customerId = null)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (location == null)
            {
                throw new ArgumentNullException(nameof(location));
            }
            if (customerId == null)
            {
                throw new ArgumentNullException(nameof(customerId));
            }

            return new WorkspaceInfo(id, location, customerId);
        }
    }
}
