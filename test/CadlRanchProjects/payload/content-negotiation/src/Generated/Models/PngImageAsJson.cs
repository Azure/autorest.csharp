// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace Payload.ContentNegotiation.Models
{
    /// <summary> The PngImageAsJson. </summary>
    public partial class PngImageAsJson
    {
        /// <summary> Initializes a new instance of PngImageAsJson. </summary>
        /// <param name="content"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        internal PngImageAsJson(BinaryData content)
        {
            Argument.AssertNotNull(content, nameof(content));

            Content = content;
        }

        /// <summary>
        /// Gets the content
        /// <para>
        /// To assign a byte[] to this property use <see cref="BinaryData.FromBytes(byte[])"/>.
        /// The byte[] will be serialized to a Base64 encoded string.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromBytes(new byte[] { 1, 2, 3 })</term>
        /// <description>Creates a payload of "AQID".</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public BinaryData Content { get; }
    }
}
