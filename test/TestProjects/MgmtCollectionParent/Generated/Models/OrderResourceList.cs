// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using MgmtCollectionParent;

namespace MgmtCollectionParent.Models
{
    /// <summary> List of orders. </summary>
    internal partial class OrderResourceList
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::MgmtCollectionParent.Models.OrderResourceList
        ///
        /// </summary>
        internal OrderResourceList()
        {
            Value = new ChangeTrackingList<OrderResourceData>();
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtCollectionParent.Models.OrderResourceList
        ///
        /// </summary>
        /// <param name="value"> List of order resources. </param>
        /// <param name="nextLink"> Link for the next set of order resources. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal OrderResourceList(IReadOnlyList<OrderResourceData> value, string nextLink, Dictionary<string, BinaryData> rawData)
        {
            Value = value;
            NextLink = nextLink;
            _rawData = rawData;
        }

        /// <summary> List of order resources. </summary>
        public IReadOnlyList<OrderResourceData> Value { get; }
        /// <summary> Link for the next set of order resources. </summary>
        public string NextLink { get; }
    }
}
