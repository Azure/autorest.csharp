﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using Azure;

namespace AutoRest.CSharp.MgmtTest.Models
{
    internal class MockTestCase : OperationExample
    {
        public MockTestCase(string operationId, MgmtTypeProviderAndOperation providerAndOperation, ExampleModel example) : base(operationId, providerAndOperation, example)
        {
        }

        public MethodSignature GetMethodSignature(bool hasSuffix)
        {
            var methodName = Operation.Name;
            if (hasSuffix)
                methodName += $"_{Name.ToCleanName()}";
            return new MethodSignature(
                Name: methodName,
                Description: null,
                Summary: null,
                Modifiers: MethodSignatureModifiers.Public | MethodSignatureModifiers.Async,
                ReturnType: typeof(Task),
                ReturnDescription: null,
                Parameters: Array.Empty<Parameter>());
        }

        private MgmtTypeProvider? _parent;
        public MgmtTypeProvider? Parent => _parent ??= GetParent();

        private MgmtTypeProvider? GetParent()
        {
            if (Carrier is not Resource resource)
                return null;
            var parents = resource.Parent();
            // TODO -- find a way to determine which parent to use. Only for prototype, here we use the first
            // Only when this resource is a "scope resource", we could have multiple parents
            // We could use the value of the scope variable, get the resource type from it to know which resource we should use as a parent here
            return parents.First();
        }

        private static string GetRequestParameterName(RequestParameter requestParameter)
        {
            var language = requestParameter.Language.Default;
            return language.SerializedName ?? language.Name;
        }

        private Dictionary<string, ExampleParameterValue>? _parameterValueMapping;
        public Dictionary<string, ExampleParameterValue> ParameterValueMapping => _parameterValueMapping ??= EnsureParameterValueMapping();

        private IEnumerable<Parameter> GetAllPossibleParameters()
        {
            // skip the first parameter if this method is an extension method, since that will be the extension resource
            var methodParameters = Operation.MethodSignature.Modifiers.HasFlag(MethodSignatureModifiers.Extension) ?
                Operation.MethodParameters.Skip(1) : Operation.MethodParameters;

            return Carrier.ExtraConstructorParameters.Concat(methodParameters);
        }

        private Dictionary<string, ExampleParameterValue> EnsureParameterValueMapping()
        {
            var result = new Dictionary<string, ExampleParameterValue>();
            // get the "serialized name" of the parameters based on the raw request path
            foreach (var parameter in GetAllPossibleParameters())
            {
                if (ProcessKnownParameters(result, parameter))
                    continue;

                var exampleParameter = FindExampleParameterBySerializedName(AllParameters, GetParameterSerializedName(parameter.Name));
                if (exampleParameter == null)
                {
                    // we did not find the corresponding parameter in the examples, see if this is a required parameter
                    if (parameter.DefaultValue == null)
                        throw new InvalidOperationException($"Cannot find an example value for required parameter `{parameter.Name}` in example {Name}");
                    // if it is optional, we just do not put it in the map indicates that in the invocation we could omit it
                }
                else
                {
                    result.Add(parameter.Name, new ExampleParameterValue(parameter, exampleParameter.ExampleValue));
                }
            }

            return result;
        }

        private static bool ProcessKnownParameters(Dictionary<string, ExampleParameterValue> result, Parameter parameter)
        {
            if (parameter == KnownParameters.WaitForCompletion)
            {
                result.Add(parameter.Name, new ExampleParameterValue(parameter, $"{typeof(WaitUntil)}.Completed"));
                return true;
            }
            if (parameter == KnownParameters.CancellationTokenParameter)
            {
                // we usually do not set this parameter in generated test cases
                return true;
            }

            return false;
        }

        public bool IsConvenientOperation => Operation.IsConvenientOperation;

        public bool IsLro => Operation.IsLongRunningOperation;

        public bool IsPageable => Operation.IsPagingOperation;
    }
}
