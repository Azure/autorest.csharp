using System;
using System.Text.Json;
using System.Threading;
using AutoRest.CSharp.V3.Utilities;

namespace AutoRest.CSharp.V3.JsonRpc.Messaging
{
    internal delegate bool ProcessAction(Connection connection, string pluginName, string sessionId);

    internal static class IncomingMessages
    {
        public static string GetPluginNames(this IncomingRequest _, params string[] pluginNames) => pluginNames.ToJsonArray();

        public static string Process(this IncomingRequest request, Connection connection, ProcessAction processAction)
        {
            var parameters = request.Params.ToStringArray();
            var (pluginName, sessionId) = (parameters![0], parameters![1]);
            return processAction(connection, pluginName, sessionId).ToJsonBool();
        }

        public static string Shutdown(this IncomingRequest _, CancellationTokenSource tokenSource)
        {
            tokenSource.Cancel();
            return String.Empty;
        }
    }

    internal class IncomingRequest
    {
        public string JsonRpc { get; } = "2.0";
        public string? Method { get; set; }
        public JsonElement? Params { get; set; }
        public string? Id { get; set; }
    }

    internal class IncomingResponse
    {
        public string JsonRpc { get; } = "2.0";
        public string? Result { get; set; }
        public string? Id { get; set; }
    }
}
