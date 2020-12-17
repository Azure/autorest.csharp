// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;

namespace AutoRest.CSharp.Output.Models.Responses
{
    internal struct StatusCodes
    {
        public StatusCodes(int? code, int? family)
        {
            Code = code;
            Family = family;
        }

        public int? Code { get; }
        public int? Family { get; }
    }
}
