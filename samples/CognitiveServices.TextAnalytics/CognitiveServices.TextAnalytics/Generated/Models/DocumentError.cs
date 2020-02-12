// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace CognitiveServices.TextAnalytics.Models
{
    /// <summary> The DocumentError. </summary>
    public partial class DocumentError
    {
        /// <summary> Document Id. </summary>
        public string Id { get; set; }
        public TextAnalyticsError Error { get; set; } = new TextAnalyticsError();
    }
}
