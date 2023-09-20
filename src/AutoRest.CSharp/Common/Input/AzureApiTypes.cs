// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Azure;

namespace AutoRest.CSharp.Common.Input
{
    internal class AzureApiTypes : ApiTypes
    {
        public override Type ResponseType => typeof(Response);
        public override Type ResponseOfTType => typeof(Response<>);
    }
}
