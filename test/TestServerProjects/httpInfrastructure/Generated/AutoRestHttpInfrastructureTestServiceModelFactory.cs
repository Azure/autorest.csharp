// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace httpInfrastructure.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class AutoRestHttpInfrastructureTestServiceModelFactory
    {
        /// <summary> Initializes a new instance of MyException. </summary>
        /// <param name="statusCode"></param>
        /// <returns> A new <see cref="Models.MyException"/> instance for mocking. </returns>
        public static MyException MyException(string statusCode = null)
        {
            return new MyException(statusCode);
        }

        /// <summary> Initializes a new instance of B. </summary>
        /// <param name="statusCode"></param>
        /// <param name="textStatusCode"></param>
        /// <returns> A new <see cref="Models.B"/> instance for mocking. </returns>
        public static B B(string statusCode = null, string textStatusCode = null)
        {
            return new B(statusCode, textStatusCode);
        }

        /// <summary> Initializes a new instance of C. </summary>
        /// <param name="httpCode"></param>
        /// <returns> A new <see cref="Models.C"/> instance for mocking. </returns>
        public static C C(string httpCode = null)
        {
            return new C(httpCode);
        }

        /// <summary> Initializes a new instance of D. </summary>
        /// <param name="httpStatusCode"></param>
        /// <returns> A new <see cref="Models.D"/> instance for mocking. </returns>
        public static D D(string httpStatusCode = null)
        {
            return new D(httpStatusCode);
        }
    }
}
