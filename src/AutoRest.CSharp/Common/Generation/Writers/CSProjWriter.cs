// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Xml;

namespace AutoRest.CSharp.Generation.Writers;

internal class CSProjWriter
{
    public CSProjWriter()
    {
        ProjectReferences = new List<CSProjDependencyPackage>();
        PackageReferences = new List<CSProjDependencyPackage>();
        PrivatePackageReferences = new List<CSProjDependencyPackage>();
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

    public CSProjProperty<bool>? TreatWarningsAsErrors { get; init; }

    public CSProjProperty<string>? Nullable { get; init; }

    public CSProjProperty<bool>? IncludeManagementSharedCode { get; init; }

    public CSProjProperty<bool>? IncludeGeneratorSharedCode { get; init; }

    public CSProjProperty<string>? DefineConstants { get; init; }

    public CSProjProperty<string>? RestoreAdditionalProjectSources { get; init; }

    public IList<CSProjDependencyPackage> ProjectReferences { get; }

    public IList<CSProjDependencyPackage> PackageReferences { get; }

    public IList<CSProjDependencyPackage> PrivatePackageReferences { get; }

    public IList<CSProjCompileIncldue> CompileIncludes { get; }

    public string Write()
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
        // write properties
        WriteProperties(writer);

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

        // write private package references
        if (PrivatePackageReferences.Count > 0)
        {
            writer.Flush();
            builder.AppendLine();
            writer.WriteStartElement("ItemGroup");
            foreach (var package in PrivatePackageReferences)
            {
                WritePackageReference(writer, package, true);
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

    private void WriteProperties(XmlWriter writer)
    {
        writer.WriteStartElement("PropertyGroup");
        // get all the properties
        var properties = typeof(CSProjWriter).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        var method = typeof(CSProjWriter).GetMethod(nameof(WriteElementIfNotNull), BindingFlags.NonPublic | BindingFlags.Instance)!;

        // this will write those properties in the same order as they are defined in this class
        foreach (var property in properties)
        {
            // only include those CSProjProperty<T> types
            if (property.PropertyType.GetGenericTypeDefinition() != typeof(CSProjProperty<>))
                continue;
            // invoke the WriteElementIfNotNull method on each of them
            var value = property.GetValue(this);
            var arguments = property.PropertyType.GetGenericArguments();
            method.MakeGenericMethod(arguments).Invoke(this, new[] {writer, property.Name, value});
        }
        writer.WriteEndElement();
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

    private void WritePackageReference(XmlWriter writer, CSProjDependencyPackage package, bool isPrivateAsset = false)
    {
        writer.WriteStartElement("PackageReference");
        writer.WriteAttributeString("Include", package.PackageName);
        if (package.Version != null)
        {
            writer.WriteAttributeString("Version", package.Version);
        }
        if (isPrivateAsset)
        {
            writer.WriteAttributeString("PrivateAssets", "All");
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

    public record CSProjCompileIncldue(string Include, string? LinkBase)
    {
        public CSProjCompileIncldue(string include) : this(include, null) { }
    }
}
