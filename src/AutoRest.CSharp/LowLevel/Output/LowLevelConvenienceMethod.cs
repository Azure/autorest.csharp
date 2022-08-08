﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Output.Models
{
    internal record LowLevelConvenienceMethod(MethodSignature Signature, CSharpType? ResponseType, Parameter? BodyParameter, Diagnostic? Diagnostic);
}
