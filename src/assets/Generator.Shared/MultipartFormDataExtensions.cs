// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.ClientModel;
using System.Collections.Generic;
using Azure.Core;

namespace System.ClientModel.Primitives
{
    internal static class MultipartFormDataExtensions
    {
        public static IReadOnlyList<FormDataItem> ParseToFormData(this MultipartFormData multipart)
        {
            List<FormDataItem> results = new List<FormDataItem>();
            foreach (var part in multipart.ContentParts)
            {
                var contentDisposition = part.Headers["Content-Disposition"];
                var name = contentDisposition.Substring(contentDisposition.IndexOf("name=") + 5);
                name = name.Substring(0, name.IndexOf(";"));
                var fileName = contentDisposition.IndexOf("filename=") > 0 ? contentDisposition.Substring(contentDisposition.IndexOf("filename=") + 9) : null;
                if (fileName != null)
                {
                    fileName = fileName.Substring(0, fileName.IndexOf(";"));
                }
                var contentType = part.Headers.ContainsKey("Content-Type") ? part.Headers["Content-Type"] : null;
                var content = part.Content;
                var item = new FormDataItem(name, content)
                {
                    FileName = fileName,
                    ContentType = contentType,
                };
                results.Add(item);
            }
            return results;
        }

        public static RequestContent ToRequestContent(this MultipartFormData multipart)
        {
            //return RequestContent.Create(ModelReaderWriter.Write(multipart, new ModelReaderWriterOptions("MPFD")));
            return RequestContent.Create(multipart, new ModelReaderWriterOptions("MPFD"));
        }
    }
}
