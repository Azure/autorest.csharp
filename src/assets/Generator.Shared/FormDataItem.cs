// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

namespace System.ClientModel.Primitives
{
    /// <summary>
    /// A form data item in multipart/form-data format.
    /// </summary>
    internal class FormDataItem
    {
        public FormDataItem(string name, BinaryContent content)
        {
            Name = name;
            Content = content;
        }
        public string Name { get; set; }
        public string? FileName { get; set; }
        public string? ContentType { get; set; }
        public BinaryContent Content { get; set; }
    }
}
