// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using httpInfrastructure.Models;

namespace httpInfrastructure
{
    /// <summary> Model factory for AutoRestHttpInfrastructureTestService read-only models. </summary>
    public static partial class AutoRestHttpInfrastructureTestServiceModelFactory
    {
        /// <summary> Initializes new instance of MyException class. </summary>
        /// <param name="statusCode"> . </param>
        /// <returns> A new <see cref="Models.MyException"/> instance for mocking. </returns>
        public static MyException MyException(string statusCode = default)
        {
            return new MyException(statusCode);
        }

        /// <summary> Initializes new instance of B class. </summary>
        /// <param name="statusCode"> . </param>
        /// <param name="textStatusCode"> . </param>
        /// <returns> A new <see cref="Models.B"/> instance for mocking. </returns>
        public static B B(string statusCode = default, string textStatusCode = default)
        {
            return new B(statusCode, textStatusCode);
        }

        /// <summary> Initializes new instance of C class. </summary>
        /// <param name="httpCode"> . </param>
        /// <returns> A new <see cref="Models.C"/> instance for mocking. </returns>
        public static C C(string httpCode = default)
        {
            return new C(httpCode);
        }

        /// <summary> Initializes new instance of D class. </summary>
        /// <param name="httpStatusCode"> . </param>
        /// <returns> A new <see cref="Models.D"/> instance for mocking. </returns>
        public static D D(string httpStatusCode = default)
        {
            return new D(httpStatusCode);
        }
    }
}
