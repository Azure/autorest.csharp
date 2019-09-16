// --------------------------------------------------------------------------------------------------------------------
// <copyright>
//   Copyright (c) Microsoft. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Microsoft.Perks.JsonRPC
{
    public interface ICallerResponse
    {
        bool SetCompleted(JToken result);
        bool SetCancelled();
    }

    public class CallerResponse<T> : TaskCompletionSource<T>, ICallerResponse
    {
        public string Id { get; }

        public CallerResponse(string id)
        {
            Id = id;
        }

        public bool SetCompleted(JToken result)
        {
            T value;
            Func<object, bool> trueLikeValue = obj => obj != null && !0.Equals(obj) && !false.Equals(obj) && !"".Equals(obj);
            if (typeof(T) == typeof(bool))
            {
                var obj = result.ToObject<object>();
                value = (T)(object)(trueLikeValue(obj));
            }
            else if (typeof(T) == typeof(bool?))
            {
                var obj = result.ToObject<object>();
                value = obj == null ? (T)(object)(null) : (T)(object)(trueLikeValue(obj));
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