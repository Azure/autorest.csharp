// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// 

using System;
using System.Diagnostics;
using System.Threading;
using DiagDebugger = System.Diagnostics.Debugger;

namespace AutoRest.Core.Utilities
{
    public static class Debugger
    {
        public static void Await()
        {
            while (!DiagDebugger.IsAttached)
            {
                Console.Error.WriteLine($"Waiting for debugger to attach to process {Process.GetCurrentProcess().Id}");
                for (var i = 0; i < 50; i++)
                {
                    if (DiagDebugger.IsAttached)
                    {
                        break;
                    }
                    Thread.Sleep(100);
                    Console.Error.Write(".");
                }
                Console.Error.WriteLine();
            }
            DiagDebugger.Break();
        }
    }
}