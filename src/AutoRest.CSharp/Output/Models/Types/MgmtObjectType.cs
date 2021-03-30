// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Builders;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class MgmtObjectType : ObjectType
    {
        private bool _isResourceType;

        public MgmtObjectType(ObjectSchema objectSchema, BuildContext context, bool isResourceType) : base(objectSchema, context)
        {
            _isResourceType = isResourceType;
        }

        protected override string DefaultName => GetDefaultName(_objectSchema, _isResourceType);

        protected string GetDefaultName(ObjectSchema objectSchema, bool isResourceType)
        {
            var name = objectSchema.NameOverride is null ? objectSchema.CSharpName() : objectSchema.NameOverride;
            return isResourceType ? name + "Data" : name;
        }

        public void OverrideInherits(CSharpType cSharpType)
        {
            _inheritsType = cSharpType;
            _properties = null;
        }

        protected override HashSet<string?> GetParentProperties()
        {
            HashSet<string?> result = new HashSet<string?>();
            CSharpType? type = Inherits;
            while (type != null)
            {
                if (type.IsFrameworkType == false)
                {
                    if (type.Implementation is ObjectType objType)
                    {
                        result.UnionWith(objType.Properties.Select(p => p.SchemaProperty?.Language.Default.Name));
                        type = objType.Inherits;
                    }
                    else
                    {
                        type = null;
                    }
                }
                else
                {
                    result.UnionWith(GetPropertiesFromSystemType(type.FrameworkType));
                    type = null;
                }
            }
            return result;
        }

        protected IEnumerable<string> GetPropertiesFromSystemType(System.Type systemType)
        {
            return systemType.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
                .Select(p =>
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append(char.ToLower(p.Name[0]));
                    builder.Append(p.Name.Substring(1));
                    return builder.ToString();
                });
        }
    }
}
