using System;
using System.Collections.Generic;

namespace AutoRest.CSharp.V3.Common.JsonRpc
{
    internal static class AutoRestRequests
    {
        //public const string ReadFile =     @"{""jsonrpc"":""2.0"",""method"":""ReadFile"",""params"":""[{1},{2}]"",""id"":""{0}""}";
        //public const string GetValue =     @"{""jsonrpc"":""2.0"",""method"":""GetValue"",""params"":""[{1},{2}]"",""id"":""{0}""}";
        //public const string ListInputs =   @"{""jsonrpc"":""2.0"",""method"":""ListInputs"",""params"":""[{1},{2}]"",""id"":""{0}""}";
        //public const string ProtectFiles = @"{""jsonrpc"":""2.0"",""method"":""ProtectFiles"",""params"":""[{1},{2}]"",""id"":""{0}""}";
        //public const string Message =      @"{""jsonrpc"":""2.0"",""method"":""Message"",""params"":""[{1},{2}]"",""id"":""{0}""}";
        //public ReadFile = new RequestType2<string, string, string, Error, void>('ReadFile');
        //public GetValue = new RequestType2<string, string, any, Error, void>('GetValue');
        //public ListInputs = new RequestType2<string, string | undefined, Array<string>, Error, void>('ListInputs');
        //public ProtectFiles = new NotificationType2<string, string, void>('ProtectFiles');
        //public WriteFile = new NotificationType4<string, string, string, Array<Mapping> | RawSourceMap | undefined, void>('WriteFile');
        //public Message = new NotificationType2<string, Message, void>('Message');

        public static string ToLiteral(this string input) =>
            !String.IsNullOrEmpty(input)
                ? input
                    .Replace("\\", "\\\\") // backslashes
                    .Replace("\"", "\\\"") // quotes
                    .Replace("\0", "\\0") // nulls
                    .Replace("\a", "\\a") // alert
                    .Replace("\b", "\\b") // backspace
                    .Replace("\f", "\\f") // form feed
                    .Replace("\n", "\\n") // newline
                    .Replace("\r", "\\r") // return
                    .Replace("\t", "\\t") // tab
                    .Replace("\v", "\\v") // vertical tab
                : (input == null ? "null" : "");

        //private const string BasicRequestFormat1 = @"{{""jsonrpc"":""2.0"",""method"":""{1}"",""params"":""[{2}]"",""id"":""{0}""}}";
        private const string BasicRequestFormat = @"{{""jsonrpc"":""2.0"",""method"":""{1}"",""params"":[""{2}"",{3}],""id"":""{0}""}}";
        private const string BasicNotificationFormat = @"{{""jsonrpc"":""2.0"",""method"":""{0}"",""params"":[""{1}"",{2}]}}";

        public static string ReadFile(string requestId, string sessionId, string filename) => String.Format(BasicRequestFormat, requestId, nameof(ReadFile), sessionId, "\"" + filename.ToLiteral() + "\"");
        public static string GetValue(string requestId, string sessionId, string key) => String.Format(BasicRequestFormat, requestId, nameof(GetValue), sessionId, "\"" + key.ToLiteral() + "\"");
        //public static string ListInputs(string requestId, string sessionId, string artifactType = null)
        //{
        //    if (artifactType == null)
        //    {
        //        return String.Format(BasicRequestFormat1, requestId, nameof(ListInputs), sessionId);
        //    }
        //    return String.Format(BasicRequestFormat, requestId, nameof(ListInputs), sessionId, artifactType.ToLiteral());
        //}
        public static string ListInputs(string requestId, string sessionId, string artifactType = null) => String.Format(BasicRequestFormat, requestId, nameof(ListInputs), sessionId, artifactType != null ? "\"" + artifactType.ToLiteral() + "\"" : "null");
        public static string ProtectFiles(string requestId, string sessionId, string path) => String.Format(BasicRequestFormat, requestId, nameof(ProtectFiles), sessionId, "\"" + path.ToLiteral() + "\"");
        public static string Message(string sessionId, IMessage message) => String.Format(BasicNotificationFormat, nameof(Message), sessionId, message);

        // Custom Messages
        public static string WriteFile(string sessionId, string filename, string content, string artifactType, Mapping[] sourceMap)
        {
            var artifact = new ArtifactMapping { Content = content, SourceMap = sourceMap, Type = artifactType, Uri = filename };
            var message = new ArtifactMessage { Channel = Channel.File, Details = artifact, Text = String.Empty };
            return Message(sessionId, message);
        }
        public static string WriteFile(string sessionId, string filename, string content, string artifactType, RawSourceMap sourceMap = null)
        {
            var artifact = new ArtifactRaw { Content = content, SourceMap = sourceMap, Type = artifactType, Uri = filename };
            var message = new ArtifactMessage { Channel = Channel.File, Details = artifact, Text = String.Empty };
            return Message(sessionId, message);
        }
    }
}
