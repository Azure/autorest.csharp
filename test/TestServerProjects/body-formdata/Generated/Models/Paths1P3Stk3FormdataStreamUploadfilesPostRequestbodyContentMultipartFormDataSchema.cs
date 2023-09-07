// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

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
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="Paths1P3Stk3FormdataStreamUploadfilesPostRequestbodyContentMultipartFormDataSchema"/>. </summary>
        /// <param name="fileContent"> Files to upload. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fileContent"/> is null. </exception>
        internal Paths1P3Stk3FormdataStreamUploadfilesPostRequestbodyContentMultipartFormDataSchema(IEnumerable<Stream> fileContent)
        {
            Argument.AssertNotNull(fileContent, nameof(fileContent));

            FileContent = fileContent.ToList();
        }

        /// <summary> Initializes a new instance of <see cref="Paths1P3Stk3FormdataStreamUploadfilesPostRequestbodyContentMultipartFormDataSchema"/>. </summary>
        /// <param name="fileContent"> Files to upload. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal Paths1P3Stk3FormdataStreamUploadfilesPostRequestbodyContentMultipartFormDataSchema(IReadOnlyList<Stream> fileContent, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            FileContent = fileContent;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="Paths1P3Stk3FormdataStreamUploadfilesPostRequestbodyContentMultipartFormDataSchema"/> for deserialization. </summary>
        internal Paths1P3Stk3FormdataStreamUploadfilesPostRequestbodyContentMultipartFormDataSchema()
        {
        }

        /// <summary> Files to upload. </summary>
        public IReadOnlyList<Stream> FileContent { get; }
    }
}
