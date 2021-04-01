// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License
using System;
using System.Text;
using AutoRest.CSharp.Input;
using System.Collections.Generic;
using AutoRest.CSharp.Output.Models.Requests;

namespace AutoRest.CSharp.Output.Models.Type.Decorate
{
    internal static class ResourceTypeBuilder
    {
        public static string ConstructOperationResourseType(OperationGroup operationsGroup)
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
            if (operationsGroup.OperationHttpMethodMapping.TryGetValue(HttpMethod.Put, out requests))
            {
                return (HttpRequest?)requests[0].Protocol?.Http;
            }
            if (operationsGroup.OperationHttpMethodMapping.TryGetValue(HttpMethod.Delete, out requests))
            {
                return (HttpRequest?)requests[0].Protocol?.Http;
            }
            if (operationsGroup.OperationHttpMethodMapping.TryGetValue(HttpMethod.Patch, out requests))
            {
                return (HttpRequest?)requests[0].Protocol?.Http;
            }
            return null;
        }
    }
}
