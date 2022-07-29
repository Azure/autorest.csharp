// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Output.Models
{
    internal record LowLevelConvenienceMethod(LowLevelClientMethod LowLevelClientMethod, MethodSignature Signature, CSharpType? ResponseType, Parameter? BodyParameter, Diagnostic? Diagnostic);
}
