using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.Common.Utilities;
using Microsoft.Perks.JsonRPC;

namespace AutoRest.CSharp.V3.Common.JsonRpc
{
    internal delegate Task<bool> ProcessMethod(Plugins.AutoRestInterface autoRest);

    internal static class IncomingMessages
    {
        //_dispatch = new Dictionary<string, DispatchMethod>
        //{
        //    { "GetPluginNames", async je => pluginNames.ToJsonArray() },
        //    { "Process", async je => await RunProcessor(je, processMethod) },
        //    { "Shutdown", async je => { Stop(); return null; } }
        //};

        public static string GetPluginNames(this IncomingRequest _, params string[] pluginNames) => pluginNames.ToJsonArray();

        //public static string Process(this IncomingRequest request, ProcessMethod processMethod)
        //{
        //    var parameters = request.Params.ToStringArray();
        //    return (await processMethod(this, elements[0], elements[1])).ToJsonBool();
        //}

        public static string Shutdown(this IncomingRequest _, CancellationTokenSource tokenSource)
        {
            tokenSource.Cancel();
            return null;
        }

        public static T ParseResponseType<T>(string jsonResponse)
        {
            var element = jsonResponse.Parse();
            return typeof(T) switch
            {
                var t when t == typeof(string) => (T)(object)element.ToStringValue(),
                var t when t == typeof(string[]) => (T)(object)element.ToStringArray(),
                var t when t == typeof(int?) => (T)(object)element.ToNumber(),
                var t when t == typeof(bool?) => (T)(object)element.ToBoolean(),
                var t when t == typeof(JsonElement?) => (T)(object)element,
                _ => throw new NotSupportedException($"Type {typeof(T)} is not a supported response type.")
            };
        }
    }

    internal class IncomingRequest
    {
        public string JsonRpc { get; set; }
        public string Method { get; set; }
        public JsonElement? Params { get; set; }
        public string Id { get; set; }
    }

    internal class IncomingResponse
    {
        public string JsonRpc { get; set; }
        public string Result { get; set; }
        public string Id { get; set; }
    }
}
