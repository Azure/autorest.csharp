// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using CustomizedTypeSpec;

namespace CustomizedTypeSpec
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class CodeGenClientAttribute : CodeGenTypeAttribute
    {
        public Type? ParentClient { get; set; }

        public CodeGenClientAttribute(string originalName) : base(originalName)
        {
        }
    }
}
