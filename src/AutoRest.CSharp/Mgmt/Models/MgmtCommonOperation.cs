// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
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
            _implementations = new(implementations);
            MethodParameters = implementations.First().MethodParameters;
            ReturnType = returnType;
            Name = name;
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

            // TODO -- add a configuration to control whether we need this virtual keyword. And if this configuration is on, we will generate this method with the "new" keyword nevertheless (for backward compat purpose)
            return clientOperation.MethodSignature with
            {
                Modifiers = MethodSignatureModifiers.Public | MethodSignatureModifiers.New | MethodSignatureModifiers.Virtual
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
