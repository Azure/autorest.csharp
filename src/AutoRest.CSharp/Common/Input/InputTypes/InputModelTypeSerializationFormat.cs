// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace AutoRest.CSharp.Common.Input
{
    [Flags]
    internal enum InputModelTypeSerializationFormat
    {
        None = 0,
        Json = 1,
        Xml = 2,
    }
}
