// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Pagination.Models
{
    /// <summary> Text Blocklist. </summary>
    public partial class TextBlocklist
    {
        /// <summary> Initializes a new instance of TextBlocklist. </summary>
        /// <param name="blocklistName"> Text blocklist name. Only supports the following characters: 0-9  A-Z  a-z  -  .  _  ~. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="blocklistName"/> is null. </exception>
        internal TextBlocklist(string blocklistName)
        {
            Argument.AssertNotNull(blocklistName, nameof(blocklistName));

            BlocklistName = blocklistName;
        }

        /// <summary> Initializes a new instance of TextBlocklist. </summary>
        /// <param name="blocklistName"> Text blocklist name. Only supports the following characters: 0-9  A-Z  a-z  -  .  _  ~. </param>
        /// <param name="description"> Text blocklist description. </param>
        internal TextBlocklist(string blocklistName, string description)
        {
            BlocklistName = blocklistName;
            Description = description;
        }

        /// <summary> Text blocklist name. Only supports the following characters: 0-9  A-Z  a-z  -  .  _  ~. </summary>
        public string BlocklistName { get; }
        /// <summary> Text blocklist description. </summary>
        public string Description { get; }
    }
}
