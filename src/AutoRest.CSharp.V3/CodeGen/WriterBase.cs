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
        private CSharpNamespace? _currentNamespace;
        private readonly bool _useTypeShortNames = true;
        private readonly bool _useKeywords = true;

        public abstract void Line(string str = "");
        public abstract void Append(string str = "");
        public abstract void Replace(string oldValue = "", string newValue = "");
        public abstract string GetFormattedCode();

        public virtual void FileHeader()
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

        private DisposeAction Definition(string modifiers, string kind, string defaultName, string? name, string? implements = null)
        {
            var line = new[] {modifiers, kind, name ?? defaultName, implements != null ? $": {implements}" : null}.JoinIgnoreEmpty(" ");
            Line(line);
            return Scope();
        }

        public DisposeAction Class(string modifiers, string? name, string? implements = null) => Definition(modifiers, "class", "[NO TYPE NAME]", name, implements);
        public DisposeAction Enum(string modifiers, string? name, string? implements = null) => Definition(modifiers, "enum", "[NO ENUM NAME]", name, implements);
        public DisposeAction Struct(string modifiers, string? name, string? implements = null) => Definition(modifiers, "struct", "[NO STRUCT NAME]", name, implements);

        //public EndBlock Method(string methodDeclaration)
        //{
        //    Line(methodDeclaration);
        //    return Scope();
        //}

        //public EndBlock Method(string modifiers, string type, string name, params string[] parameters)
        //{
        //    Line($"{modifiers} {type} {name}({string.Join(", ", parameters)})");
        //    return Scope();
        //}

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

        public void AutoProperty(string modifiers, CSharpType? type, string? name) =>
            Line($"{modifiers} {Pair(type, name)} {{ get; set; }}");

        public void EnumValue(string? value, bool includeComma = true) =>
            Line($"{value ?? "[NO VALUE]"}{(includeComma ? "," : String.Empty)}");

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
                    .Select(ns => $"using {ns};");
                var usingBlock = String.Join(Environment.NewLine, usingLines);
                var removeLine = usingBlock.Any() ? String.Empty : Environment.NewLine;
                var extraLine = usingBlock.Any() ? Environment.NewLine : String.Empty;
                Replace(usingBlockIdentifier + removeLine, usingBlock + extraLine);
            });
        }

        public string Type(CSharpType? type)
        {
            if (_useTypeShortNames)
            {
                _usingNamespaces.Add(type?.KeywordName != null ? null : type?.Namespace);
                _usingNamespaces.Add(type?.SubType1?.KeywordName != null ? null : type?.SubType1?.Namespace);
                _usingNamespaces.Add(type?.SubType2?.KeywordName != null ? null : type?.SubType2?.Namespace);
            }
            return (_useTypeShortNames ? type?.GetComposedName(typesAsKeywords: _useKeywords) : type?.FullName) ?? "[NO TYPE]";
        }

        public string Type(Type? type) => Type(new CSharpType {FrameworkType = type});
        public string AttributeType(Type? type) => Type(type).Replace("Attribute", String.Empty);

        public static string Pair(string? typeText, string? name) => $"{typeText ?? "[NO TYPE]"} {name ?? "[NO NAME]"}";
        public string Pair(CSharpType? type, string? name) => $"{Type(type)} {name ?? "[NO NAME]"}";
        public string Pair(Type? type, string? name) => $"{Type(type)} {name ?? "[NO NAME]"}";
    }
}
