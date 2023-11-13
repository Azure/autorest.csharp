// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Report;
using AutoRest.CSharp.Utilities;
using Azure.Core;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class ResourceDetection
    {
        private const string ProvidersSegment = "/providers/";
        private static ConcurrentDictionary<string, InputModelType?> _resourceDataSchemaCache = new ConcurrentDictionary<string, InputModelType?>();

        public static bool IsResource(this OperationSet set, InputNamespace? inputNamespace = null)
        {
            return set.TryGetResourceDataSchema(out _, inputNamespace);
        }

        private static InputModelType? FindObjectSchemaWithName(string name, InputNamespace? inputNamespace = null)
            => inputNamespace?.Models.OfType<InputModelType>().FirstOrDefault(inputModel => inputModel.GetOriginalName() == name);

        public static bool TryGetResourceDataSchema(this OperationSet set, [MaybeNullWhen(false)] out InputModelType resourceType, InputNamespace? intputNamespace = null)
        {
            resourceType = null;
            // get the result from cache
            if (_resourceDataSchemaCache.TryGetValue(set.RequestPath, out resourceType))
            {
                return resourceType != null;
            }

            // try to get result from configuration
            if (Configuration.MgmtConfiguration.RequestPathToResourceData.TryGetValue(set.RequestPath, out var resourceTypeName))
            {
                // find a schema with this name
                resourceType = FindObjectSchemaWithName(resourceTypeName, intputNamespace);
                if (resourceType == null)
                {
                    throw new ErrorHelpers.ErrorException($"cannot find an object schema with name {resourceTypeName} in the request-path-to-resource-data configuration");
                }
                _resourceDataSchemaCache.TryAdd(set.RequestPath, resourceType);
                return true;
            }

            // try to find it in the partial resource list
            if (Configuration.MgmtConfiguration.PartialResources.TryGetValue(set.RequestPath, out resourceTypeName))
            {
                resourceType = FindObjectSchemaWithName(resourceTypeName, intputNamespace);
                if (resourceType == null)
                {
                    throw new ErrorHelpers.ErrorException($"cannot find an object schema with name {resourceTypeName} in the request-path-to-resource-data configuration");
                }
                _resourceDataSchemaCache.TryAdd(set.RequestPath, resourceType);
                return true;
            }

            // try to get another configuration to see if this is marked as not a resource
            if (Configuration.MgmtConfiguration.RequestPathIsNonResource.Contains(set.RequestPath))
            {
                MgmtReport.Instance.TransformSection.AddTransformLog(
                    new TransformItem(TransformTypeName.RequestPathIsNonResource, set.RequestPath), set.RequestPath, "Path marked as non-resource: " + set.RequestPath);
                _resourceDataSchemaCache.TryAdd(set.RequestPath, null);
                return false;
            }

            // Check if the request path has even number of segments after the providers segment
            if (!CheckEvenSegments(set.RequestPath))
                return false;

            // before we are finding any operations, we need to ensure this operation set has a GET request.
            if (set.FindOperation(RequestMethod.Get) is null)
                return false;

            // try put operation to get the resource name
            if (set.TryOperationWithMethod(RequestMethod.Put, out resourceType))
            {
                _resourceDataSchemaCache.TryAdd(set.RequestPath, resourceType);
                return true;
            }

            // try get operation to get the resource name
            if (set.TryOperationWithMethod(RequestMethod.Get, out resourceType))
            {
                _resourceDataSchemaCache.TryAdd(set.RequestPath, resourceType);
                return true;
            }

            // We tried everything, this is not a resource
            _resourceDataSchemaCache.TryAdd(set.RequestPath, null);
            return false;
        }

        private static bool CheckEvenSegments(string requestPath)
        {
            var index = requestPath.LastIndexOf(ProvidersSegment);
            // this request path does not have providers segment - it can be a "ById" request, skip to next criteria
            if (index < 0)
                return true;
            // get whatever following the providers
            var following = requestPath.Substring(index);
            var segments = following.Split("/", StringSplitOptions.RemoveEmptyEntries);
            return segments.Length % 2 == 0;
        }

        private static bool TryOperationWithMethod(this OperationSet set, RequestMethod method, [MaybeNullWhen(false)] out InputModelType resourceType)
        {
            resourceType = null;

            var operation = set.FindOperation(method);
            if (operation is null)
                return false;
            // find the response with code 200
            var response = operation.GetServiceResponse();
            if (response is null)
                return false;
            // find the response schema
            var responseType = response.BodyType as InputModelType;
            if (responseType is null)
                return false;

            // we need to verify this schema has ID, type and name so that this is a resource model
            if (!responseType.IsResourceModel())
                return false;

            resourceType = responseType;
            return true;
        }
    }
}
