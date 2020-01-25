// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.Generation.Types;

namespace AutoRest.CSharp.V3.Generation.Writers
{
    internal static class CodeWriterExtensions
    {
        public static CodeWriter AppendNullableValue(this CodeWriter writer, CSharpType type) =>
            writer.AppendNullableValue(type.IsNullable, type.IsValueType);

        public static CodeWriter AppendNullableValue(this CodeWriter writer, bool isNullable, bool isValueType)
        {
            if (isNullable && isValueType)
            {
                writer.Append($".Value");
            }

            return writer;
        }
    }
}
