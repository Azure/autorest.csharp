// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Types;
using Azure.ResourceManager;

namespace AutoRest.CSharp.Mgmt.AutoRest
{
    internal static class MgmtContext
    {
        private static BuildContext<MgmtOutputLibrary>? _context;
        public static BuildContext<MgmtOutputLibrary> Context => _context ?? throw new InvalidOperationException("MgmtContext was not initialized.");

        public static MgmtOutputLibrary Library => Context.Library;

        public static CodeModel CodeModel => Context.CodeModel;

        public static bool IsInitialized => _context is not null;

        private static string? _rpName;
        public static string RpName => _rpName ??= Context.DefaultNamespace.Equals(typeof(ArmClient).Namespace) ? "Arm" : Context.DefaultNamespace.Split('.').Last();

        public static void Initialize(BuildContext<MgmtOutputLibrary> context)
        {
            _context = context;
        }
    }
}
