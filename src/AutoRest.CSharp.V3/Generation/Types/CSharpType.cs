// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using AutoRest.CSharp.V3.Output.Models.Types;

namespace AutoRest.CSharp.V3.Generation.Types
{
    internal class CSharpType
    {
        private readonly ITypeProvider? _implementation;
        private readonly Type? _type;

        public CSharpType(Type type, params CSharpType[] arguments) : this(type, false, arguments)
        {
        }

        public CSharpType(Type type, bool isNullable, params CSharpType[] arguments)
        {
            Debug.Assert(type.Namespace != null, "type.Namespace != null");
            _type = type;

            Namespace = type.Namespace;
            Name = type.IsGenericType ? type.Name.Substring(0, type.Name.IndexOf('`')) : type.Name;
            IsNullable = isNullable;
            Arguments = arguments;
            IsValueType = type.IsValueType;
        }

        public CSharpType(ITypeProvider implementation, string ns, string name, bool isValueType = false, bool isNullable = false)
        {
            _implementation = implementation;
            Name = name;
            IsValueType = isValueType;
            IsNullable = isNullable;
            Namespace = ns;
        }

        public string Namespace { get; }
        public string Name { get; }
        public bool IsValueType { get; }
        public CSharpType[] Arguments { get; } = Array.Empty<CSharpType>();
        public bool IsFrameworkType => _type != null;
        public Type FrameworkType => _type ?? throw new InvalidOperationException("Not a framework type");
        public ITypeProvider Implementation => _implementation ?? throw new InvalidOperationException("Not implemented type");
        public bool IsNullable { get; }

        public CSharpType WithNullable(bool isNullable) => IsFrameworkType
            ? new CSharpType(FrameworkType, isNullable, Arguments)
            : new CSharpType(Implementation, Namespace, Name, IsValueType, isNullable);
    }
}
