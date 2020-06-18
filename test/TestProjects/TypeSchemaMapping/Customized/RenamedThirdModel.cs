// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure;
using Azure.Core;

namespace CustomNamespace
{
    [CodeGenModel("ThirdModel")]
    internal partial class RenamedThirdModel
    {
        [CodeGenMember("ETag")]
        private ETag CustomizedETagProperty { get; }

        [CodeGenMember("CreatedAt")]
        private DateTime CustomizedCreatedAtProperty { get; }
    }
}
