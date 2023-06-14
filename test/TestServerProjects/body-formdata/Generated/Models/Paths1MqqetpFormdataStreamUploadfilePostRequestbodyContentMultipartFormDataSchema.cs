// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.IO;
using Azure.Core;

namespace body_formdata.Models
{
    /// <summary> The Paths1MqqetpFormdataStreamUploadfilePostRequestbodyContentMultipartFormDataSchema. </summary>
    internal partial class Paths1MqqetpFormdataStreamUploadfilePostRequestbodyContentMultipartFormDataSchema
    {
        /// <summary> Initializes a new instance of Paths1MqqetpFormdataStreamUploadfilePostRequestbodyContentMultipartFormDataSchema. </summary>
        /// <param name="fileContent"> File to upload. </param>
        /// <param name="fileName"> File name to upload. Name has to be spelled exactly as written here. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fileContent"/> or <paramref name="fileName"/> is null. </exception>
        internal Paths1MqqetpFormdataStreamUploadfilePostRequestbodyContentMultipartFormDataSchema(Stream fileContent, string fileName)
        {
            Argument.AssertNotNull(fileContent, nameof(fileContent));
            Argument.AssertNotNull(fileName, nameof(fileName));

            FileContent = fileContent;
            FileName = fileName;
        }

        /// <summary> File to upload. </summary>
        public Stream FileContent { get; }
        /// <summary> File name to upload. Name has to be spelled exactly as written here. </summary>
        public string FileName { get; }
    }
}
