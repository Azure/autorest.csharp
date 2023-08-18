// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;
using AutoRest.CSharp.AutoRest.Communication;

namespace AutoRest.CSharp.Common.Utilities
{
    internal static class AutoRestLogger
    {
        private static IPluginCommunication? _autoRest = null;
        public static void Initialize(IPluginCommunication autoRest)
        {
            _autoRest = autoRest;
        }

        public static bool IsInitialized => _autoRest != null;

        public static async Task Warning(string message)
        {
            if (!IsInitialized)
                throw new InvalidOperationException("AutoRestLogger.Warning is called before initialized");
            await _autoRest!.Warning(message);
        }

        public static async Task Fatal(string message)
        {
            if (!IsInitialized)
                throw new InvalidOperationException("AutoRestLogger.Fatal is called before initialized");
            await _autoRest!.Fatal(message);
        }
    }
}
