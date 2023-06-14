// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace azure_special_properties.Models
{
    /// <summary> Parameter group. </summary>
    public partial class HeaderCustomNamedRequestIdParamGroupingParameters
    {
        /// <summary> Initializes a new instance of HeaderCustomNamedRequestIdParamGroupingParameters. </summary>
        /// <param name="fooClientRequestId"> The fooRequestId. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fooClientRequestId"/> is null. </exception>
        public HeaderCustomNamedRequestIdParamGroupingParameters(string fooClientRequestId)
        {
            Argument.AssertNotNull(fooClientRequestId, nameof(fooClientRequestId));

            FooClientRequestId = fooClientRequestId;
        }

        /// <summary> The fooRequestId. </summary>
        public string FooClientRequestId { get; }
    }
}
