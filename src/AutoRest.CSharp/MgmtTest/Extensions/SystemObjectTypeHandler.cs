// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Output.Models.Types;
using Azure.ResourceManager.Models;

namespace AutoRest.CSharp.MgmtTest.Extensions
{
    internal static class SystemObjectTypeHandler
    {
        public static string? GetPropertySerializedName(SystemObjectType systemObjectType, string propertyName)
        {
            var type = systemObjectType.SystemType;
            var dict = type switch
            {
                _ when type == typeof(ManagedServiceIdentity) => _managedIdentityPropertyNames,
                _ when type == typeof(UserAssignedIdentity) => _userAssignedIdentityPropertyNames,
                _ when type == typeof(SystemAssignedServiceIdentity) => _systemAssignedServiceIdentityPropertyNames,
                _ => GetDefaultPropertySerializedNames(systemObjectType),
            };

            return dict?[propertyName];
        }

        private static Dictionary<string, string?> GetDefaultPropertySerializedNames(SystemObjectType systemObjectType)
        {
            return systemObjectType.Properties.ToDictionary(
                property => property.Declaration.Name,
                property => property.SchemaProperty?.SerializedName);
        }

        private static Dictionary<string, string?> _managedIdentityPropertyNames = new()
        {
            ["PrincipalId"] = "principalId",
            ["TenantId"] = "tenantId",
            ["ManagedServiceIdentityType"] = "type",
            ["UserAssignedIdentities"] = "userAssignedIdentities",
        };

        private static Dictionary<string, string?> _userAssignedIdentityPropertyNames = new()
        {
            ["PrincipalId"] = "principalId",
            ["TenantId"] = "tenantId",
        };

        private static Dictionary<string, string?> _systemAssignedServiceIdentityPropertyNames = new()
        {
            ["PrincipalId"] = "principalId",
            ["TenantId"] = "tenantId",
            ["SystemAssignedServiceIdentityType"] = "type",
        };
    }
}
