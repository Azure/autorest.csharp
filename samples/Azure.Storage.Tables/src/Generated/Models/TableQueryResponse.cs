// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Storage.Tables.Models
{
    /// <summary> The properties for the table query response. </summary>
    public partial class TableQueryResponse
    {
        /// <summary> Initializes a new instance of TableQueryResponse. </summary>
        internal TableQueryResponse()
        {
            Value = new ChangeTrackingList<TableResponseProperties>();
        }

        /// <summary> Initializes a new instance of TableQueryResponse. </summary>
        /// <param name="odataMetadata"> The metadata response of the table. </param>
        /// <param name="value"> List of tables. </param>
        internal TableQueryResponse(string odataMetadata, IReadOnlyList<TableResponseProperties> value)
        {
            OdataMetadata = odataMetadata;
            Value = value;
        }

        /// <summary> The metadata response of the table. </summary>
        public string OdataMetadata { get; }
        /// <summary> List of tables. </summary>
        public IReadOnlyList<TableResponseProperties> Value { get; }
    }
}
