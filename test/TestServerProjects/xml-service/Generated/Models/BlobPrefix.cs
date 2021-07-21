// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace xml_service.Models
{
    /// <summary> The BlobPrefix. </summary>
    public partial class BlobPrefix
    {
        /// <summary> Initializes a new instance of BlobPrefix. </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        internal BlobPrefix(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;
        }

        public string Name { get; }
    }
}
