// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models;

namespace AutoRest.CSharp.Common.Output.Models.Types
{
    internal record ModelMethodDefinition(MethodSignature Signature, ModelWriter.MethodBodyImplementation BodyImplementation) { }
}
