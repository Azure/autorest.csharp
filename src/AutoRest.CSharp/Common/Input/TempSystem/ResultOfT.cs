// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.ComponentModel;

namespace System.ServiceModel.Rest
{
#pragma warning disable SA1649 // File name should match first type name
    public class Result<T> : NullableResult<T>
#pragma warning restore SA1649 // File name should match first type name
    {
        /// <summary>
        /// TBD.
        /// </summary>
        /// <param result=""></param>
        public Result(T value, Result result) : base(value, result)
        {
        }

        /// <summary>
        /// TBD.
        /// </summary>
        public override T Value => base.Value!;

        /// <summary>
        /// TBD.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool HasValue => true;

        /// <summary>
        /// TBD.
        /// </summary>
        /// <returns></returns>
        public override Result GetRawResult() => base.GetRawResult();
    }
}
