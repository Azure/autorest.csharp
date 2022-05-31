// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace MgmtScopeResource.Models
{
    /// <summary> HTTP message. </summary>
    internal partial class HttpMessage
    {
        /// <summary> Initializes a new instance of <see cref="HttpMessage"/>. </summary>
        internal HttpMessage()
        {
        }

        /// <summary> Initializes a new instance of <see cref="HttpMessage"/>. </summary>
        /// <param name="content"> HTTP message content. </param>
        internal HttpMessage(BinaryData content)
        {
            Content = content;
        }

        /// <summary> HTTP message content. </summary>
        public BinaryData Content { get; }
    }
}
