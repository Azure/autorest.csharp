// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Input;

namespace AutoRest.CSharp.Mgmt.Decorator.Transformer
{
    /// <summary>
    /// This static class will add some empty ObjectSchema into the code model as placeholder of the ResourceData of partial resources
    /// </summary>
    internal static class PartialResourceResolver
    {
        public static void Update(CodeModel codeModel)
        {
            foreach ((var _, var schemaName) in Configuration.MgmtConfiguration.PartialResources)
            {
                // create an empty object schema
                var objectSchema = EmptyObjectSchema.FromName(schemaName);
                codeModel.Schemas.Objects.Add(objectSchema);
            }

            // check if their is duplicate names
        }

        public class EmptyObjectSchema : ObjectSchema
        {
            public static EmptyObjectSchema FromName(string name) => new EmptyObjectSchema
            {
                Language = new Languages
                {
                    Default = new Language
                    {
                        Name = name,
                    }
                }
            };
        }
    }
}
