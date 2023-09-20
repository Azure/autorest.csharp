// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.ComponentModel;

namespace System.ServiceModel.Rest
{
#pragma warning disable SA1649 // File name should match first type name
    public class NullableResult<T>
#pragma warning restore SA1649 // File name should match first type name
    {
        private T? _value;
        private Result _result;

        /// <summary>
        /// TBD.
        /// </summary>
        /// <param result=""></param>
        public NullableResult(T? value, Result result)
        {
            _value = value;
            _result = result;
        }

        /// <summary>
        /// TBD.
        /// </summary>
        public virtual T? Value => _value;

        /// <summary>
        /// TBD.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual bool HasValue => _value != null;

        /// <summary>
        /// TBD.
        /// </summary>
        /// <returns></returns>
        public virtual Result GetRawResult() => _result;
    }
}
