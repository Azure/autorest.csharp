// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.Common.Input;

namespace AutoRest.CSharp.Output.Models
{
    internal record ConvenienceMethodGenerationInfo()
    {
        public bool IsConvenienceMethodGenerated { get; init; } = false;

        public bool IsConvenienceMethodInternal { get; init; } = false;

        public ConvenienceMethodOmittingMessage? Message { get; init; }
    }
}
