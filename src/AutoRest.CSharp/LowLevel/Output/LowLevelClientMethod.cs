// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.Output.Models.Requests;

namespace AutoRest.CSharp.Output.Models
{    internal class LowLevelClientMethod
    {
        public LowLevelClientMethod(RestClientMethod restClientMethod, Diagnostic diagnostics)
        {
            RestClientMethod = restClientMethod;
            Diagnostics = diagnostics;
        }

        public RestClientMethod RestClientMethod { get; }
        public Diagnostic Diagnostics { get; }
    }
}
