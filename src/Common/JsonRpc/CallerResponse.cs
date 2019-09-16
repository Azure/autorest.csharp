// --------------------------------------------------------------------------------------------------------------------
// <copyright>
//   Copyright (c) Microsoft. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

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
        private string Id { get; }

        public CallerResponse(string id)
        {
            Id = id;
        }

        public bool SetCompleted(JToken result)
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