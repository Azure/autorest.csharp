// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary> Represents an item-level warning. </summary>
    public partial class ItemWarning
    {
        /// <summary> The key of the item which generated a warning. </summary>
        public string Key { get; internal set; }
        /// <summary> The message describing the warning that occurred while processing the item. </summary>
        public string Message { get; internal set; }
        /// <summary> The name of the source at which the warning originated. For example, this could refer to a particular skill in the attached skillset. This may not be always available. </summary>
        public string Name { get; internal set; }
        /// <summary> Additional, verbose details about the warning to assist in debugging the indexer. This may not be always available. </summary>
        public string Details { get; internal set; }
        /// <summary> A link to a troubleshooting guide for these classes of warnings. This may not be always available. </summary>
        public string DocumentationLink { get; internal set; }
    }
}
