﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Output;
using Azure.ResourceManager.Core;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal static class ResourceIdentifierChooser
    {
        internal static string GetResourceIdentifierType(this OperationGroup operation)
        {
            return "TenantResourceIdentifier"; //TODO: remove hard coded value during 5779
        }
    }
}
