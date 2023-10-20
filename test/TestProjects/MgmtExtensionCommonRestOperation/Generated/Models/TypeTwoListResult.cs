// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using MgmtExtensionCommonRestOperation;

namespace MgmtExtensionCommonRestOperation.Models
{
    /// <summary> The TypeTwoListResult. </summary>
    internal partial class TypeTwoListResult
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="TypeTwoListResult"/>. </summary>
        /// <param name="value"> The list of of type twos. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal TypeTwoListResult(IEnumerable<TypeTwoData> value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value.ToList();
        }

        /// <summary> Initializes a new instance of <see cref="TypeTwoListResult"/>. </summary>
        /// <param name="value"> The list of of type twos. </param>
        /// <param name="nextLink"> The uri to fetch the next page of Virtual Machine Scale Set VMs. Call ListNext() with this to fetch the next page of VMSS VMs. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal TypeTwoListResult(IReadOnlyList<TypeTwoData> value, string nextLink, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Value = value;
            NextLink = nextLink;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="TypeTwoListResult"/> for deserialization. </summary>
        internal TypeTwoListResult()
        {
        }

        /// <summary> The list of of type twos. </summary>
        public IReadOnlyList<TypeTwoData> Value { get; }
        /// <summary> The uri to fetch the next page of Virtual Machine Scale Set VMs. Call ListNext() with this to fetch the next page of VMSS VMs. </summary>
        public string NextLink { get; }
    }
}
