// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Output;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class ResourceTypeBuilder
    {
        public const string Subscriptions = "subscriptions";
        public const string ResourceGroups = "resourceGroups";
        public const string Tenant = "tenant";
        public const string Locations = "locations";
        public const string ManagementGroups = "providers/Microsoft.Management/managementGroups"; // TODO: shall we change ParentResourceType() and make it "Microsoft.Management/managementGroups".
        public const string ResourceGroupResources = "resourceGroupsResources"; // Represent any resource under a resource group. The resource type for /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{parentResourcePath}/{resourceType}/{resourceName}

        public static readonly Dictionary<string, string> TypeToExtensionName = new Dictionary<string, string>()
        {
            { Subscriptions , "SubscriptionExtensions" },
            { ResourceGroups , "ResourceGroupExtensions" },
            { Tenant , "ArmClientExtensions" },
            { ManagementGroups , "ManagementGroupExtensions" },
        };

        private static ConcurrentDictionary<OperationGroup, string> _valueCache = new ConcurrentDictionary<OperationGroup, string>();

        private static ConcurrentDictionary<Operation, string> _operationValueCache = new ConcurrentDictionary<Operation, string>();

        public static string ResourceType(this OperationGroup operationsGroup, MgmtConfiguration config)
        {
            string? result = null;
            if (_valueCache.TryGetValue(operationsGroup, out result))
                return result;

            if (!config.OperationGroupToResourceType.TryGetValue(operationsGroup.Key, out result))
            {
                result = ResourceTypeBuilder.ConstructOperationResourceType(operationsGroup);
            }

            _valueCache.TryAdd(operationsGroup, result);
            return result;
        }

        public static string ResourceType(this Operation operation)
        {
            string? result = null;
            if (_operationValueCache.TryGetValue(operation, out result))
                return result;
            if (!(operation.Requests.FirstOrDefault().Protocol.Http is HttpRequest httpRequest))
            {
                throw new ArgumentException($"The operation does not have an HttpRequest.");
            }

            var indexOfProvider = httpRequest.Path.IndexOf(ProviderSegment.Providers);
            if (indexOfProvider < 0)
            {
                throw new ArgumentException($"Could not set ResourceType for operations group {httpRequest.Path}. No {ProviderSegment.Providers} string found in the URI");
            }
            var resourceType = ResourceTypeBuilder.ConstructResourceType(httpRequest.Path.Substring(indexOfProvider + ProviderSegment.Providers.Length));
            if (resourceType == string.Empty)
            {
                throw new ArgumentException($"Could not set ResourceType for operations group {httpRequest.Path}. An unexpected pattern of reference-reference was found in the URI");
            }
            result = resourceType.ToString().TrimEnd('/');
            _operationValueCache.TryAdd(operation, result);
            return result;
        }

        private static string ConstructOperationResourceType(OperationGroup operationsGroup)
        {
            var method = GetBestMethod(operationsGroup);
            if (method == null)
            {
                throw new ArgumentException($@"Could not set ResourceType for operations group {operationsGroup.Key}
                                            Please try setting this value for this operations in the readme.md for this swagger in the operation-group-mapping section");
            }
            var indexOfProvider = method.Path.IndexOf(ProviderSegment.Providers);
            if (indexOfProvider < 0)
            {
                throw new ArgumentException($"Could not set ResourceType for operations group {operationsGroup.Key}. No {ProviderSegment.Providers} string found in the URI");
            }
            var resourceType = ResourceTypeBuilder.ConstructResourceType(method.Path.Substring(indexOfProvider + ProviderSegment.Providers.Length));
            if (resourceType == string.Empty)
            {
                throw new ArgumentException($"Could not set ResourceType for operations group {operationsGroup.Key}. An unexpected pattern of reference-reference was found in the URI");
            }
            return resourceType.ToString().TrimEnd('/');
        }


        private static string ConstructResourceType(string httpRequestUri)
        {
            var returnString = new StringBuilder();
            var insideBrace = false;

            for (int i = 0; i < httpRequestUri.Length; i++)
            {
                char ch = httpRequestUri[i];
                char lastChar = ch;

                if (ch == '{')
                {
                    // non-constant-refernce pattern, need to custom defined in readme.md
                    if (lastChar == '}')
                    {
                        return string.Empty;
                    }
                    insideBrace = true;
                }
                else if (ch == '}')
                {
                    insideBrace = false;
                    i++;
                }
                else if (!insideBrace)
                {
                    // non-constant-refernce pattern, need to custom defined in readme.md
                    returnString.Append(ch);
                }
                lastChar = ch;
            }
            return returnString.ToString();
        }

        private static HttpRequest? GetBestMethod(OperationGroup operationsGroup)
        {
            List<ServiceRequest>? requests;
            if (operationsGroup.OperationHttpMethodMapping().TryGetValue(HttpMethod.Put, out requests))
            {
                return (HttpRequest?)requests[0].Protocol?.Http;
            }
            if (operationsGroup.OperationHttpMethodMapping().TryGetValue(HttpMethod.Delete, out requests))
            {
                return (HttpRequest?)requests[0].Protocol?.Http;
            }
            if (operationsGroup.OperationHttpMethodMapping().TryGetValue(HttpMethod.Patch, out requests))
            {
                return (HttpRequest?)requests[0].Protocol?.Http;
            }
            return null;
        }
    }
}
