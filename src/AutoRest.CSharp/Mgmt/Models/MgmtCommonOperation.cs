// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using Azure;

namespace AutoRest.CSharp.Mgmt.Models
{
    internal record MgmtCommonOperation
    {
        private HashSet<MgmtClientOperation> _implementations;

        public IReadOnlyList<Parameter> MethodParameters { get; }

        public CSharpType ReturnType { get; }

        public string Name { get; }

        public MgmtCommonOperation(string name, CSharpType returnType, IReadOnlyList<MgmtClientOperation> implementations)
        {
            ValidateMgmtCommonOperation(implementations);

            _implementations = new(implementations);
            MethodParameters = implementations.First().MethodParameters;
            ReturnType = returnType;
            Name = name;
        }

        private static void ValidateMgmtCommonOperation(IReadOnlyList<MgmtClientOperation> implementations)
        {
            if (!Configuration.MgmtConfiguration.IsStrictCommonOperationEnabled)
                return;

            // validate if they all have the same count of the parameters
            var countSet = new HashSet<string>();
            foreach (var operation in implementations)
            {
                // here we only include the optional parameters
                var optionalParameterList = operation.MethodParameters.Where(parameter => parameter.IsOptionalInSignature).Select(parameter => $"{parameter.Type.Namespace}.{parameter.Type.Name}");
                countSet.Add(string.Join(", ", optionalParameterList));
            }
            if (countSet.Count != 1)
            {
                var operationIds = implementations.SelectMany(operation => operation).Select(restOperation => restOperation.OperationId);
                throw new InvalidOperationException($"Common operation from {string.Join(", ", operationIds)} has inconsistent optional parameters. The optional parameter lists are {string.Join("; ", countSet)}");
            }

            // validate if these implementation operations all have the same parameter names
            var nameSet = new HashSet<string>();
            foreach (var operation in implementations)
            {
                var parameterNameList = operation.MethodParameters.Select(parameter => parameter.Name);
                nameSet.Add(string.Join(", ", parameterNameList));
            }
            if (nameSet.Count != 1)
            {
                var operationIds = implementations.SelectMany(operation => operation).Select(restOperation => restOperation.OperationId);
                throw new InvalidOperationException($"Common operation from {string.Join(", ", operationIds)} has inconsistent parameter names. The parameter lists are {string.Join("; ", nameSet)}");
            }
        }

        public bool Contains(MgmtClientOperation operation) => _implementations.Contains(operation);

        public bool Contains(MgmtRestOperation operation)
        {
            foreach (var op in _implementations)
            {
                if (op.Contains(operation))
                    return true;
            }

            return false;
        }

        private MethodSignature? _methodSignature;
        public MethodSignature MethodSignature => _methodSignature ??= new MethodSignature(
            Name,
            null,
            $"The default implementation for operation {Name}",
            MethodSignatureModifiers.Public,
            IsPagingOperation ? new CSharpType(typeof(Pageable<>), ReturnType) : ReturnType,
            null,
            MethodParameters);

        public MethodSignature GetNewMethodSignature(MgmtClientOperation clientOperation)
        {
            Debug.Assert(_implementations.Contains(clientOperation));

            var modifiers = MethodSignatureModifiers.Public | MethodSignatureModifiers.New;
            if (clientOperation.Any(restOperation => Configuration.MgmtConfiguration.VirtualOperations.Contains(restOperation.OperationId)))
            {
                modifiers |= MethodSignatureModifiers.Virtual;
            }
            return clientOperation.MethodSignature with
            {
                Modifiers = modifiers
            };
        }

        /// <summary>
        /// When writing the override of the core method, we need to use this method to get its signature because despite all the overriding methods have the compatible signature, they could have different parameter names
        /// </summary>
        /// <param name="clientOperation"></param>
        /// <returns></returns>
        public MethodSignature GetCoreMethodOverrideSignature(MgmtClientOperation clientOperation)
        {
            Debug.Assert(_implementations.Contains(clientOperation));

            return new MethodSignature(
                $"{Name}Core",
                null,
                $"The core implementation for operation {Name}\n{clientOperation.Description}",
                MethodSignatureModifiers.Protected | MethodSignatureModifiers.Override,
                IsPagingOperation ? new CSharpType(typeof(Pageable<>), ReturnType) : ReturnType,
                null,
                clientOperation.MethodParameters);
        }

        private MethodSignature? _coreMethodSignature;
        public MethodSignature CoreMethodSignature => _coreMethodSignature ??= new MethodSignature(
            $"{Name}Core",
            null,
            $"The core implementation for operation {Name}",
            MethodSignatureModifiers.Protected,
            IsPagingOperation ? new CSharpType(typeof(Pageable<>), ReturnType) : ReturnType,
            null,
            MethodParameters);

        public bool IsPagingOperation => _implementations.First().IsPagingOperation;
    }
}
