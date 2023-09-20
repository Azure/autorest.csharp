// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ServiceModel.Rest;

namespace AutoRest.CSharp.Common.Input
{
    internal class SystemApiTypes : ApiTypes
    {
        public override Type ResponseType => typeof(Result);

        public override Type ResponseOfTType => typeof(Result<>);
    }
}
