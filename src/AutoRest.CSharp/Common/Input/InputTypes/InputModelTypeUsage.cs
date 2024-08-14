// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace AutoRest.CSharp.Common.Input;

[Flags]
internal enum InputModelTypeUsage
{
    None = 0,
    Input = 1 << 1,
    Output = 1 << 2,
    ApiVersionEnum = 1 << 3,
    JsonMergePatch = 1 << 4,
    MultipartFormData = 1 << 5,
    Spread = 1 << 6,
    Error = 1 << 7,
    Json = 1 << 8,
    Xml = 1 << 9
}
