// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Output;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class ResourceTypeBuilder
    {
        private static ConcurrentDictionary<OperationGroup, string> _valueCache = new ConcurrentDictionary<OperationGroup, string>();

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
