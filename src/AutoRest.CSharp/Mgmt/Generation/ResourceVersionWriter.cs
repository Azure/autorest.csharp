// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Output;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class ResourceVersionWriter
    {
        private Resource _resource;

        public ResourceVersionWriter(Resource resource)
        {
            _resource = resource;
            VersionClassName = $"{resource.ResourceName}Version";
        }

        public string VersionClassName { get; }

        public void Write(CodeWriter writer)
        {
            writer.UseNamespace(typeof(IEquatable<>).Namespace!);

            using (writer.Namespace($"{_resource.Type.Namespace}.Models"))
            {
                writer.WriteXmlDocumentationSummary($" The versions of {_resource.ResourceName} this client is compatible with. ");
                using (writer.Scope($"public readonly partial struct {VersionClassName} : IEquatable<{VersionClassName}>"))
                {
                    writer.Line($"private readonly string _value;");

                    writer.Line();
                    var versions = new List<string>() { "2019-10-01" }; //TODO: Get this from somewhere
                    writer.Line($"#pragma warning disable CA1707 // Identifiers should not contain underscores");
                    foreach (string version in versions)
                    {
                        var versionProperty = GetVersionProperty(version);
                        writer.WriteXmlDocumentationSummary($"Version {version}.");
                        writer.Line($"public static {VersionClassName} {versionProperty} {{ get; }} = new {VersionClassName}(\"{version}\");");
                    }
                    writer.Line($"#pragma warning restore CA1707 // Identifiers should not contain underscores");
                    writer.WriteXmlDocumentationSummary($"Default version.");
                    writer.Line($"public static {VersionClassName} Default {{ get; }} = {GetVersionProperty(versions[0])};");

                    writer.Line();
                    writer.WriteXmlDocumentationSummary($"Initializes a new instance of the <see cref=\"{VersionClassName}\"/> structure.");
                    writer.WriteXmlDocumentationParameter("value", $"The string value of the instance.");
                    using (writer.Scope($"private {VersionClassName}(string value)"))
                    {
                        writer.Line($"_value = value ?? throw new ArgumentNullException(nameof(value));");
                    }

                    writer.Line();
                    writer.WriteXmlDocumentationSummary($"Converts a string to a <see cref=\"{VersionClassName}\"/>.");
                    writer.WriteXmlDocumentationParameter("value", $"The string value to convert.");
                    writer.Line($"public static implicit operator {VersionClassName}(string value) => new {VersionClassName}(value);");

                    writer.Line();
                    writer.WriteXmlDocumentationInheritDoc();
                    writer.Line($"public bool Equals({VersionClassName} other) => string.Equals(_value, other._value, {typeof(StringComparison)}.Ordinal);");

                    writer.Line();
                    writer.WriteXmlDocumentationSummary($"Determines if two <see cref=\"{VersionClassName}\"/> values are the same.");
                    WriteRightLeftParam(writer);
                    writer.WriteXmlDocumentationReturns($"True if <paramref name=\"left\"/> and <paramref name=\"right\"/> are the same; otherwise, false.");
                    writer.Line($"public static bool operator ==({VersionClassName} left, {VersionClassName} right) => left.Equals(right);");

                    writer.Line();
                    writer.WriteXmlDocumentationSummary($"Determines if two <see cref=\"{VersionClassName}\"/> values are different.");
                    WriteRightLeftParam(writer);
                    writer.WriteXmlDocumentationReturns($"True if <paramref name=\"left\"/> and <paramref name=\"right\"/> are different; otherwise, false.");
                    writer.Line($"public static bool operator !=({VersionClassName} left, {VersionClassName} right) => !left.Equals(right);");

                    writer.Line();
                    writer.WriteXmlDocumentationInheritDoc();
                    writer.Line($"public override string ToString() => _value;");

                    writer.Line();
                    writer.WriteXmlDocumentationInheritDoc();
                    WriteBrowsableNever(writer);
                    writer.Line($"public override bool Equals(object obj) => obj is {VersionClassName} other && Equals(other);");

                    writer.Line();
                    writer.WriteXmlDocumentationInheritDoc();
                    WriteBrowsableNever(writer);
                    writer.Line($"public override int GetHashCode() => _value?.GetHashCode() ?? 0;");
                }
            }
        }

        private object GetVersionProperty(string version)
        {
            return $"V{version.Replace('-', '_')}";
        }

        private static void WriteBrowsableNever(CodeWriter writer)
        {
            writer.Line($"[{typeof(EditorBrowsableAttribute)}({typeof(EditorBrowsableState)}.{nameof(EditorBrowsableState.Never)})]");
        }

        private void WriteRightLeftParam(CodeWriter writer)
        {
            writer.WriteXmlDocumentationParameter("left", $"The first <see cref=\"{VersionClassName}\"/> to compare.");
            writer.WriteXmlDocumentationParameter("right", $"The second <see cref=\"{VersionClassName}\"/> to compare.");
        }
    }
}
