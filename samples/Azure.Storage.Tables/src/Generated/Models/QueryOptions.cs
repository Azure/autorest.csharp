// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Storage.Tables;

namespace Azure.Storage.Tables.Models
{
    /// <summary> Parameter group. </summary>
    public partial class QueryOptions
    {
        /// <summary> Initializes a new instance of QueryOptions. </summary>
        public QueryOptions()
        {
        }

        /// <summary> Specifies the media type for the response. </summary>
        public ResponseFormat? Format { get; set; }
        /// <summary> Maximum number of records to return. </summary>
        public int? Top { get; set; }
        /// <summary> Select expression using OData notation. Limits the columns on each record to just those requested, e.g. "$select=PolicyAssignmentId, ResourceId". </summary>
        public string Select { get; set; }
        /// <summary> OData filter expression. </summary>
        public string Filter { get; set; }
    }
}
