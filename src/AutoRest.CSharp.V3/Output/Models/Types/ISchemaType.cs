// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.Input;

namespace AutoRest.CSharp.V3.Output.Models.Types
{
    internal interface ISchemaType: ITypeProvider
    {
        Schema Schema { get; }
    }
}
