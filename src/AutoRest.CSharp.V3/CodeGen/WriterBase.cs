// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.V3.Pipeline.Generated;
using AutoRest.CSharp.V3.Utilities;

namespace AutoRest.CSharp.V3.CodeGen
{
    internal abstract class WriterBase
    {
        private readonly List<CSharpNamespace?> _usingNamespaces = new List<CSharpNamespace?>();
        private readonly List<string> _classFields = new List<string>();
        private CSharpNamespace? _currentNamespace;

        private readonly string _definitionAccessDefault = "public";

        public abstract void Line(string str = "");
        public abstract void Append(string str = "");
        public abstract void Replace(string oldValue = "", string newValue = "");
        public abstract string ToFormattedCode();

        public virtual void Header()
        {
            Line("// Copyright (c) Microsoft Corporation. All rights reserved.");
            Line("// Licensed under the MIT License.");
            Line();
        }

        protected virtual DisposeAction Scope(string start = "{", string end = "}")
        {
            Line(start);
            return new DisposeAction(() => Line(end));
        }

        public DisposeAction Namespace(CSharpNamespace? @namespace = null)
        {
            _currentNamespace = @namespace;
            Line($"namespace {@namespace?.FullName ?? "[NO NAMESPACE]"}");
            return Scope();
        }

        private string DefinitionLine(string? access, string? modifiers, string kind, string defaultName, string? name, string? implements = null) =>
            new[] { access ?? _definitionAccessDefault, modifiers, kind, name ?? defaultName, implements != null ? $": {implements}" : null }.JoinIgnoreEmpty(" ");

        private DisposeAction Definition(string? access, string? modifiers, string kind, string defaultName, string? name, string? implements = null)
        {
            Line(DefinitionLine(access, modifiers, kind, defaultName, name, implements));
            return Scope();
        }

        public DisposeAction Class(string? access, string? modifiers, string? name, string? implements = null)
        {
            Line(DefinitionLine(access, modifiers, "class", "[NO TYPE NAME]", name, implements));
            Line("{");
            const string fieldBlockIdentifier = "%%ClassFieldBlock%%";
            Line(fieldBlockIdentifier);
            return new DisposeAction(() =>
            {
                var fields = _classFields.Any() ? String.Join(Environment.NewLine, _classFields) + Environment.NewLine + Environment.NewLine : String.Empty;
                Replace(fieldBlockIdentifier + Environment.NewLine, fields);
                _classFields.Clear();
                Line("}");
            });
        }
        public DisposeAction Enum(string? access, string? modifiers, string? name, string? implements = null) => Definition(access, modifiers, "enum", "[NO ENUM NAME]", name, implements);
        public DisposeAction Struct(string? access, string? modifiers, string? name, string? implements = null) => Definition(access, modifiers, "struct", "[NO STRUCT NAME]", name, implements);

        private static string MethodDeclaration(string? modifiers, string? returnType, string? name, params string[] parameters)
        {
            var headerText = new[] { modifiers, returnType, name ?? "[NO METHOD NAME]" }.JoinIgnoreEmpty(" ");
            var parametersText = parameters.JoinIgnoreEmpty(", ");
            return $"{headerText}({parametersText})";
        }

        public DisposeAction Method(string? modifiers, string? returnType, string? name, params string[] parameters)
        {
            Line(MethodDeclaration(modifiers, returnType, name, parameters));
            return Scope();
        }

        public DisposeAction Try()
        {
            Line("try");
            return Scope();
        }

        public DisposeAction Catch(params string[] parameters)
        {
            var parametersText = parameters.JoinIgnoreEmpty(", ");
            Line($"catch{(parameters.Length > 0 ? $"({parametersText})" : String.Empty)}");
            return Scope();
        }

        public DisposeAction If(string condition)
        {
            Line($"if({condition})");
            return Scope();
        }

        public DisposeAction Else()
        {
            Line("else");
            return Scope();
        }

        public DisposeAction ForEach(string statement)
        {
            Line($"foreach({statement})");
            return Scope();
        }

        public DisposeAction Switch(string value)
        {
            Line($"switch({value})");
            return Scope();
        }

