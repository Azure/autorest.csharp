// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Storage.Tables.Models
{
    /// <summary> The response for a single table. </summary>
    public partial class TableResponse : TableResponseProperties
    {
        /// <summary> Initializes a new instance of TableResponse. </summary>
        internal TableResponse()
        {
        }

        /// <summary> Initializes a new instance of TableResponse. </summary>
        /// <param name="tableName"> The name of the table. </param>
        /// <param name="odataType"> The odata type of the table. </param>
        /// <param name="odataId"> The id of the table. </param>
        /// <param name="odataEditLink"> The edit link of the table. </param>
        /// <param name="odataMetadata"> The metadata response of the table. </param>
        internal TableResponse(string tableName, string odataType, string odataId, string odataEditLink, string odataMetadata) : base(tableName, odataType, odataId, odataEditLink)
        {
            OdataMetadata = odataMetadata;
        }

        /// <summary> The metadata response of the table. </summary>
        public string OdataMetadata { get; }
    }
}
