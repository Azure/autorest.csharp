// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Storage.Tables.Models
{
    /// <summary> The properties for the table entity query response. </summary>
    internal partial class TableEntityQueryResponse
    {
        /// <summary> Initializes a new instance of TableEntityQueryResponse. </summary>
        internal TableEntityQueryResponse()
        {
            Value = new ChangeTrackingList<IDictionary<string, object>>();
        }

        /// <summary> Initializes a new instance of TableEntityQueryResponse. </summary>
        /// <param name="odataMetadata"> The metadata response of the table. </param>
        /// <param name="value"> List of table entities. </param>
        internal TableEntityQueryResponse(string odataMetadata, IReadOnlyList<IDictionary<string, object>> value)
        {
            OdataMetadata = odataMetadata;
            Value = value;
        }

        /// <summary> The metadata response of the table. </summary>
        public string OdataMetadata { get; }
        /// <summary> List of table entities. </summary>
        public IReadOnlyList<IDictionary<string, object>> Value { get; }
    }
}
