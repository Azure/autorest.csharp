// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace azure_special_properties.Models
{
    /// <summary> Parameter group. </summary>
    public partial class HeaderCustomNamedRequestIdParamGroupingParameters
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="HeaderCustomNamedRequestIdParamGroupingParameters"/>. </summary>
        /// <param name="fooClientRequestId"> The fooRequestId. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fooClientRequestId"/> is null. </exception>
        public HeaderCustomNamedRequestIdParamGroupingParameters(string fooClientRequestId)
        {
            Argument.AssertNotNull(fooClientRequestId, nameof(fooClientRequestId));

            FooClientRequestId = fooClientRequestId;
        }

        /// <summary> Initializes a new instance of <see cref="HeaderCustomNamedRequestIdParamGroupingParameters"/>. </summary>
        /// <param name="fooClientRequestId"> The fooRequestId. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal HeaderCustomNamedRequestIdParamGroupingParameters(string fooClientRequestId, Dictionary<string, BinaryData> rawData)
        {
            FooClientRequestId = fooClientRequestId;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="HeaderCustomNamedRequestIdParamGroupingParameters"/> for deserialization. </summary>
        internal HeaderCustomNamedRequestIdParamGroupingParameters()
        {
        }

        /// <summary> The fooRequestId. </summary>
        public string FooClientRequestId { get; }
    }
}
