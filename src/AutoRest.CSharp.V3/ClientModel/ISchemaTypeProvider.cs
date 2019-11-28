﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.Pipeline.Generated;

namespace AutoRest.CSharp.V3.ClientModel
{
    internal interface ISchemaTypeProvider
    {
        string Name { get; }
        Schema Schema { get; }
    }
}
