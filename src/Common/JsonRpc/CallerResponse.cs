// --------------------------------------------------------------------------------------------------------------------
// <copyright>
//   Copyright (c) Microsoft. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Text.Json;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.Common.Utilities;

namespace Microsoft.Perks.JsonRPC
{
    public interface ICallerResponse
    {
        bool SetCompleted(JsonElement result);
        bool SetCancelled();
    }

    public class CallerResponse<T> : TaskCompletionSource<T>, ICallerResponse
    {
        public string Id { get; }

        public CallerResponse(string id)
        {
            Id = id;
        }

        public bool SetCompleted(JsonElement result)
        {
            T value;
            static bool TrueLikeValue(object obj) => obj != null && !0.Equals(obj) && !false.Equals(obj) && !"".Equals(obj);
            if (typeof(T) == typeof(bool))
            {
                var obj = result.ToObject<object>();
                value = (T)(object)(TrueLikeValue(obj));
            }
            else if (typeof(T) == typeof(bool?))
            {
                var obj = result.ToObject<object>();
                value = obj == null ? (T)(object)(null) : (T)(object)(TrueLikeValue(obj));
            }
            else
            {
                value = result.ToObject<T>();
            }
            return TrySetResult(value);
        }

        public bool SetCancelled()
        {
            return TrySetCanceled();
        }
    }
}