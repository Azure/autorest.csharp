// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.Utilities;

namespace AutoRest.CSharp.V3.JsonRpc
{
    internal class ArtifactMessage : IMessage
    {
        public Channel Channel { get; set; }
        public string[]? Key { get; set; } = null;
        public IArtifact? Details { get; set; }
        public string? Text { get; set; }
        public SourceLocation[]? Source { get; set; } = null;

        public override string ToString() =>
            $@"{{""Channel"":""{Channel.ToString().ToLowerInvariant()}""{Key.TextOrEmpty($@",""Key"":{Key.ToJsonArray()}")},""Details"":{Details},""Text"":""{Text.ToStringLiteral()}""{Source.TextOrEmpty($@",""Source"":{Source.ToJsonArray()}")}}}";
    }
}
