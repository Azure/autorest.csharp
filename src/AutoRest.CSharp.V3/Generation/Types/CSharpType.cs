// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;

namespace AutoRest.CSharp.V3.Generation.Types
{
    internal class CSharpType
    {
        public CSharpType(Type type, params CSharpType[] arguments) : this(type, false, arguments)
        {
        }

        public CSharpType(Type type, bool isNullable, params CSharpType[] arguments)
        {
            Debug.Assert(type.Namespace != null, "type.Namespace != null");

            Namespace = type.Namespace;
            Name = type.IsGenericType ? type.Name.Substring(0, type.Name.IndexOf('`')) : type.Name;
            IsNullable = isNullable;
            Arguments = arguments;
            IsValueType = type.IsValueType;
            FrameworkType = type;
        }

        public CSharpType(string ns, string name, bool isValueType = false, bool isNullable = false)
        {
            Name = name;
            IsValueType = isValueType;
            IsNullable = isNullable;
            Namespace = ns;
        }

        public string Namespace { get; }
        public string Name { get; }
        public bool IsValueType { get; }
        public CSharpType[] Arguments { get; } = Array.Empty<CSharpType>();
        public Type? FrameworkType { get; }
        public bool IsNullable { get; }

        public CSharpType WithNullable(bool isNullable) => FrameworkType != null
            ? new CSharpType(FrameworkType, isNullable, Arguments)
            : new CSharpType(Namespace, Name, IsValueType, isNullable);
    }
}
