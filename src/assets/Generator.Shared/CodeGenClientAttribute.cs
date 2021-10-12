// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class CodeGenClientAttribute : CodeGenTypeAttribute
    {
        public Type? ParentClient { get; set; }
        public bool ForcePublicConstructors { get; set; } = false;

        public CodeGenClientAttribute(string? originalName = default) : base(originalName)
        {
        }
    }
}
