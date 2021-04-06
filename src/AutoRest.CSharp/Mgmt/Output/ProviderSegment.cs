// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.Output.Models.Requests
{
    internal class ProviderSegment
    {
        internal static readonly string Providers = "/providers/";
        internal bool NoPredecessor { get; set; }
        internal bool HasReferenceSuccessor { get; set; }
        internal bool IsFullProvider { get; set; }
        internal string TokenValue { get; set; }
        internal bool HadSpecialReference { get; set; }
        internal bool IsLastProvider { get; set; }
        internal int IndexFoundAt { get; set; }
        internal ProviderSegment()
        {
            TokenValue = string.Empty;
        }
    }
}
