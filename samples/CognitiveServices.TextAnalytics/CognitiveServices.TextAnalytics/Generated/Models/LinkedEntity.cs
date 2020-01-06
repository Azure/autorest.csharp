// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace CognitiveServices.TextAnalytics.Models.VV30Preview1
{
    /// <summary> MISSING·SCHEMA-DESCRIPTION-OBJECTSCHEMA. </summary>
    public partial class LinkedEntity
    {
        /// <summary> Entity Linking formal name. </summary>
        public string Name { get; set; }
        /// <summary> List of instances this entity appears in the text. </summary>
        public ICollection<Match> Matches { get; set; } = new List<Match>();
        /// <summary> Language used in the data source. </summary>
        public string Language { get; set; }
        /// <summary> Unique identifier of the recognized entity from the data source. </summary>
        public string? Id { get; set; }
        /// <summary> URL for the entity&apos;s page from the data source. </summary>
        public string Url { get; set; }
        /// <summary> Data source used to extract entity linking, such as Wiki/Bing etc. </summary>
        public string DataSource { get; set; }
    }
}
