﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using AutoRest.CSharp.V3.JsonRpc.MessageModels;
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
}
