
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.CodeDom.Compiler;

namespace Microsoft.Perks.JsonRPC
{
    public static class ProtocolExtensions {
        ///<Summary>
        /// Ensures a given string is safe to transport in JSON
        ///</Summary>
        private static string ToLiteral(string input)
        {
            return String.IsNullOrEmpty(input)
                ? input
                : input.
                    Replace("\\", "\\\\"). // backslashes
                    Replace("\"", "\\\""). // quotes
                    Replace("\0", "\\0").  // nulls
                    Replace("\a", "\\a").  // alert
                    Replace("\b", "\\b").  // backspace
                    Replace("\f", "\\f").  // form feed
                    Replace("\n", "\\n").  // newline
                    Replace("\r", "\\r").  // return
                    Replace("\t", "\\t").  // tab
                    Replace("\v", "\\v");  // vertical tab
        }

        //https://stackoverflow.com/a/324812/294804
        //private static string ToLiteral(string input)
        //{
        //    using var writer = new StringWriter();
        //    using var provider = CodeDomProvider.CreateProvider("CSharp");
        //    provider.GenerateCodeFromExpression(new CodePrimitiveExpression(input), writer, null);
        //    return writer.ToString();
        //}

        ///<Summary>
        /// Converts the value to a Primitive and reutrns the JSON Primitive equivalent
        ///</Summary>
        private static string Quote(this object value) =>
            value == null
                ? "null"
                : value.GetType().IsPrimitive
                    ? value.ToString().ToLower()
                    : $"\"{ToLiteral(value.ToString())}\"";
        
        ///<Summary>
        /// Converts the value to an object/string/primitive representation 
        ///</Summary>
        private static string ToJsonValue( this object value ) =>
          value == null || value is string || value.GetType().IsPrimitive ?
            Quote(value) :
            JsonSerializer.Serialize(value);

        ///<Summary>
        /// Creates a comma-separated Json Object notation { ... } from the array of strings
        ///</Summary>
        private static string JsonObject(params string[] members ) => $"{{{members.Aggregate((c,e) =>$"{c},{e}")}}}";

        ///<Summary>
        /// creates a comma-separated Json Array notation [ ... ] from the array of values
        ///</Summary>
        private static string JsonArray(this IEnumerable<object> values) => $"[{values.Select(ToJsonValue).Aggregate((c,e) => $"{c},{e}")}]";

        ///<Summary>
        /// Returns a quoted string and a serialized value for a key/value pair {"key": "value" }
        ///</Summary>
        private static string MemberValue(this string key, object value) => MemberObject(key,ToJsonValue(value));

        ///<Summary>
        /// Returns a quotes string and the value for a key/value pair (rawValue must be JSON encoded already)
        ///</Summary>
        private static string MemberObject(this string key, string rawValue) => $"{Quote(key)}:{rawValue}";

        ///<Summary>
        /// Returns the JSON-RPC protocol pair
        ///</Summary>
        private static readonly string Protocol = MemberValue("jsonrpc","2.0");

        ///<Summary>
        /// Formats 'id' member
        ///</Summary>
        private static string Id(this string id) => MemberValue("id",id);

        ///<Summary>
        /// Formats 'result' member
        ///</Summary>
        private static string Result(this string rawValue) => MemberObject("result",rawValue);

        ///<Summary>
        /// Formats 'method' member
        ///</Summary>
        private static string Method(this string value) => MemberValue("method",value);

        ///<Summary>
        /// Formats 'params' member for an array of value
        ///</Summary>
        private static string Params(this IEnumerable<object> values) => Params(values.JsonArray());

        ///<Summary>
        /// Formats a 'params' member for a previously-json-formatted rawContent value
        ///</Summary>
        private static string Params(this string rawContent) =>  $"{Quote("params")}:{rawContent}";

        ///<Summary>
        /// Generates a Response JSON object
        ///</Summary>
        internal static string Response(string id, string result) => JsonObject(Protocol, Id(id), Result(result));

        ///<Summary>
        /// Generates a Notification JSON object (array parameters syntax)
        ///</Summary>
        public static string Notification(string methodName, params object[] values) =>
          values == null || values.Length == 0 ?
            // without any values, this doesn't need parameters
            JsonObject(Protocol, methodName.Method()):

            // with values
            JsonObject(Protocol, methodName.Method(), Params(values));

        ///<Summary>
        /// Generates a Request JSON object (array syntax)
        ///</Summary>
        public static string Request(string id, string methodName, params object[] values) =>
          values == null || values.Length == 0 ?
            // without any values, this doesn't need parameters
            JsonObject(Protocol, methodName.Method(), Id(id)):

            // with values
            JsonObject(Protocol, methodName.Method(), Params(values), Id(id));
    }
}
