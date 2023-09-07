// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Storage.Tables;

namespace Azure.Storage.Tables.Models
{
    /// <summary> Parameter group. </summary>
    public partial class QueryOptions
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="QueryOptions"/>. </summary>
        public QueryOptions()
        {
        }

        /// <summary> Initializes a new instance of <see cref="QueryOptions"/>. </summary>
        /// <param name="format"> Specifies the media type for the response. </param>
        /// <param name="top"> Maximum number of records to return. </param>
        /// <param name="select"> Select expression using OData notation. Limits the columns on each record to just those requested, e.g. "$select=PolicyAssignmentId, ResourceId". </param>
        /// <param name="filter"> OData filter expression. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal QueryOptions(ResponseFormat? format, int? top, string select, string filter, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Format = format;
            Top = top;
            Select = select;
            Filter = filter;
            _serializedAdditionalRawData = serializedAdditionalRawData;
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
