// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class ResourceTypeBuilder
    {
        public const string ResourceGroupResources = "resourceGroupsResources"; // Represent any resource under a resource group. The resource type for /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{parentResourcePath}/{resourceType}/{resourceName}

        private static ConcurrentDictionary<OperationGroup, string> _valueCache = new ConcurrentDictionary<OperationGroup, string>();

        private static ConcurrentDictionary<string, string> _operationPathValueCache = new ConcurrentDictionary<string, string>();

        private static ConcurrentDictionary<RequestPath, ResourceType> _requestPathToResourceTypeCache = new ConcurrentDictionary<RequestPath, ResourceType>();

        static ResourceTypeBuilder()
        {
            _requestPathToResourceTypeCache.TryAdd(RequestPath.Subscription, Models.ResourceType.Subscription);
            _requestPathToResourceTypeCache.TryAdd(RequestPath.ResourceGroup, Models.ResourceType.ResourceGroup);
            _requestPathToResourceTypeCache.TryAdd(RequestPath.Tenant, Models.ResourceType.Tenant);
            _requestPathToResourceTypeCache.TryAdd(RequestPath.ManagementGroup, Models.ResourceType.ManagementGroup);
        }

        public static ResourceType GetResourceType(this RequestPath requestPath, MgmtConfiguration config)
        {
            if (_requestPathToResourceTypeCache.TryGetValue(requestPath, out var resourceType))
                return resourceType;

            resourceType = CalculateResourceType(requestPath, config);
            _requestPathToResourceTypeCache.TryAdd(requestPath, resourceType);
            return resourceType;
        }

        private static ResourceType CalculateResourceType(RequestPath requestPath, MgmtConfiguration config)
        {
            if (config.RequestPathToResourceType.TryGetValue(requestPath.SerializedPath, out var resourceType))
                return new ResourceType(resourceType);

            return new ResourceType(requestPath);
        }

        public static string ResourceType(this Operation operation)
        {
            string? result = null;
            if (!(operation.Requests.FirstOrDefault().Protocol.Http is HttpRequest httpRequest))
            {
                throw new ArgumentException($"The operation does not have an HttpRequest.");
            }
            var path = httpRequest.Path;
            if (_operationPathValueCache.TryGetValue(path, out result))
                return result;

            var indexOfProvider = path.IndexOf(ProviderSegment.Providers);
            if (indexOfProvider < 0)
            {
                throw new ArgumentException($"Could not set ResourceType for operations group {path}. No {ProviderSegment.Providers} string found in the URI");
            }
            var resourceType = ResourceTypeBuilder.ConstructResourceType(path.Substring(indexOfProvider + ProviderSegment.Providers.Length));
            if (resourceType == string.Empty)
            {
                throw new ArgumentException($"Could not set ResourceType for operations group {path}. An unexpected pattern of reference-reference was found in the URI");
            }
            result = resourceType.ToString().TrimEnd('/');
            _operationPathValueCache.TryAdd(path, result);
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
