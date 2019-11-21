// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Text;
using System.Text.Json;
using AutoRest.CSharp.V3.Utilities;

namespace AutoRest.CSharp.V3.JsonRpc.Messaging
{
    internal static class PeekingBinaryReaderExtensions
    {
        public static bool IsJsonBlock(this byte? value) => '{' == value || '[' == value;

        public static JsonElement? ReadJson(this PeekableBinaryStream stream, int contentLength) => Encoding.UTF8.GetString(stream.ReadBytes(contentLength)).Parse();
        public static JsonElement? ReadJson(this PeekableBinaryStream stream)
        {
            var sb = new StringBuilder();
            // ReSharper disable once IteratorMethodResultIsIgnored
            stream.ReadAllAsciiLines(l => sb.Append(l).ToString().Parse() != null);
            return sb.ToString().Parse();
        }
    }
}
