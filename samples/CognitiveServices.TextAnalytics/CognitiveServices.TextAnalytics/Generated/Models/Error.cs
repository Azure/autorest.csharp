// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace CognitiveServices.TextAnalytics.Models.VV30Preview1
{
    /// <summary> MISSING·SCHEMA-DESCRIPTION-OBJECTSCHEMA. </summary>
    public partial class Error
    {
        /// <summary> Error code. </summary>
        public ErrorCode Code { get; set; }
        /// <summary> Error message. </summary>
        public string Message { get; set; }
        /// <summary> Error target. </summary>
        public string? Target { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-OBJECTSCHEMA. </summary>
        public InnerError? Innererror { get; set; }
        /// <summary> Details about specific errors that led to this reported error. </summary>
        public ICollection<Error>? Details { get; set; }
    }
}
