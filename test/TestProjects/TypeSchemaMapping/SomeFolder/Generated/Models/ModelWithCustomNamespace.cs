// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Very.Custom.Namespace.From.Swagger
{
    /// <summary> The ModelWithCustomNamespace. </summary>
    internal partial class ModelWithCustomNamespace
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::Very.Custom.Namespace.From.Swagger.ModelWithCustomNamespace
        ///
        /// </summary>
        internal ModelWithCustomNamespace()
        {
        }

        /// <summary>
        /// Initializes a new instance of global::Very.Custom.Namespace.From.Swagger.ModelWithCustomNamespace
        ///
        /// </summary>
        /// <param name="modelProperty"> . </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal ModelWithCustomNamespace(string modelProperty, Dictionary<string, BinaryData> rawData)
        {
            ModelProperty = modelProperty;
            _rawData = rawData;
        }

        /// <summary> . </summary>
        public string ModelProperty { get; }
    }
}
