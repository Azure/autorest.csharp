using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.V3.Pipeline.Generated;

namespace AutoRest.CSharp.V3.CodeGen
{
    internal abstract class BaseCSharpWriter
    {
        private readonly List<CSharpNamespace?> _usingNamespaces = new List<CSharpNamespace?>();
        private CSharpNamespace? _currentNamespace;
        private bool _useTypeShortNames = true;
        private bool _useKeywords = true;

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

        public DisposeAction Class(string modifiers, CSharpLanguage? cs = null)
        {
            Line($"{modifiers} class {cs?.Name ?? "[NO TYPE NAME]"}");
            return Scope();
        }

        public DisposeAction Enum(string modifiers, CSharpLanguage? cs = null)
        {
            Line($"{modifiers} enum {cs?.Name ?? "[NO ENUM NAME]"}");
            return Scope();
        }

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

        public void AutoProperty(string modifiers, CSharpType? type = null, CSharpLanguage? propertyCs = null) =>
            Line($"{modifiers} {Type(type)} {propertyCs?.Name ?? "[NO PROPERTY NAME]"} {{ get; set; }}");

        public void EnumValue(CSharpLanguage? choiceCs = null, bool includeComma = true) => Line($"{choiceCs?.Name ?? "[NO NAME]"}{(includeComma ? "," : String.Empty)}");

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

        public DisposeAction Usings()
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

        public string Type(CSharpType? type = null)
        {
            _usingNamespaces.Add(type?.KeywordName != null ? null : type?.Namespace);
            _usingNamespaces.Add(type?.SubType1?.KeywordName != null ? null : type?.SubType1?.Namespace);
            _usingNamespaces.Add(type?.SubType2?.KeywordName != null ? null : type?.SubType2?.Namespace);
            return (_useTypeShortNames ? type?.GetComposedName(typesAsKeywords: _useKeywords) : type?.FullName) ?? "[NO TYPE]";
        }
    }
}
