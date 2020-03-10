// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.V3.Generation.Writers
{
    internal static class BinaryCodeWriterExtensions
    {
        public static void WriteMethodDeserialization(this CodeWriter writer, bool async, ref string destination, string message)
        {
            writer.Line($"var {destination:D} = {message:D}.ExtractResponseContent();");
            using (writer.Scope($"if ({destination:D} == null)"))
            {
                if (async)
                {
                    writer.Line($"throw await clientDiagnostics.CreateRequestFailedExceptionAsync({message:D}.Response).ConfigureAwait(false);");
                }
                else
                {
                    writer.Line($"throw clientDiagnostics.CreateRequestFailedException({message:D}.Response);");
                }
            }
        }
    }
}
