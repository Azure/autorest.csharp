using System;
using Azure.Core;

namespace AutoRest.CSharp.V3.Utilities
{
    internal static class AzureCoreExtensions
    {
        public static string ToRequestMethodName(this RequestMethod method) => method.ToString() switch
        {
            "GET" => nameof(RequestMethod.Get),
            "POST" => nameof(RequestMethod.Post),
            "PUT" => nameof(RequestMethod.Put),
            "PATCH" => nameof(RequestMethod.Patch),
            "DELETE" => nameof(RequestMethod.Delete),
            "HEAD" => nameof(RequestMethod.Head),
            _ => String.Empty
        };
    }
}
