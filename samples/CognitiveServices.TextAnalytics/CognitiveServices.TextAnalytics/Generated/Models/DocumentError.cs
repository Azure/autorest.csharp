// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace CognitiveServices.TextAnalytics.Models
{
    /// <summary> MISSING·SCHEMA-DESCRIPTION-OBJECTSCHEMA. </summary>
    public partial class DocumentError
    {
        /// <summary> Document Id. </summary>
        public string Id { get; set; }
        /// <summary> Document Error. </summary>
        public DocumentErrorError Error { get; set; } = new DocumentErrorError();
    }
}
