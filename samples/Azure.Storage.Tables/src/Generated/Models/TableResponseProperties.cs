// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Storage.Tables.Models
{
    /// <summary> The properties for the table response. </summary>
    public partial class TableResponseProperties
    {
        /// <summary> Initializes a new instance of TableResponseProperties. </summary>
        internal TableResponseProperties()
        {
        }

        /// <summary> Initializes a new instance of TableResponseProperties. </summary>
        /// <param name="tableName"> The name of the table. </param>
        /// <param name="odataType"> The odata type of the table. </param>
        /// <param name="odataId"> The id of the table. </param>
        /// <param name="odataEditLink"> The edit link of the table. </param>
        internal TableResponseProperties(string tableName, string odataType, string odataId, string odataEditLink)
        {
            TableName = tableName;
            OdataType = odataType;
            OdataId = odataId;
            OdataEditLink = odataEditLink;
        }

        /// <summary> The name of the table. </summary>
        public string TableName { get; }
        /// <summary> The odata type of the table. </summary>
        public string OdataType { get; }
        /// <summary> The id of the table. </summary>
        public string OdataId { get; }
        /// <summary> The edit link of the table. </summary>
        public string OdataEditLink { get; }
    }
}
