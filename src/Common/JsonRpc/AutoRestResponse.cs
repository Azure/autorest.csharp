using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.Common.Utilities;

namespace AutoRest.CSharp.V3.Common.JsonRpc
{
    public interface IAutoRestResponse
    {
        bool SetCompleted(string result);
        bool SetCancelled();
    }

    internal class AutoRestResponse : TaskCompletionSource<string>, IAutoRestResponse
    {
        public bool SetCompleted(string result)
        {
            //T value;
            //static bool TrueLikeValue(object obj) => obj != null && !0.Equals(obj) && !false.Equals(obj) && !"".Equals(obj);
            //if (typeof(T) == typeof(bool))
            //{
            //    var obj = result.ToObject<object>();
            //    value = (T)(object)(TrueLikeValue(obj));
            //}
            //else if (typeof(T) == typeof(bool?))
            //{
            //    var obj = result.ToObject<object>();
            //    value = obj == null ? (T)(object)(null) : (T)(object)(TrueLikeValue(obj));
            //}
            //else
            //{
            //    value = result.ToObject<T>();
            //}
            return TrySetResult(result);
        }

        public bool SetCancelled()
        {
            return TrySetCanceled();
        }
    }
}
