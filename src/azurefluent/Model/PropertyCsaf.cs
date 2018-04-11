// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using AutoRest.Core.Model;
using AutoRest.Core.Utilities;
using AutoRest.CSharp.Model;
using AutoRest.Extensions;
using Newtonsoft.Json;

namespace AutoRest.CSharp.Azure.Fluent.Model
{
    public class PropertyCsaf : PropertyCs
    {
        public override string ModelTypeName => ResourcePropertyOverride ? "new " + base.ModelTypeName : base.ModelTypeName;

        public bool ResourcePropertyOverride { get; set; }
    }
}