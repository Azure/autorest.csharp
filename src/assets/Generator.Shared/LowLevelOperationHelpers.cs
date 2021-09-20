// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using Azure;

internal static class LowLevelOperationHelpers
{
    public static readonly Func<Response, BinaryData> ResponseContentSelector = (Response r) => r.Content;
}
