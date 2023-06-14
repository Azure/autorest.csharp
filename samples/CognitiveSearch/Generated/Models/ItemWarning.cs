// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Represents an item-level warning. </summary>
    public partial class ItemWarning
    {
        /// <summary> Initializes a new instance of ItemWarning. </summary>
        /// <param name="message"> The message describing the warning that occurred while processing the item. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="message"/> is null. </exception>
        internal ItemWarning(string message)
        {
            Argument.AssertNotNull(message, nameof(message));

            Message = message;
        }

        /// <summary> Initializes a new instance of ItemWarning. </summary>
        /// <param name="key"> The key of the item which generated a warning. </param>
        /// <param name="message"> The message describing the warning that occurred while processing the item. </param>
        /// <param name="name"> The name of the source at which the warning originated. For example, this could refer to a particular skill in the attached skillset. This may not be always available. </param>
        /// <param name="details"> Additional, verbose details about the warning to assist in debugging the indexer. This may not be always available. </param>
        /// <param name="documentationLink"> A link to a troubleshooting guide for these classes of warnings. This may not be always available. </param>
        internal ItemWarning(string key, string message, string name, string details, string documentationLink)
        {
            Key = key;
            Message = message;
            Name = name;
            Details = details;
            DocumentationLink = documentationLink;
        }

        /// <summary> The key of the item which generated a warning. </summary>
        public string Key { get; }
        /// <summary> The message describing the warning that occurred while processing the item. </summary>
        public string Message { get; }
        /// <summary> The name of the source at which the warning originated. For example, this could refer to a particular skill in the attached skillset. This may not be always available. </summary>
        public string Name { get; }
        /// <summary> Additional, verbose details about the warning to assist in debugging the indexer. This may not be always available. </summary>
        public string Details { get; }
        /// <summary> A link to a troubleshooting guide for these classes of warnings. This may not be always available. </summary>
        public string DocumentationLink { get; }
    }
}
