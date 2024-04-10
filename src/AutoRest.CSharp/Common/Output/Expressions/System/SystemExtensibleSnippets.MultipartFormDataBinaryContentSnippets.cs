﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.System;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Common.Output.Expressions.System
{
    internal partial class SystemExtensibleSnippets
    {
        internal class MultipartFormDataBinaryContentSnippets
        {
            public ValueExpression ParseToFormData(MultipartFormDataBinaryContentExpression multipart)
                => MultipartFormDataBinaryContentExtensionsProvider.Instance.ParseToFormData(multipart);
            public MethodBodyStatement Add(VariableReference multipartContent, ValueExpression content, ValueExpression name, ValueExpression fileName)
            {
                var multipartContentExpression = new MultipartFormDataBinaryContentExpression(multipartContent);
                if (fileName != null)
                {
                    return multipartContentExpression.Add(content, name, fileName);
                } else
                {
                    return multipartContentExpression.Add(content, name);
                }
            }
        }
    }
}
