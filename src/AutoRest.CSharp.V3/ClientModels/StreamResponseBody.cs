﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.IO;

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class StreamResponseBody : ResponseBody
    {
        public override ClientTypeReference Type { get; } = new FrameworkTypeReference(typeof(Stream));
    }
}
