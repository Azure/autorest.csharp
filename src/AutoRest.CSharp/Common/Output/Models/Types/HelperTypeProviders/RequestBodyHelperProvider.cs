// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Azure;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.System;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Models.Types
{
    internal class RequestBodyHelperProvider : ExpressionTypeProvider
    {
        private static readonly Lazy<RequestBodyHelperProvider> _instance = new Lazy<RequestBodyHelperProvider>(() => new RequestBodyHelperProvider(Configuration.Namespace));
        public static RequestBodyHelperProvider Instance => _instance.Value;

        private RequestBodyHelperProvider(string defaultNamespace) : base(defaultNamespace, null)
        {
            DefaultName = Configuration.IsBranded ? "RequestContentHelper" : "RequestBodyHelper";
            IsStatic = true;
        }

        protected override string DefaultName { get; }

        protected override string DefaultAccessibility { get; } = "internal";

        protected override IEnumerable<Method> BuildMethods()
        {
            foreach (var method in BuildFromEnumerableMethods())
            {
                yield return method;
            }
        }

        private IEnumerable<Method> BuildFromEnumerableMethods()
        {
            //var signature = new MethodSignature(
            //    )
            yield break;
        }

        public const string FromEnumerable = "FromEnumerable";
        public const string FromDictionary = "FromDictionary";
    }
}
