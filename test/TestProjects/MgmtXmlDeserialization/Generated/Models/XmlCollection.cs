// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using MgmtXmlDeserialization;

namespace MgmtXmlDeserialization.Models
{
    /// <summary> Paged Xml list representation. </summary>
    internal partial class XmlCollection
    {
        /// <summary> Initializes a new instance of XmlCollection. </summary>
        internal XmlCollection()
        {
            Value = new ChangeTrackingList<XmlInstanceData>();
        }

        /// <summary> Initializes a new instance of XmlCollection. </summary>
        /// <param name="value"> Page values. </param>
        /// <param name="count"> Total record count number across all pages. </param>
        /// <param name="nextLink"> Next page link if any. </param>
        internal XmlCollection(IReadOnlyList<XmlInstanceData> value, long? count, string nextLink)
        {
            Value = value;
            Count = count;
            NextLink = nextLink;
        }

        /// <summary> Page values. </summary>
        public IReadOnlyList<XmlInstanceData> Value { get; }
        /// <summary> Total record count number across all pages. </summary>
        public long? Count { get; }
        /// <summary> Next page link if any. </summary>
        public string NextLink { get; }
    }
}
