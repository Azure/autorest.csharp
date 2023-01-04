// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using Azure;

namespace AutoRest.CSharp.MgmtTest.Models
{
    internal class MockTestCase : OperationExample
    {
        public MockTestCase(string operationId, MgmtTypeProvider carrier, MgmtClientOperation operation, ExampleModel example) : base(operationId, carrier, operation, example)
        {
        }

        protected virtual string GetMethodName(bool hasSuffix)
            => hasSuffix ? $"{Operation.Name}_{Name.ToCleanName()}" : Operation.Name;

        public MethodSignature GetMethodSignature(bool hasSuffix) => new MethodSignature(
                Name: GetMethodName(hasSuffix),
                Description: null,
                Summary: null,
                Modifiers: MethodSignatureModifiers.Public | MethodSignatureModifiers.Async,
                ReturnType: typeof(Task),
                ReturnDescription: null,
                Parameters: Array.Empty<Parameter>());

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
                // if this parameter is a body parameter, we might have changed it to required, and we cannot tell if we have changed it on the codemodel right now. In this case we just fake an empty body.
                if (parameter.DefaultValue == null && parameter.RequestLocation == RequestLocation.Body)
                {
                    exampleParameter ??= new() { ExampleValue = new() { Properties = new() } };
                }
                if (exampleParameter == null)
                {
                    // if this is a required parameter and we did not find the corresponding parameter in the examples, we throw an exception.
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

        protected override ExampleValue ReplacePathParameterValue(string serializedName, CSharpType type, ExampleValue value)
        {
            if (serializedName == "subscriptionId")
            {
                return new ExampleValue()
                {
                    Language = value.Language,
                    Schema = value.Schema,
                    RawValue = ReplaceValueForSubscriptionId((string)value.RawValue!)
                };
            }

            return value;
        }

        private readonly static Regex _regexForGuid = new Regex("^{[A-Z0-9]{8}-([A-Z0-9]{4}-){3}[A-Z0-9]{12}}$");
        private const string _fallbackSubscriptionId = "00000000-0000-0000-0000-000000000000";

        private string ReplaceValueForSubscriptionId(string rawValue)
        {
            if (_regexForGuid.IsMatch(rawValue))
                return rawValue;

            return _fallbackSubscriptionId;
        }
    }
}
