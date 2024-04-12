// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using AutoRest.CSharp.Input;

namespace AutoRest.CSharp.Mgmt.Decorator.Transformer;

internal static class RearrangeParameterOrder
{
    public static void Update(CodeModel codeModel)
    {
        foreach (var operationGroup in codeModel.OperationGroups)
        {
            foreach (var operation in operationGroup.Operations)
            {
                var httpRequest = operation.GetHttpRequest();
                if (httpRequest != null)
                {
                    var orderedParams = operation.Parameters
                        .Where(p => p.In == HttpParameterIn.Path)
                        .OrderBy(
                            p => httpRequest.Path.IndexOf(
                                "{" + p.GetOriginalName() + "}",
                                StringComparison.InvariantCultureIgnoreCase));
                    operation.Parameters = orderedParams.Concat(operation.Parameters
                            .Where(p => p.In != HttpParameterIn.Path).ToList())
                        .ToList();
                }
            }
        }
    }
}
