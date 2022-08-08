// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;

namespace AutoRest.CSharp.MgmtTest.Models
{
    internal class OperationExample
    {
        private ExampleModel _example;
        public string OperationId { get; }
        public string Name => _example.Name;

        public MgmtTypeProvider Carrier { get; }
        public MgmtClientOperation Operation { get; }

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

        public OperationExample(string operationId, MgmtTypeProviderAndOperation providerAndOperation, ExampleModel example)
        {
            OperationId = operationId;
            _example = example;
            Carrier = providerAndOperation.Carrier;
            Operation = providerAndOperation.Operation;
        }

        private MgmtRestOperation GetRestOperationFromOperationId()
        {
            foreach (var operation in Operation)
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

        protected string GetParameterSerializedName(string name) => EnsureParameterSerializedNames()[name];

        private static string GetRequestParameterName(RequestParameter requestParameter)
        {
            var language = requestParameter.Language.Default;
            return language.SerializedName ?? language.Name;
        }

        private ExampleParameter FindPathExampleParameterBySerializedName(string serializedName)
        {
            var parameter = FindExampleParameterBySerializedName(PathParameters, serializedName);

            // we throw exceptions here because path parameter cannot be optional, therefore if we do not find a parameter in the example, there must be an issue in the example
            if (parameter == null)
                throw new InvalidOperationException($"Cannot find a parameter in test case {_example.Name} with the name of {serializedName}");

            return parameter;
        }

        protected ExampleParameter? FindExampleParameterBySerializedName(IEnumerable<ExampleParameter> parameters, string name)
            => parameters.FirstOrDefault(p => GetRequestParameterName(p.Parameter) == name);
    }
}
