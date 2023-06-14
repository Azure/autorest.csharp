// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Pagination.Models
{
    /// <summary> Item in TextBlocklist. </summary>
    public partial class TextBlockItem
    {
        /// <summary> Initializes a new instance of TextBlockItem. </summary>
        /// <param name="blockItemId"> Block Item Id. It will be uuid. </param>
        /// <param name="text"> Block item content. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="blockItemId"/> or <paramref name="text"/> is null. </exception>
        internal TextBlockItem(string blockItemId, string text)
        {
            Argument.AssertNotNull(blockItemId, nameof(blockItemId));
            Argument.AssertNotNull(text, nameof(text));

            BlockItemId = blockItemId;
            Text = text;
        }

        /// <summary> Initializes a new instance of TextBlockItem. </summary>
        /// <param name="blockItemId"> Block Item Id. It will be uuid. </param>
        /// <param name="description"> Block item description. </param>
        /// <param name="text"> Block item content. </param>
        internal TextBlockItem(string blockItemId, string description, string text)
        {
            BlockItemId = blockItemId;
            Description = description;
            Text = text;
        }

        /// <summary> Block Item Id. It will be uuid. </summary>
        public string BlockItemId { get; }
        /// <summary> Block item description. </summary>
        public string Description { get; }
        /// <summary> Block item content. </summary>
        public string Text { get; }
    }
}
