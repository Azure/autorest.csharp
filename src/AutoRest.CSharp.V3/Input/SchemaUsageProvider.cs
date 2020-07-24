// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace AutoRest.CSharp.V3.Input
{
    internal class SchemaUsageProvider
    {
        private readonly Dictionary<Schema, SchemaTypeUsage> _usages = new Dictionary<Schema, SchemaTypeUsage>();

        public SchemaUsageProvider(CodeModel codeModel)
        {
            foreach (var operationGroup in codeModel.OperationGroups)
            {
                foreach (var operation in operationGroup.Operations)
                {
                    foreach (var operationResponse in operation.Responses)
                    {
                        Apply(operationResponse.ResponseSchema, SchemaTypeUsage.Output);
                    }

                    foreach (var operationResponse in operation.Exceptions)
                    {
                        Apply(operationResponse.ResponseSchema, SchemaTypeUsage.Error);
                    }

                    foreach (var serviceRequest in operation.Requests)
                    {
                        foreach (var parameter in serviceRequest.Parameters)
                        {
                            if (parameter.Flattened == true)
                            {
                                Apply(parameter.Schema, SchemaTypeUsage.FattenedParameters);
                            }
                            else
                            {
                                Apply(parameter.Schema, SchemaTypeUsage.Input);
                            }
                        }
                    }
                }
            }
        }

        private void Apply(Schema? schema, SchemaTypeUsage usage)
        {
            if (!(schema is ObjectSchema objectSchema))
            {
                return;
            }

            _usages.TryGetValue(schema, out var currentUsage);

            var newUsage = currentUsage | usage;
            if (newUsage == currentUsage)
            {
                return;
            }

            _usages[schema] = newUsage;

            foreach (var parent in objectSchema.Parents!.All)
            {
                Apply(parent, usage);
            }

            foreach (var child in objectSchema.Children!.All)
            {
                Apply(child, usage);
            }

            foreach (var schemaProperty in objectSchema.Properties)
            {
                if (schemaProperty.IsReadOnly &&
                    usage == SchemaTypeUsage.Input)
                {
                    continue;
                }

                Apply(schemaProperty.Schema, usage);
            }
        }

        public SchemaTypeUsage GetUsage(ObjectSchema schema)
        {
            _usages.TryGetValue(schema, out var usage);
            return usage;
        }
    }

    [Flags]
    internal enum SchemaTypeUsage
    {
        None = 0,
        Input = 1,
        Output = Input << 1,
        Error = Output << 2,
        FattenedParameters = Error << 2,
    }
}