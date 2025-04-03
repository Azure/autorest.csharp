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
using Azure.ResourceManager.Resources.Models;

namespace MgmtTypeSpec.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmMgmtTypeSpecModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.MgmtTypeSpecPrivateLinkResourceData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="properties"> The resource-specific properties for this resource. </param>
        /// <param name="identity"> The managed service identities assigned to this resource. </param>
        /// <returns> A new <see cref="Models.MgmtTypeSpecPrivateLinkResourceData"/> instance for mocking. </returns>
        public static MgmtTypeSpecPrivateLinkResourceData MgmtTypeSpecPrivateLinkResourceData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, MgmtTypeSpecPrivateLinkResourceProperties properties = null, ManagedServiceIdentity identity = null)
        {
            return new MgmtTypeSpecPrivateLinkResourceData(
                id,
                name,
                resourceType,
                systemData,
                properties,
                identity,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.MgmtTypeSpecPrivateLinkResourceProperties"/>. </summary>
        /// <param name="groupId"> The private link resource group id. </param>
        /// <param name="requiredMembers"> The private link resource required member names. </param>
        /// <param name="requiredZoneNames"> The private link resource private link DNS zone name. </param>
        /// <returns> A new <see cref="Models.MgmtTypeSpecPrivateLinkResourceProperties"/> instance for mocking. </returns>
        public static MgmtTypeSpecPrivateLinkResourceProperties MgmtTypeSpecPrivateLinkResourceProperties(string groupId = null, IEnumerable<string> requiredMembers = null, IEnumerable<string> requiredZoneNames = null)
        {
            requiredMembers ??= new List<string>();
            requiredZoneNames ??= new List<string>();

            return new MgmtTypeSpecPrivateLinkResourceProperties(groupId, requiredMembers?.ToList(), requiredZoneNames?.ToList(), serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.OperationStatusResult"/>. </summary>
        /// <param name="id"> Fully qualified ID for the async operation. </param>
        /// <param name="name"> Name of the async operation. </param>
        /// <param name="status"> Operation status. </param>
        /// <param name="percentComplete"> Percent of the operation that is complete. </param>
        /// <param name="startOn"> The start time of the operation. </param>
        /// <param name="endOn"> The end time of the operation. </param>
        /// <param name="operations"> The operations list. </param>
        /// <param name="error"> If present, details of the operation error. </param>
        /// <param name="resourceId"> Fully qualified ID of the resource against which the original async operation was started. </param>
        /// <returns> A new <see cref="Models.OperationStatusResult"/> instance for mocking. </returns>
        public static OperationStatusResult OperationStatusResult(ResourceIdentifier id = null, string name = null, string status = null, double? percentComplete = null, DateTimeOffset? startOn = null, DateTimeOffset? endOn = null, IEnumerable<OperationStatusResult> operations = null, ResponseError error = null, string resourceId = null)
        {
            operations ??= new List<OperationStatusResult>();

            return new OperationStatusResult(
                id,
                name,
                status,
                percentComplete,
                startOn,
                endOn,
                operations?.ToList(),
                error,
                resourceId,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="MgmtTypeSpec.FooData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="properties"> The resource-specific properties for this resource. </param>
        /// <param name="extendedLocation"></param>
        /// <returns> A new <see cref="MgmtTypeSpec.FooData"/> instance for mocking. </returns>
        public static FooData FooData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, FooProperties properties = null, ExtendedLocation extendedLocation = null)
        {
            tags ??= new Dictionary<string, string>();

            return new FooData(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location,
                properties,
                extendedLocation,
                serializedAdditionalRawData: null);
        }
    }
}
