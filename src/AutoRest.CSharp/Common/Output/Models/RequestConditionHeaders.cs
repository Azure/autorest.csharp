// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace AutoRest.CSharp.Common.Output.Models
{
    [Flags]
    internal enum RequestConditionHeaders
    {
        None = 0,
        IfMatch = 1,
        IfNoneMatch = 2,
        IfModifiedSince = 4,
        IfUnmodifiedSince = 8
    }
}
