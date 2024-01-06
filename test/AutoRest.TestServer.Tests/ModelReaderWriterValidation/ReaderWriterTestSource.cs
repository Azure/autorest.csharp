// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace AutoRest.TestServer.Tests
{
    public static class ReaderWriterTestSource
    {
        internal static List<BinaryData> InvalidOperationBinaryData = new List<BinaryData>
        {
            new BinaryData("\"\""u8.ToArray()),
            new BinaryData("[]"u8.ToArray()),
        };

        internal static List<BinaryData> JsonExceptionBinaryData = new List<BinaryData>
        {
            new BinaryData(new byte[] { }),
        };

        internal static List<BinaryData> NullBinaryData = new List<BinaryData>
        {
            new BinaryData("null"u8.ToArray()),
        };

        internal static List<BinaryData> EmptyObjectBinaryData = new List<BinaryData>
        {
            new BinaryData("{}"u8.ToArray()),
        };
    }
}
