// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using AutoRest.Core;
using AutoRest.Core.Model;
using AutoRest.CSharp.Model;

namespace AutoRest.CSharp.Azure.Fluent.Model
{
    public class EnumTypeCsaf : EnumTypeCs
    {
        protected override string ModelAsStringType => Name;

        public override bool IsValueType => !(ModelAsString || OldModelAsString) && !string.IsNullOrEmpty(Name.FixedValue);
    }
}