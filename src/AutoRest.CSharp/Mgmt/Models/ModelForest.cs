// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Decorator;

namespace AutoRest.CSharp.Mgmt.Models
{
    internal class ModelForest
    {
        private HashSet<ObjectSchema> _topLevelObjects = new HashSet<ObjectSchema>();
        private HashSet<ObjectSchema> _singlePropertyObjects = new HashSet<ObjectSchema>();
        public ModelForest(IEnumerable<Schema> schemas, CodeModel codeModel)
        {
            foreach (var schema in schemas)
            {
                if (schema is not ObjectSchema objSchema)
                    continue;

                if (objSchema.Properties.Count == 1 &&
                    (objSchema.Children is null || objSchema.Children.All.Count == 0) &&
                    (objSchema.Parents is null || objSchema.Parents.All.Count == 0))
                    _singlePropertyObjects.Add(objSchema);

                foreach (var property in objSchema.Properties)
                {
                    if (property.IsRequired && property.Schema is ObjectSchema objectSchema)
                        _topLevelObjects.Add(objectSchema);

                    if (property.Schema is not ArraySchema arraySchema)
                        continue;

                    if (arraySchema.ElementType is ObjectSchema elementSchema)
                        _topLevelObjects.Add(elementSchema);
                }
            }

            foreach (var operationGroup in codeModel.OperationGroups)
            {
                foreach (var operation in operationGroup.Operations)
                {
                    var bodyParam = operation.Parameters.FirstOrDefault(p => p.In == ParameterLocation.Body);
                    if (bodyParam is not null)
                    {
                        AddSchema(bodyParam.Schema);
                    }
                    var bodyParams = operation.Requests.Select(request => request.Parameters.FirstOrDefault(p => p.In == ParameterLocation.Body));
                    foreach (var body in bodyParams)
                        AddSchema(body?.Schema);

                    foreach (var response in operation.Responses.Select(response => response.ResponseSchema))
                    {
                        AddSchema(response);
                    }
                }
            }

            foreach (var singlePropertySchema in _singlePropertyObjects)
            {
                if (!_topLevelObjects.Contains(singlePropertySchema))
                {
                    if (singlePropertySchema.Extensions is null)
                        singlePropertySchema.Extensions = new DictionaryOfAny();

                    singlePropertySchema.Extensions["x-accessibility"] = "internal";
                }
            }
        }

        private void AddSchema(Schema? schema)
        {
            if (schema is null)
                return;

            if (schema is ObjectSchema bodySchema)
                _topLevelObjects.Add(bodySchema);

            if (schema is ArraySchema arraySchema && arraySchema.ElementType is ObjectSchema bodyElementSchema)
                _topLevelObjects.Add(bodyElementSchema);
        }
    }
}
