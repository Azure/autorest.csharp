// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Azure.Core;

namespace body_formdata.Models
{
    /// <summary> The Paths1P3Stk3FormdataStreamUploadfilesPostRequestbodyContentMultipartFormDataSchema. </summary>
    internal partial class Paths1P3Stk3FormdataStreamUploadfilesPostRequestbodyContentMultipartFormDataSchema
    {
        /// <summary> Initializes a new instance of Paths1P3Stk3FormdataStreamUploadfilesPostRequestbodyContentMultipartFormDataSchema. </summary>
        /// <param name="fileContent"> Files to upload. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fileContent"/> is null. </exception>
        internal Paths1P3Stk3FormdataStreamUploadfilesPostRequestbodyContentMultipartFormDataSchema(IEnumerable<Stream> fileContent)
        {
            Argument.AssertNotNull(fileContent, nameof(fileContent));

            FileContent = fileContent.ToList();
        }

        /// <summary> Files to upload. </summary>
        public IReadOnlyList<Stream> FileContent { get; }
    }
}
