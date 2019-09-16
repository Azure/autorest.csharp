// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// 

using System;

namespace AutoRest.Core.Utilities
{
    public static class Debugger
    {
        public static void Await()
        {
            while (!System.Diagnostics.Debugger.IsAttached)
            {
                Console.Error.WriteLine($"Waiting for debugger to attach to process {System.Diagnostics.Process.GetCurrentProcess().Id}");
                for (int i = 0; i < 50; i++)
                {
                    if (System.Diagnostics.Debugger.IsAttached)
                    {
                        break;
                    }
                    System.Threading.Thread.Sleep(100);
                    Console.Error.Write(".");
                }
                Console.Error.WriteLine();
            }
            System.Diagnostics.Debugger.Break();
        }
    }
}