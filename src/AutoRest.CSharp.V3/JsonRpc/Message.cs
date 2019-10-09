using AutoRest.CSharp.V3.Utilities;

namespace AutoRest.CSharp.V3.JsonRpc
{
    internal interface IMessage { }
    internal class Message : IMessage
    {
        public Channel Channel { get; set; }
        public string[]? Key { get; set; } = null;
        public object? Details { get; set; } = null;
        public string? Text { get; set; }
        public SourceLocation[]? Source { get; set; } = null;

        public override string ToString() =>
            $@"{{""Channel"":""{Channel.ToString().ToLowerInvariant()}""{Key.TextOrEmpty($@",""Key"":{Key.ToJsonArray()}")}{Details.TextOrEmpty($@",""Details"":{Details}")},""Text"":""{Text.ToStringLiteral()}""{Source.TextOrEmpty($@",""Source"":{Source.ToJsonArray()}")}}}";
    }

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

    internal interface IPosition { }
    internal class Position : IPosition
    {
        // 1-based
        public int Line { get; set; }
        // 0-based
        public int Column { get; set; }

        public override string ToString() => $@"{{""line"":{Line},""column"":{Column}}}";
    }

    internal class PositionStringPath : IPosition
    {
        public string[]? Path { get; set; } = null;

        public override string ToString() => $@"{{{Path.TextOrEmpty($@"""path"":{Path.ToJsonArray()}")}}}";
    }

    internal class PositionIntPath : IPosition
    {
        public int[]? Path { get; set; } = null;

        public override string ToString() => $@"{{{Path.TextOrEmpty($@"""path"":{Path.ToJsonArray()}")}}}";
    }

    internal class SourceLocation
    {
        public string? Document { get; set; }
        public IPosition? Position { get; set; }

        public override string ToString() => $@"{{""document"":""{Document}"",""Position"":{Position}}}";
    }

    internal interface IArtifact { }
    internal class ArtifactRaw : IArtifact
    {
        public string? Uri { get; set; }
        public string? Type { get; set; }
        public string? Content { get; set; }
        public RawSourceMap? SourceMap { get; set; } = null;

        public override string ToString() => $@"{{""uri"":""{Uri}"",""type"":""{Type}"",""content"":""{Content.ToStringLiteral()}""{SourceMap.TextOrEmpty($@",""sourceMap"":{SourceMap}")}}}";
    }

    internal class ArtifactMapping : IArtifact
    {
        public string? Uri { get; set; }
        public string? Type { get; set; }
        public string? Content { get; set; }
        public Mapping[]? SourceMap { get; set; } = null;

        public override string ToString() => $@"{{""uri"":""{Uri}"",""type"":""{Type}"",""content"":""{Content.ToStringLiteral()}""{SourceMap.TextOrEmpty($@",""sourceMap"":{SourceMap.ToJsonArray()}")}}}";
    }

    internal class RawSourceMap
    {
        public string? File { get; set; } = null;
        public string? SourceRoot { get; set; } = null;
        public string? Version { get; set; }
        public string[]? Sources { get; set; }
        public string[]? Names { get; set; }
        public string[]? SourcesContent { get; set; } = null;
        public string? Mappings { get; set; }

        public override string ToString() => $@"{{""version"":""{Version}"",""sources"":{Sources.ToJsonArray()},""names"":{Names.ToJsonArray()},""mappings"":""{Mappings}""{File.TextOrEmpty($@",""file"":""{File}""")}{SourceRoot.TextOrEmpty($@",""sourceRoot"":""{SourceRoot}""")}{SourcesContent.TextOrEmpty($@",""sourcesContent"":{SourcesContent.ToJsonArray()}")}}}";
    }

    internal class Mapping
    {
        public Position? Generated { get; set; }
        public Position? Original { get; set; }
        public string? Source { get; set; }
        public string? Name { get; set; } = null;

        public override string ToString() => $@"{{""generated"":{Generated},""original"":{Original},""source"":""{Source}""{Name.TextOrEmpty($@",""name"":""{Name}""")}}}";
    }

    // The Channel that a message is registered with.
    internal enum Channel
    {
        // Information is considered the mildest of responses; not necessarily actionable.
        Information,
        // Warnings are considered important for best practices, but not catastrophic in nature.
        Warning,
        // Errors are considered blocking issues that block a successful operation.
        Error,
        // Debug messages are designed for the developer to communicate internal AutoRest implementation details.
        Debug,
        // Verbose messages give the user additional clarity on the process.
        Verbose,
        // Catastrophic failure, likely aborting the process.
        Fatal,
        // Hint messages offer guidance or support without forcing action.
        Hint,
        // File represents a file output from an extension. Details are a Artifact and are required.
        File,
        // Content represents an update/creation of a configuration file. The final URI will be in the same folder as the primary config file.
        Configuration,
        // Protect is a path to not remove during a clear-output-folder.
        Protect
    }
}
