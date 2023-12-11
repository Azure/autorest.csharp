// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace AutoRest.CSharp.Common.Output.Builders;

internal class CSProjBuilder
{
    public CSProjBuilder()
    {
        ProjectReferences = new List<CSProjDependencyPackage>();
        PackageReferences = new List<CSProjDependencyPackage>();
        CompileIncludes = new List<CSProjCompileIncldue>();
    }

    public CSProjProperty<string>? Description { get; init; }

    public CSProjProperty<string>? AssemblyTitle { get; init; }

    public CSProjProperty<string>? Version { get; init; }

    public CSProjProperty<string>? PackageTags { get; init; }

    public CSProjProperty<string>? TargetFrameworks { get; init; }

    public CSProjProperty<string>? TargetFramework { get; init; }

    public CSProjProperty<bool>? IncludeOperationsSharedSource { get; init; }

    public CSProjProperty<string>? LangVersion { get; init; }

    public CSProjProperty<bool>? GenerateDocumentationFile { get; init; }

    public CSProjProperty<string>? NoWarn { get; init; }

    public IList<CSProjDependencyPackage> ProjectReferences { get; }

    public IList<CSProjDependencyPackage> PackageReferences { get; }

    public IList<CSProjCompileIncldue> CompileIncludes { get; }

    public string Build()
    {
        var builder = new StringBuilder();
        using var writer = XmlWriter.Create(builder, new XmlWriterSettings
        {
            OmitXmlDeclaration = true,
            Indent = true
        });
        writer.WriteStartDocument();
        // write the Project element
        writer.WriteStartElement("Project");
        writer.WriteAttributeString("Sdk", "Microsoft.NET.Sdk");
        writer.WriteStartElement("PropertyGroup");
        WriteElementIfNotNull(writer, "Description", Description);
        WriteElementIfNotNull(writer, "AssemblyTitle", AssemblyTitle);
        WriteElementIfNotNull(writer, "Version", Version);
        WriteElementIfNotNull(writer, "PackageTags", PackageTags);
        WriteElementIfNotNull(writer, "TargetFrameworks", TargetFrameworks);
        WriteElementIfNotNull(writer, "TargetFramework", TargetFramework);
        WriteElementIfNotNull(writer, "IncludeOperationsSharedSource", IncludeOperationsSharedSource);
        WriteElementIfNotNull(writer, "LangVersion", LangVersion);
        WriteElementIfNotNull(writer, "GenerateDocumentationFile", GenerateDocumentationFile);
        WriteElementIfNotNull(writer, "NoWarn", NoWarn);
        writer.WriteEndElement();

        // write the first ItemGroup for compile include
        if (CompileIncludes.Count > 0)
        {
            // this is the only way I know to write a blank line in an xml document using APIs instead of just write raw strings
            // feel free to change this if other elegant way is found.
            writer.Flush();
            builder.AppendLine();
            writer.WriteStartElement("ItemGroup");
            foreach (var compileInclude in CompileIncludes)
            {
                WriteCompileInclude(writer, compileInclude);
            }
            writer.WriteEndElement();
        }

        // write project references
        if (ProjectReferences.Count > 0)
        {
            writer.Flush();
            builder.AppendLine();
            writer.WriteStartElement("ItemGroup");
            foreach (var package in ProjectReferences)
            {
                WriteProjectReference(writer, package);
            }
            writer.WriteEndElement();
        }

        // write package references
        if (PackageReferences.Count > 0)
        {
            writer.Flush();
            builder.AppendLine();
            writer.WriteStartElement("ItemGroup");
            foreach (var package in PackageReferences)
            {
                WritePackageReference(writer, package);
            }
            writer.WriteEndElement();
        }
        writer.WriteEndDocument();
        writer.Close();
        writer.Flush();

        // add an empty on the end of file
        builder.AppendLine();

        return builder.ToString();
    }

    private void WriteElementIfNotNull<T>(XmlWriter writer, string name, CSProjProperty<T>? property) where T : notnull
    {
        if (property == null)
            return;

        if (property.Comment != null)
        {
            writer.WriteComment(property.Comment);
        }

        switch (property.Value)
        {
            case string s:
                writer.WriteElementString(name, s);
                break;
            case bool b:
                writer.WriteElementString(name, XmlConvert.ToString(b));
                break;
            default:
                throw new NotImplementedException($"type of {property.Value.GetType()} is unhandled");
        }
    }

    private void WriteCompileInclude(XmlWriter writer, CSProjCompileIncldue compileInclude)
    {
        writer.WriteStartElement("Compile");
        writer.WriteAttributeString("Include", compileInclude.Include);
        if (compileInclude.LinkBase != null)
        {
            writer.WriteAttributeString("LinkBase", compileInclude.LinkBase);
        }
        writer.WriteEndElement();
    }

    private void WriteProjectReference(XmlWriter writer, CSProjDependencyPackage package)
    {
        writer.WriteStartElement("ProjectReference");
        writer.WriteAttributeString("Include", package.PackageName);
        writer.WriteEndElement();
    }

    private void WritePackageReference(XmlWriter writer, CSProjDependencyPackage package)
    {
        writer.WriteStartElement("PackageReference");
        writer.WriteAttributeString("Include", package.PackageName);
        if (package.Version != null)
        {
            writer.WriteAttributeString("Version", package.Version);
        }
        writer.WriteEndElement();
    }

    public record CSProjProperty<T>(T Value, string? Comment) where T : notnull
    {
        public CSProjProperty(T value) : this(value, null)
        { }

        public static implicit operator CSProjProperty<T>(T value) => new(value, null);
    }

    public record CSProjDependencyPackage(string PackageName, string? Version)
    {
        public CSProjDependencyPackage(string packageName) : this(packageName, null) { }
    }

    public record CSProjCompileIncldue(string Include, string? LinkBase);
}