        public void MethodExpression(string? modifiers, string? returnType, string? name, string[]? parameters, string expression) =>
            Line($"{MethodDeclaration(modifiers, returnType, name, parameters ?? new string[0])} => {expression};");

        public void EnumValue(string? value, bool includeComma = true) =>
            Line($"{value ?? "[NO VALUE]"}{(includeComma ? "," : String.Empty)}");

        public void AutoProperty(string modifiers, CSharpType type, string? name, bool isReadOnly = false, string? initializer = null) =>
            Line($"{modifiers} {Pair(type, name)} {{ get; {(isReadOnly ? String.Empty : "set; ")}}}{initializer}");

        //TODO: Determine implementation for documentation
        //public void DocSummary(string summary)
        //{
        //    Line("/// <summary>");
        //    var summaryLines = summary.Split(Environment.NewLine);
        //    foreach (var summaryLine in summaryLines)
        //    {
        //        Line($"/// {summaryLine}");
        //    }
        //    Line("/// </summary>");
        //}
        //public void DocParam(string paramName, string paramSummary) =>
        //    Line($"/// <param name=\"{paramName}\">{paramSummary}</param>");

        //public void DocReturns(string returns) =>
        //    Line($"/// <returns>{returns}</returns>");

        public DisposeAction UsingStatements()
        {
            const string usingBlockIdentifier = "%%UsingBlock%%";
            Line(usingBlockIdentifier);
            return new DisposeAction(() =>
            {
                var usingLines = _usingNamespaces
                    .Where(un => un != null)
                    .Select(un => un!.FullName)
                    .Distinct()
                    .Where(ns => ns != _currentNamespace?.FullName)
                    .OrderByDescending(ns => ns.StartsWith("System"))
                    .ThenBy(ns => ns, StringComparer.InvariantCulture)
                    .Select(ns => $"using {ns};")
                    .ToArray();
                var usingBlock = usingLines.Any() ? String.Join(Environment.NewLine, usingLines) + Environment.NewLine + Environment.NewLine : String.Empty;
                Replace(usingBlockIdentifier + Environment.NewLine, usingBlock);
            });
        }

        public string Type(CSharpType type)
        {
            string name;

            if (type.FrameworkType != null && GetKeywordMapping(type.FrameworkType) is string keyword)
            {
                name = keyword;
            }
            else
            {
                name = type.Name;
                _usingNamespaces.Add(type.Namespace);
            }

            if (type.Arguments.Any())
            {
                var subTypes = type.Arguments.Select(a => Type(a)).JoinIgnoreEmpty(", ");
                name += $"<{subTypes}>";
            }

            if (type.IsNullable)
            {
                name += "?";
            }

            return name;
        }

        public string Type(Type type, bool isNullable = false) => Type(new CSharpType(type, isNullable));
        public string AttributeType(Type type) => Type(type).Replace("Attribute", String.Empty);

        public static string Pair(string? typeText, string? name) => $"{typeText ?? "[NO TYPE]"} {name ?? "[NO NAME]"}";
        public string Pair(CSharpType type, string? name) => $"{Type(type)} {name ?? "[NO NAME]"}";
        public string Pair(Type type, string? name, bool isNullable = false) => $"{Type(type, isNullable)} {name ?? "[NO NAME]"}";

        private static string? GetKeywordMapping(Type? type) =>
            type switch
            {
                var t when t == typeof(bool) => "bool",
                var t when t == typeof(byte) => "byte",
                var t when t == typeof(sbyte) => "sbyte",
                var t when t == typeof(short) => "short",
                var t when t == typeof(ushort) => "ushort",
                var t when t == typeof(int) => "int",
                var t when t == typeof(uint) => "uint",
                var t when t == typeof(long) => "long",
                var t when t == typeof(ulong) => "ulong",
                var t when t == typeof(char) => "char",
                var t when t == typeof(double) => "double",
                var t when t == typeof(float) => "float",
                var t when t == typeof(object) => "object",
                var t when t == typeof(decimal) => "decimal",
                var t when t == typeof(string) => "string",
                _ => null
            };
    }
}
