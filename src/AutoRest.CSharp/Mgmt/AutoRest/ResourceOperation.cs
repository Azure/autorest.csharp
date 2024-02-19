// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRest.CSharp.Mgmt.Models;

namespace AutoRest.CSharp.Mgmt.AutoRest
{
    public class ResourceOperation
    {
        public string? Name { get; set; }
        public string? Path { get; set; }
        public string? Method { get; set; }
        public string? OperationID { get; set; }
        public bool IsLongRunning { get; set; }
        public PagingMetadata? PagingMetadata { get; set; }
        public string? Description { get; set; }
    }
}
