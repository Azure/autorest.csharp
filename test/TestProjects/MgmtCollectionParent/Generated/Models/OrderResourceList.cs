// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using MgmtCollectionParent;

namespace MgmtCollectionParent.Models
{
    /// <summary> List of orders. </summary>
    internal partial class OrderResourceList
    {
        /// <summary> Initializes a new instance of OrderResourceList. </summary>
        internal OrderResourceList()
        {
            Value = new ChangeTrackingList<OrderResourceData>();
        }

        /// <summary> Initializes a new instance of OrderResourceList. </summary>
        /// <param name="value"> List of order resources. </param>
        /// <param name="nextLink"> Link for the next set of order resources. </param>
        internal OrderResourceList(IReadOnlyList<OrderResourceData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> List of order resources. </summary>
        public IReadOnlyList<OrderResourceData> Value { get; }
        /// <summary> Link for the next set of order resources. </summary>
        public string NextLink { get; }
    }
}
