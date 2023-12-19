// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace System.ClientModel.Tests.Client.ModelReaderWriterTests.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class SystemClientModelTestsClientModelReaderWriterTestsModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.ModelWithPersistableOnly"/>. </summary>
        /// <param name="name"> The name. </param>
        /// <param name="fields"> The fields property. </param>
        /// <param name="nullProperty"> The nullable property. </param>
        /// <param name="keyValuePairs"> The key value pairs property. </param>
        /// <param name="xProperty"> The x property. </param>
        /// <returns> A new <see cref="Models.ModelWithPersistableOnly"/> instance for mocking. </returns>
        public static ModelWithPersistableOnly ModelWithPersistableOnly(string name = null, IEnumerable<string> fields = null, int? nullProperty = null, IDictionary<string, string> keyValuePairs = null, int xProperty = default)
        {
            fields ??= new List<string>();
            keyValuePairs ??= new Dictionary<string, string>();

            return new ModelWithPersistableOnly(name, fields?.ToList(), nullProperty, keyValuePairs, xProperty, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.ModelX"/>. </summary>
        /// <param name="name"> The name property. </param>
        /// <param name="fields"> Optional list. </param>
        /// <param name="nullProperty"> Nullable integer. </param>
        /// <param name="keyValuePairs"> Optional dictionary. </param>
        /// <param name="xProperty"> The XProperty property. </param>
        /// <returns> A new <see cref="Models.ModelX"/> instance for mocking. </returns>
        public static ModelX ModelX(string name = null, IEnumerable<string> fields = null, int? nullProperty = null, IDictionary<string, string> keyValuePairs = null, int xProperty = default)
        {
            fields ??= new List<string>();
            keyValuePairs ??= new Dictionary<string, string>();

            return new ModelX("X", name, serializedAdditionalRawData: null, fields?.ToList(), nullProperty, keyValuePairs, xProperty);
        }

        /// <summary> Initializes a new instance of <see cref="Models.ModelY"/>. </summary>
        /// <param name="name"> The name property. </param>
        /// <param name="yProperty"> The YProperty property. </param>
        /// <returns> A new <see cref="Models.ModelY"/> instance for mocking. </returns>
        public static ModelY ModelY(string name = null, string yProperty = null)
        {
            return new ModelY("Y", name, serializedAdditionalRawData: null, yProperty);
        }
    }
}
