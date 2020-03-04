// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    internal class CodeGenSchemaMemberAttribute : Attribute
    {
        public CodeGenSchemaMemberAttribute(string schemaName)
        {
        }
    }
}