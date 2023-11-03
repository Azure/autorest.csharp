// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace httpInfrastructure.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class HttpInfrastructureModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.MyException"/>. </summary>
        /// <param name="statusCode"></param>
        /// <returns> A new <see cref="Models.MyException"/> instance for mocking. </returns>
        public static MyException MyException(string statusCode = null)
        {
            return new MyException(statusCode, new Dictionary<string, BinaryData>());
        }

        /// <summary> Initializes a new instance of <see cref="Models.B"/>. </summary>
        /// <param name="statusCode"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="textStatusCode"></param>
        /// <returns> A new <see cref="Models.B"/> instance for mocking. </returns>
        public static B B(string statusCode = null, IDictionary<string, BinaryData> serializedAdditionalRawData = null, string textStatusCode = null)
        {
            serializedAdditionalRawData ??= new Dictionary<string, BinaryData>();

            return new B(statusCode, serializedAdditionalRawData, textStatusCode);
        }

        /// <summary> Initializes a new instance of <see cref="Models.C"/>. </summary>
        /// <param name="httpCode"></param>
        /// <returns> A new <see cref="Models.C"/> instance for mocking. </returns>
        public static C C(string httpCode = null)
        {
            return new C(httpCode, new Dictionary<string, BinaryData>());
        }

        /// <summary> Initializes a new instance of <see cref="Models.D"/>. </summary>
        /// <param name="httpStatusCode"></param>
        /// <returns> A new <see cref="Models.D"/> instance for mocking. </returns>
        public static D D(string httpStatusCode = null)
        {
            return new D(httpStatusCode, new Dictionary<string, BinaryData>());
        }
    }
}
