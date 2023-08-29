// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Pagination.Models
{
    /// <summary> Text Blocklist. </summary>
    public partial class TextBlocklist
    {
        private Dictionary<string, BinaryData> _rawData;

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
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal TextBlocklist(string blocklistName, string description, Dictionary<string, BinaryData> rawData)
        {
            BlocklistName = blocklistName;
            Description = description;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="TextBlocklist"/> for deserialization. </summary>
        internal TextBlocklist()
        {
        }

        /// <summary> Text blocklist name. Only supports the following characters: 0-9  A-Z  a-z  -  .  _  ~. </summary>
        public string BlocklistName { get; }
        /// <summary> Text blocklist description. </summary>
        public string Description { get; }
    }
}
