// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Concurrent;
using System.Linq;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class TupleResourceDetection
    {
        private static ConcurrentDictionary<OperationGroup, bool> _valueCache = new ConcurrentDictionary<OperationGroup, bool>();

        public static bool IsTupleResource(this OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context)
        {
            bool result = false;
            if (_valueCache.TryGetValue(operationGroup, out result))
                return result;

            if (context.Configuration.MgmtConfiguration.OperationGroupIsTuple.Contains(operationGroup.Key))
            {
                result = true;
            }

            _valueCache.TryAdd(operationGroup, result);
            return result;
        }

        // This tuple detection algorithm works fine for AvailabilitySets, VirtualMachineExtensionImages, DedicatedHostGroups, DedicatedHosts, SshPublicKeys..etc
        // but it's doesn't work for VirtualMachines, Images, ProximityPlacementGroups..etc because of different naming convention and format.
        // TODO: We need to make it work for all possible resources before making it usable.

        /*private static bool IsTuple(OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context)
        {
            bool foundTuple = false;

            var resourceOperation = context.Library.GetResourceOperation(operationGroup);
            var resourceData = context.Library.GetResourceData(operationGroup);
            var getMethods = resourceOperation.RestClient.Methods.Where(m => m.Request.HttpMethod == RequestMethod.Get);
            var getMethodWithResourceDataResponse = getMethods.Where(m => m.Responses[0].ResponseBody?.Type.Name == resourceData.Type.Name);
            RestClientMethod? getMethod = null;
            if (getMethodWithResourceDataResponse != null && getMethodWithResourceDataResponse.Count() > 0)
            {
                getMethod = getMethodWithResourceDataResponse.First();
            }

            if (getMethod == null)
            {
                return foundTuple;
            }

            List<string> paramList = new();
            // This method gets the list of matching parameters. It matches the get
            // method parameters with resource type.
            GetParams(paramList, getMethod, resourceOperation.OperationGroup, context);

            // It checks if get method parameters length is greater than the matching parameters
            // length + 1, then it's a tuple, otherwise it's not a tuple.

            // Let's take AvailabilitySets as an example
            // Resource Type for AvailabilitySets is "Microsoft.Compute/availabilitySets"
            // Get method parameters are "Get( string resourceGroupName, string availabilitySetName)"
            // Matching parameter is availabilitySetName, so the below check will check if get method parameters
            // length which in this case is 2, is greater than matching parameters + 1 which is 2, then it's a tuple.
            // In this case the condition is false, so it's not a tuple.


            // Let's take VirtualMachineExtensionImage as an example
            // Resource Type for VirtualMachineExtensionImage is "Microsoft.Compute/locations/publishers/vmextension"
            // Get method parameters are "Get(string location, string publisherName, string type, string version)"
            // Matching parameters are location and publisherName, so the below check will check if get method parameters
            // length which in this case is 4, is greater than matching parameters + 1 which is 3, then it's a tuple.
            // In this case the condition is true, so it's a tuple.
            if (getMethod.Parameters.Length > paramList.Count + 1)
            {
                foundTuple = true;
            };

            return foundTuple;
        }

        private static void GetParams(List<string> paramList, RestClientMethod clientMethod, OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context)
        {
            var config = context.Configuration.MgmtConfiguration;
            var resourceType = operationGroup.ResourceType(config);

            if (IsTerminalState(operationGroup, context))
            {
                string[] paramArray = GetParamArray(resourceType);
                foreach (var param in paramArray)
                {
                    if (Exists(clientMethod.Parameters, param))
                        paramList.Add(param);
                }
            }
            else
            {
                var lastParam = GetLastParam(resourceType);
                if (Exists(clientMethod.Parameters, lastParam))
                {
                    paramList.Add(lastParam);
                }

                var parentOperationGroup = operationGroup.ParentOperationGroup(context);
                if (parentOperationGroup != null)
                    GetParams(paramList, clientMethod, parentOperationGroup, context);
            }
        }

        private static string[] GetParamArray(string resourceType)
        {
            var paramArr = resourceType.Split("/");
            return paramArr;
        }

        private static string GetLastParam(string resourceType)
        {
            var paramArr = resourceType.Split("/");
            return paramArr[paramArr.Length - 1];
        }

        private static bool Exists(Parameter[] parameters, string lastParam)
        {
            StringBuilder sb = new StringBuilder(lastParam.TrimEnd('s'));
            if (lastParam != "locations")
                sb.Append("Name");

            return parameters.Any(p => p.Name == sb.ToString());
        }

        private static OperationGroup? ParentOperationGroup(this OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context)
        {
            var config = context.Configuration.MgmtConfiguration;
            var parentResourceType = operationGroup.ParentResourceType(config);
            OperationGroup? parentOperationGroup = null;

            foreach (var opGroup in context.CodeModel.OperationGroups)
            {
                if (opGroup.ResourceType(context.Configuration.MgmtConfiguration).Equals(parentResourceType))
                {
                    parentOperationGroup = opGroup;
                    break;
                }
            }

            return parentOperationGroup;
        }

        private static bool IsTerminalState(OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context)
        {
            return operationGroup.ParentOperationGroup(context) == null;
        }*/
    }
}
