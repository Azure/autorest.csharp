﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class OmitOperationGroups
    {
        private static HashSet<Schema> _schemasToOmit = new HashSet<Schema>();
        private static HashSet<Schema> _schemasStillUsed = new HashSet<Schema>();

        public static void RemoveOperationGroups(CodeModel codeModel, BuildContext<MgmtOutputLibrary> context)
        {
            var operationGroupsToOmit = context.Configuration.MgmtConfiguration.OperationGroupsToOmit;
            if (operationGroupsToOmit != null)
            {
                var omitSet = operationGroupsToOmit.ToHashSet();
                var omittedOGs = codeModel.OperationGroups.Where(og => omitSet.Contains(og.Key)).ToList();
                var nonOmittedOGs = codeModel.OperationGroups.Where(og => !omitSet.Contains(og.Key)).ToList();

                codeModel.OperationGroups = nonOmittedOGs;
                foreach (var operationGroup in codeModel.OperationGroups)
                {
                    AddNonOmittedSchemasToSafeList(operationGroup);
                }
                foreach (var operationGroup in omittedOGs)
                {
                    if (operationGroup.IsResource(context.Configuration.MgmtConfiguration))
                    {
                        DetectSchemasToOmit(codeModel, operationGroup);
                    }
                }

                AddDependantSchemasRecursively(_schemasStillUsed);
                RemoveSchemas(codeModel);
            }
        }

        private static void RemoveSchemas(CodeModel codeModel)
        {
            foreach (var schema in _schemasToOmit)
            {
                if (schema is ObjectSchema objSchema && !_schemasStillUsed.Contains(objSchema))
                {
                    codeModel.Schemas.Objects.Remove(objSchema);
                    RemoveRelations(objSchema);
                }
            }
        }

        private static void RemoveRelations(ObjectSchema schema)
        {
            if (schema.Parents != null)
            {
                foreach (ObjectSchema parent in schema.Parents.Immediate)
                {
                    if (parent.Children != null)
                    {
                        parent.Children.Immediate.Remove(schema);
                    }
                }
            }
        }

        private static void AddDependantSchemasRecursively(HashSet<Schema> setToProcess)
        {
            Queue<Schema> sQueue = new Queue<Schema>(setToProcess);
            while (sQueue.Count > 0)
            {
                var cur = sQueue.Dequeue();
                if (cur is ObjectSchema curSchema)
                {
                    foreach (var property in curSchema.Properties)
                    {
                        if (property.Schema is ObjectSchema propertySchema)
                        {
                            sQueue.Enqueue(propertySchema);
                            setToProcess.Add(propertySchema);
                        }
                    }
                    if (curSchema.Parents != null)
                    {
                        foreach (var parent in curSchema.Parents.Immediate)
                        {
                            if (parent is ObjectSchema parentSchema)
                            {
                                sQueue.Enqueue(parentSchema);
                                setToProcess.Add(parentSchema);
                            }
                        }
                    }
                }
            }
        }

        private static void AddNonOmittedSchemasToSafeList(OperationGroup operationGroup)
        {
            foreach (var operation in operationGroup.Operations)
            {
                AddResponseSchemas(operation);
                AddRequestSchemas(operation);
            }
        }

        private static void AddResponseSchemas(Operation operation)
        {
            foreach (var response in operation.Responses)
            {
                var schema = response.ResponseSchema;
                if (schema != null && schema is ObjectSchema objSchema)
                {
                    if (_schemasToOmit.Contains(objSchema))
                    {
                        _schemasStillUsed.Add(objSchema);
                    }
                    foreach (var property in objSchema.Properties)
                    {
                        if (_schemasToOmit.Contains(property.Schema))
                        {
                            _schemasStillUsed.Add(property.Schema);
                        }
                    }
                }
            }
        }

        private static void AddRequestSchemas(Operation operation)
        {
            foreach (var request in operation.Requests)
            {
                if (request.Parameters != null)
                {
                    foreach (var param in request.Parameters)
                    {
                        if (param.Schema is ObjectSchema objSchema)
                        {
                            if (_schemasToOmit.Contains(objSchema))
                            {
                                _schemasStillUsed.Add(objSchema);
                            }
                            foreach (var property in objSchema.Properties)
                            {
                                if (_schemasToOmit.Contains(property.Schema))
                                {
                                    _schemasStillUsed.Add(property.Schema);
                                }
                            }
                        }
                    }
                }
            }
        }

        private static void DetectSchemasToOmit(CodeModel codeModel, OperationGroup operationGroup)
        {
            foreach (var operation in operationGroup.Operations)
            {
                foreach (var response in operation.Responses)
                {
                    var schema = response.ResponseSchema;
                    if (schema != null && !_schemasToOmit.Contains(schema))
                    {
                        _schemasToOmit.Add(schema);
                    }
                }
                foreach (var request in operation.Requests)
                {
                    foreach (var param in request.Parameters)
                    {
                        var schema = param.Schema;
                        if (!_schemasToOmit.Contains(schema))
                        {
                            _schemasToOmit.Add(schema);
                        }
                    }
                }
            }

            AddDependantSchemasRecursively(_schemasToOmit);

            foreach (var schema in _schemasToOmit)
            {
                if (schema is ObjectSchema objSchema)
                {
                    if (objSchema.Children != null)
                    {
                        foreach (var child in objSchema.Children.All)
                        {
                            if (!_schemasToOmit.Contains(child))
                            {
                                _schemasStillUsed.Add(child);
                            }
                        }
                    }
                }
            }
        }
    }
}
