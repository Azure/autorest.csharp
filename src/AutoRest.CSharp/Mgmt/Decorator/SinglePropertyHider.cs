// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal class SinglePropertyHider
    {
        public static void HideModels(IEnumerable<Schema> schemas)
        {
            HashSet<ObjectSchema> topLevelObjects = new HashSet<ObjectSchema>();
            HashSet<ObjectSchema> singlePropertyObjects = new HashSet<ObjectSchema>();
            foreach (var schema in schemas)
            {
                if (schema is not ObjectSchema objSchema)
                    continue;

                if (objSchema.Properties.Count == 1 &&
                    (objSchema.Children is null || objSchema.Children.All.Count == 0) &&
                    (objSchema.Parents is null || objSchema.Parents.All.Count == 0))
                    singlePropertyObjects.Add(objSchema);

                foreach (var property in objSchema.Properties)
                {
                    if (property.IsRequired && property.Schema is ObjectSchema objectSchema)
                        topLevelObjects.Add(objectSchema);

                    Schema element;
                    if (property.Schema is ArraySchema arraySchema)
                    {
                        element = arraySchema.ElementType;
                    }
                    else if (property.Schema is DictionarySchema dictionarySchema)
                    {
                        element = dictionarySchema.ElementType;
                    }
                    else
                    {
                        continue;
                    }

                    if (element is ObjectSchema elementSchema)
                        topLevelObjects.Add(elementSchema);
                }
            }

            foreach (var operationGroup in MgmtContext.CodeModel.OperationGroups)
            {
                foreach (var operation in operationGroup.Operations)
                {
                    var bodyParam = operation.Parameters.FirstOrDefault(p => p.In == HttpParameterIn.Body);
                    if (bodyParam is not null)
                    {
                        AddSchema(bodyParam.Schema, topLevelObjects);
                    }
                    var bodyParams = operation.Requests.Select(request => request.Parameters.FirstOrDefault(p => p.In == HttpParameterIn.Body));
                    foreach (var body in bodyParams)
                        AddSchema(body?.Schema, topLevelObjects);

                    foreach (var response in operation.Responses.Select(response => response.ResponseSchema))
                    {
                        AddSchema(response, topLevelObjects);
                    }
                }
            }

            foreach (var singlePropertySchema in singlePropertyObjects)
            {
                if (!topLevelObjects.Contains(singlePropertySchema))
                {
                    if (singlePropertySchema.Extensions is null)
                        singlePropertySchema.Extensions = new RecordOfStringAndAny();

                    singlePropertySchema.Extensions["x-accessibility"] = "internal";
                }
            }
        }

        private static void AddSchema(Schema? schema, HashSet<ObjectSchema> topLevelObjects)
        {
            if (schema is null)
                return;

            if (schema is ObjectSchema bodySchema)
                topLevelObjects.Add(bodySchema);

            if (schema is ArraySchema arraySchema && arraySchema.ElementType is ObjectSchema bodyElementSchema)
                topLevelObjects.Add(bodyElementSchema);
        }
    }
}
