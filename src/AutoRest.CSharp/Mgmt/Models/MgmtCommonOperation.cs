// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
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
            Description,
            MethodSignatureModifiers.Public,
            IsPagingOperation ? new CSharpType(typeof(Pageable<>), ReturnType) : ReturnType,
            null,
            MethodParameters);

        private MethodSignature? _coreMethodSignature;
        public MethodSignature CoreMethodSignature => _coreMethodSignature ??= new MethodSignature(
            $"{Name}Core",
            null,
            Description,
            MethodSignatureModifiers.Protected,
            IsPagingOperation ? new CSharpType(typeof(Pageable<>), ReturnType) : ReturnType,
            null,
            MethodParameters);

        public bool IsPagingOperation => _implementations.First().IsPagingOperation;

        private string? _description;
        public string Description => _description ??= BuildDescription();

        // TODO
        private string BuildDescription()
        {
            return "placeholder";
        }
    }
}
