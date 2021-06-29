// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Input;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Mgmt.AutoRest
{
    internal class CodeModelValidator
    {
        public static void Validate(CodeModel model) {
            foreach (var group in model.OperationGroups)
            {
                if (string.IsNullOrEmpty(group.Key)) {
                    ErrorHelpers.ThrowError(@"Malformed 'operationId' detected. Check swagger definition and make sure every 'operationId' follows form of 'Noun_Verb'. For details, refer to: https://github.com/Azure/azure-rest-api-specs/blob/master/documentation/openapi-authoring-automated-guidelines.md#r1001
Or overwrite the 'operationId' by 'transform' directive in configuration. For examples, refer to: https://github.com/Azure/autorest/blob/main/Samples/openapi-v2/3b-custom-transformations/readme.md#openapi-definition-mutate-descriptions");
                }
            }
        }
    }
}
