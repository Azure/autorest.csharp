﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace AutoRest.CSharp.Output.Models.Requests
{
    internal class UrlEncodedBody : RequestBody
    {
        public record NamedReferenceOrConstant (string Name, ReferenceOrConstant Value);

        public List<NamedReferenceOrConstant> Values { get; set; }= new List<NamedReferenceOrConstant>();

        public UrlEncodedBody()
        {
        }

        public void Add (string parameter, ReferenceOrConstant value)
        {
            Values.Add(new NamedReferenceOrConstant (parameter, value));
        }
    }
}
