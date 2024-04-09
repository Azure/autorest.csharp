// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.System;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Models.Types
{
    internal class MultipartFormDataExtensionsProvider: ExpressionTypeProvider
    {
        private static readonly Lazy<MultipartFormDataExtensionsProvider> _instance = new Lazy<MultipartFormDataExtensionsProvider>(() => new MultipartFormDataExtensionsProvider());
        public static MultipartFormDataExtensionsProvider Instance => _instance.Value;

        private readonly MethodSignatureModifiers _methodModifiers = MethodSignatureModifiers.Public | MethodSignatureModifiers.Static | MethodSignatureModifiers.Extension;

        public MultipartFormDataExtensionsProvider() : base(Configuration.HelperNamespace, null)
        {
            DeclarationModifiers = TypeSignatureModifiers.Internal | TypeSignatureModifiers.Static;
        }
        protected override string DefaultName => "MultipartFormDataExtensions";
        protected override IEnumerable<Method> BuildMethods()
        {
            yield return BuildParseToFormDataMethod();
        }
        private const string _parseToFormDataMethodName = "ParseToFormData";
        private Method BuildParseToFormDataMethod()
        {
            CSharpType readonlyListType = new CSharpType(typeof(IReadOnlyList<>), new CSharpType[] { FormDataItemProvider.Instance.Type });
            Parameter multipartParameter = new Parameter("multipart", null, Configuration.ApiTypes.MultipartRequestContentType, null, ValidationType.None, null);
            var signature = new MethodSignature(
                Name: _parseToFormDataMethodName,
                Summary: null,
                Description: null,
                Modifiers: _methodModifiers,
                ReturnType: readonlyListType,
                ReturnDescription: null,
                Parameters: new[] { multipartParameter });
            var body = new MethodBodyStatement[]
            {
                Var("list", New.List(FormDataItemProvider.Instance.Type), out var list),
                Return (list)
            };
            return new Method(signature, body);
        }
        public ValueExpression ParseToFormData(MultipartFormDataExpression multipart)
            => new InvokeStaticMethodExpression(Type, _parseToFormDataMethodName, new ValueExpression[] { multipart });
        public ValueExpression ParseToFormData(MultipartFormDataBinaryContentExpression multipart)
            => new InvokeStaticMethodExpression(Type, _parseToFormDataMethodName, new ValueExpression[] { multipart });
    }
}
