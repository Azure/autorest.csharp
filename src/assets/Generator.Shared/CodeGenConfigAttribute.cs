// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;

namespace Azure.Core
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    internal class CodeGenConfigAttribute : Attribute
    {
        public string Name { get; }
        public object Value { get; }

        public CodeGenConfigAttribute(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }
}
