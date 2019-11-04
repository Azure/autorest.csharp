using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AutoRest.CSharp.V3.Pipeline.Generated;
using AutoRest.CSharp.V3.Utilities;

namespace AutoRest.CSharp.V3.CodeGen
{
    internal abstract class WriterBase
    {
        private readonly List<CSharpNamespace?> _usingNamespaces = new List<CSharpNamespace?>();
        private readonly List<string> _classFields = new List<string>();
        private CSharpNamespace? _currentNamespace;

        private readonly bool _useTypeShortNames = true;
        private readonly bool _useKeywords = true;
        private readonly string _definitionAccessDefault = "public";

        public abstract void Line(string str = "");
        public abstract void Append(string str = "");
        public abstract void Replace(string oldValue = "", string newValue = "");
        public abstract string GetFormattedCode();

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

        public DisposeAction Class(string? access, string? modifiers, string? name, string? implements = null) //=> Definition(access, modifiers, "class", "[NO TYPE NAME]", name, implements);
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

        public void MethodExpression(string? modifiers, string? returnType, string? name, string[]? parameters, string expression) =>
            Line($"{MethodDeclaration(modifiers, returnType, name, parameters ?? new string[0])} => {expression};");

        public void EnumValue(string? value, bool includeComma = true) =>
            Line($"{value ?? "[NO VALUE]"}{(includeComma ? "," : String.Empty)}");

        public void AutoProperty(string modifiers, CSharpType? type, string? name, bool? isNullable) =>
            Line($"{modifiers} {Pair(type, name, isNullable)} {{ get; set; }}");

        public void LazyProperty(string modifiers, CSharpType? type, CSharpType? concreteType, string? name, bool? isNullable)
        {
            var variable = $"_{name.ToVariableName()}";
            _classFields.Add($"private {Pair(concreteType, variable, isNullable)};");
            Line($"{modifiers} {Pair(type, name)} => {Type(typeof(LazyInitializer))}.EnsureInitialized(ref {variable})!;");
        }

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

        public string Type(CSharpType? type, bool? isNullable = false)
        {
            if (_useTypeShortNames)
            {
                _usingNamespaces.Add(type?.KeywordName != null ? null : type?.Namespace);
                _usingNamespaces.Add(type?.SubType1?.KeywordName != null ? null : type?.SubType1?.Namespace);
                _usingNamespaces.Add(type?.SubType2?.KeywordName != null ? null : type?.SubType2?.Namespace);
            }
            var typeText = _useTypeShortNames ? type?.GetComposedName(typesAsKeywords: _useKeywords) : type?.FullName;
            var nullMark = (isNullable ?? false) ? "?" : String.Empty;
            return (typeText != null ? typeText + nullMark : null) ?? "[NO TYPE]";
        }

        public string Type(Type? type, bool? isNullable = false) => Type(new CSharpType {FrameworkType = type}, isNullable);
        public string AttributeType(Type? type) => Type(type).Replace("Attribute", String.Empty);

        public static string Pair(string? typeText, string? name) => $"{typeText ?? "[NO TYPE]"} {name ?? "[NO NAME]"}";
        public string Pair(CSharpType? type, string? name, bool? isNullable = false) => $"{Type(type, isNullable)} {name ?? "[NO NAME]"}";
        public string Pair(Type? type, string? name, bool? isNullable = false) => $"{Type(type, isNullable)} {name ?? "[NO NAME]"}";
    }
}
