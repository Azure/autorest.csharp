﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

#nullable disable

namespace Azure.Core
{
    /// <summary>
    ///  Provides a container for content encoded using multipart/form-data MIME type.
    /// </summary>
    internal class MultipartFormDataContent : MultipartContent
    {
        #region Fields

        private const string FormData = "form-data";

        #endregion Fields

        #region Construction

        /// <summary>
        ///  Initializes a new instance of the <see cref="MultipartFormDataContent"/> class.
        /// </summary>
        public MultipartFormDataContent() : base(FormData)
        { }

        /// <summary>
        ///  Initializes a new instance of the <see cref="MultipartFormDataContent"/> class.
        /// </summary>
        /// <param name="boundary">The boundary string for the multipart form data content.</param>
        public MultipartFormDataContent(string boundary) : base(FormData, boundary)
        { }

        #endregion Construction

        /// <summary>
        ///  Add HTTP content to a collection of RequestContent objects that
        ///  get serialized to multipart/form-data MIME type.
        /// </summary>
        /// <param name="content">The Request content to add to the collection.</param>
        public override void Add(RequestContent content)
        {
            if (content is null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            AddInternal(content, null, null, null);
        }

        /// <summary>
        ///  Add HTTP content to a collection of RequestContent objects that
        ///  get serialized to multipart/form-data MIME type.
        /// </summary>
        /// <param name="content">The Request content to add to the collection.</param>
        /// <param name="headers">The headers to add to the collection.</param>
        public override void Add(RequestContent content, Dictionary<string, string> headers)
        {
            if (content is null)
            {
                throw new ArgumentNullException(nameof(content));
            }
            if (headers is null)
            {
                throw new ArgumentNullException(nameof(headers));
            }

            AddInternal(content, headers, null, null);
        }

        /// <summary>
        ///  Add HTTP content to a collection of RequestContent objects that
        ///  get serialized to multipart/form-data MIME type.
        /// </summary>
        /// <param name="content">The Request content to add to the collection.</param>
        /// <param name="name">The name for the request content to add.</param>
        /// <param name="headers">The headers to add to the collection.</param>
        public void Add(RequestContent content, string name, Dictionary<string, string> headers)
        {
            if (content is null)
            {
                throw new ArgumentNullException(nameof(content));
            }
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Value cannot be empty or contain only white-space characters.", nameof(name));
            }

            AddInternal(content, headers, name, null);
        }

        /// <summary>
        ///  Add HTTP content to a collection of RequestContent objects that
        ///  get serialized to multipart/form-data MIME type.
        /// </summary>
        /// <param name="content">The Request content to add to the collection.</param>
        /// <param name="name">The name for the request content to add.</param>
        /// <param name="fileName">The file name for the request content to add to the collection.</param>
        /// <param name="headers">The headers to add to the collection.</param>
        public void Add(RequestContent content, string name, string fileName, Dictionary<string, string> headers)
        {
            if (content is null)
            {
                throw new ArgumentNullException(nameof(content));
            }
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Value cannot be empty or contain only white-space characters.", nameof(name));
            }
            if (fileName is null)
            {
                throw new ArgumentNullException(nameof(fileName));
            }
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException("Value cannot be empty or contain only white-space characters.", nameof(fileName));
            }

            AddInternal(content, headers, name, fileName);
        }

        private void AddInternal(RequestContent content, Dictionary<string, string> headers, string name, string fileName)
        {
            if (headers == null)
            {
                headers = new Dictionary<string, string>();
            }

            if (!headers.ContainsKey("Content-Disposition"))
            {
                var value = FormData;

                if (name != null)
                {
                    value = value + "; name=" + name;
                }
                if (fileName != null)
                {
                    value = value + "; filename=" + fileName;
                }

                headers.Add("Content-Disposition", value);
            }

            base.Add(content, headers);
        }
    }
}
