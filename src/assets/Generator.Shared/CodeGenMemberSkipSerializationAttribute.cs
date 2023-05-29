// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;

namespace Azure.Core
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class CodeGenMemberSkipSerializationAttribute : Attribute
    {
        public string PropertyName { get; }

        public bool SkipSerialization { get; }

        public bool SkipDeserialization { get; }

        public CodeGenMemberSkipSerializationAttribute(string propertyName) : this(propertyName, true, true)
        {
        }

        public CodeGenMemberSkipSerializationAttribute(string propertyName, bool skipSerialization, bool skipDeserialization)
        {
            PropertyName = propertyName;
            SkipSerialization = skipSerialization;
            SkipDeserialization = skipDeserialization;
        }
    }
}
