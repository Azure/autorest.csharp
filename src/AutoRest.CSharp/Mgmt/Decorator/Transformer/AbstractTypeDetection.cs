// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Types;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Mgmt.Decorator.Transformer
{
    internal static class AbstractTypeDetection
    {
        public static readonly ConcurrentDictionary<string, ObjectSchema> AbstractTypeToInternalDerivedClass = new();

        public static void Update()
        {
            ImmutableHashSet<string> classesToSuppressAbstract = Configuration.MgmtConfiguration.SuppressAbstractBaseClass.ToImmutableHashSet();

            foreach (var schema in MgmtContext.CodeModel.AllSchemas)
            {
                if (schema is not ObjectSchema objSchema)
                    continue;
                if (objSchema.Discriminator?.All != null && objSchema.Parents?.All.Count == 0 && !classesToSuppressAbstract.Contains(objSchema.Language.Default.Name))
                {
                    if (objSchema.Extensions == null)
                        objSchema.Extensions = new RecordOfStringAndAny();
                    objSchema.Extensions.AbstractType = true;
                    AbstractTypeToInternalDerivedClass.TryAdd(objSchema.Language.Default.Name, BuildInternalDerivedClass(objSchema));
                }
            }
        }

        private static ObjectSchema BuildInternalDerivedClass(ObjectSchema abstractBaseType)
        {
            return new ObjectSchema
            {
                Language = new Languages
                {
                    Default = new Language
                    {
                        Name = "Unknown" + abstractBaseType.Language.Default.Name
                    }
                },
                Parents = new Relations
                {
                    All = { abstractBaseType },
                    Immediate = { abstractBaseType }
                },
                SerializationFormats = { KnownMediaType.Json },
                Usage = abstractBaseType.Usage
            };
        }
    }
}
