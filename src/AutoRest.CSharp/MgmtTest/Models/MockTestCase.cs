// Copyright (c) Microsoft Corporation. All rights reserved.
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
    internal class MockTestCase
    {
        private ExampleModel _example;
        public string OperationId { get; }
        public string Name => _example.Name;
        public MgmtClientOperation ClientOperation { get; }
        private MgmtRestOperation? _restOperation;
        public MgmtRestOperation RestOperation => _restOperation ??= GetRestOperationFromOperationId();
        public RequestPath RequestPath => RestOperation.RequestPath;
        /// <summary>
        /// All the parameters defined in this test case
        /// We do not need to distiguish between ClientParameters and MethodParameters because we usually change that in code model transformation
        /// </summary>
        public IEnumerable<ExampleParameter> AllParameters => _example.AllParameters;
        private IEnumerable<ExampleParameter>? _pathParameters;
        public IEnumerable<ExampleParameter> PathParameters => _pathParameters ??= AllParameters.Where(p => p.Parameter.In == HttpParameterIn.Path);

        public MgmtTypeProvider Carrier { get ; }

        public MockTestCase(string operationId, MgmtTypeProvider provider, MgmtClientOperation clientOperation, ExampleModel example)
        {
            OperationId = operationId;
            Carrier = provider;
            _example = example;
            ClientOperation = clientOperation;
        }

        public MethodSignature GetMethodSignature(bool hasSuffix)
        {
            var methodName = ClientOperation.Name;
            if (hasSuffix)
                methodName += $"_{_example.Name.ToCleanName()}";
            return new MethodSignature(
                Name: methodName,
                Description: null,
                Summary: null,
                Modifiers: MethodSignatureModifiers.Public | MethodSignatureModifiers.Async,
                ReturnType: typeof(Task),
                ReturnDescription: null,
                Parameters: Array.Empty<Parameter>());
        }

        private MgmtRestOperation GetRestOperationFromOperationId()
        {
            foreach (var operation in ClientOperation)
            {
                if (operation.OperationId == OperationId)
                    return operation;
            }

            throw new InvalidOperationException($"Cannot find operationId {OperationId} in example {_example.Name}");
        }

        /// <summary>
        /// Returns the values to construct a resource identifier for the input request path
        /// This method does not validate the parenting relationship between the request path passing in and the request path inside this test case
        /// The passing in request path should always be a parent of the request path in this test case
        /// </summary>
        /// <param name="requestPath"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public IEnumerable<FormattableString> ComposeResourceIdentifierParameterValues(RequestPath requestPath)
        {
            // we first take the same amount of segments from my own request path, in case there is a case that the parameter names between different paths are different
            var piecesFromMyOwn = RequestPath.Take(requestPath.Count);
            // there should be a contract that we will never have two parameters with the same name in one path
            foreach (var referenceSegment in piecesFromMyOwn.Where(segment => segment.IsReference))
            {
                // find a path parameter in our path parameters for one with same name
                var serializedName = GetParameterSerializedName(referenceSegment.ReferenceName);
                var parameter = FindPathExampleParameterBySerializedName(serializedName);
                // considering here is the path parameter, therefore it should always be a simple type, string, int or enum
                var rawValue = parameter.ExampleValue.RawValue;
                if (rawValue == null)
                    throw new InvalidOperationException($"The value of required path parameter {serializedName} in example {_example.Name} is not specified");
                // replace the value of subscription id to avoid the sdk complain about the values not being a guid
                if (serializedName == "subscriptionId")
                    rawValue = ReplaceValueForSubscriptionId((string)rawValue);

                yield return $"\"{rawValue}\"";
            }
        }

        private readonly static Regex _regexForGuid = new Regex("^{[A-Z0-9]{8}-([A-Z0-9]{4}-){3}[A-Z0-9]{12}}$");
        private const string _fallbackSubscriptionId = "00000000-0000-0000-0000-000000000000";

        private string ReplaceValueForSubscriptionId(string rawValue)
        {
            if (_regexForGuid.IsMatch(rawValue))
                return rawValue;

            return _fallbackSubscriptionId;
        }

        private ExampleParameter? FindExampleParameterBySerializedName(IEnumerable<ExampleParameter> parameters, string name)
            => parameters.FirstOrDefault(p => GetRequestParameterName(p.Parameter) == name);

        private ExampleParameter FindPathExampleParameterBySerializedName(string serializedName)
        {
            var parameter = FindExampleParameterBySerializedName(PathParameters, serializedName);

            // we throw exceptions here because path parameter cannot be optional, therefore if we do not find a parameter in the example, there must be an issue in the example
            if (parameter == null)
                throw new InvalidOperationException($"Cannot find a parameter in test case {_example.Name} with the name of {serializedName}");

            return parameter;
        }

        private static string GetRequestParameterName(RequestParameter requestParameter)
        {
            var language = requestParameter.Language.Default;
            return language.SerializedName ?? language.Name;
        }

        private Dictionary<string, ExampleParameterValue>? _parameterValueMapping;
        public Dictionary<string, ExampleParameterValue> ParameterValueMapping => _parameterValueMapping ??= EnsureParameterValueMapping();

        private Dictionary<string, string> EnsureParameterSerializedNames()
        {
            if (_parameterNameToSerializedNameMapping != null)
                return _parameterNameToSerializedNameMapping;

            _parameterNameToSerializedNameMapping = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            var operation = _example.Operation;
            var serviceRequest = operation.GetServiceRequest()!;

            var allRequestParameters = operation.Parameters.Concat(serviceRequest.Parameters);

            foreach (var requestParameter in allRequestParameters)
            {
                var serializedName = GetRequestParameterName(requestParameter);
                _parameterNameToSerializedNameMapping.Add(requestParameter.Language.Default.Name, serializedName);
            }

            return _parameterNameToSerializedNameMapping;
        }

        private Dictionary<string, string>? _parameterNameToSerializedNameMapping;

        private string GetParameterSerializedName(string name)
        {
            return EnsureParameterSerializedNames()[name];
        }

        private IEnumerable<Parameter> GetAllPossibleParameters()
        {
            // skip the first parameter if this method is an extension method, since that will be the extension resource
            var methodParameters = ClientOperation.MethodSignature.Modifiers.HasFlag(MethodSignatureModifiers.Extension) ?
                ClientOperation.MethodParameters.Skip(1) : ClientOperation.MethodParameters;

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
                        throw new InvalidOperationException($"Cannot find an example value for required parameter `{parameter.Name}` in example {_example.Name}");
                    // if it is optional, we just do not put it in the map indicates that in the invocation we could omit it
                }
                else
                {
                    result.Add(parameter.Name, new ExampleParameterValue(parameter, exampleParameter.ExampleValue, null));
                }
            }

            return result;
        }

        private static bool ProcessKnownParameters(Dictionary<string, ExampleParameterValue> result, Parameter parameter)
        {
            if (parameter == KnownParameters.WaitForCompletion)
            {
                result.Add(parameter.Name, new ExampleParameterValue(parameter, null, $"{typeof(WaitUntil)}.Completed"));
                return true;
            }
            if (parameter == KnownParameters.CancellationTokenParameter)
            {
                // we usually do not set this parameter in generated test cases
                return true;
            }

            return false;
        }
    }
}
