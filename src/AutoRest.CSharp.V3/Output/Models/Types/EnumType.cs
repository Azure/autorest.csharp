// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.V3.Generation.Types;
using AutoRest.CSharp.V3.Input;
using AutoRest.CSharp.V3.Output.Builders;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.V3.Output.Models.Types
{
    internal class EnumType : ISchemaType
    {
        public EnumType(ChoiceSchema schema, BuildContext context)
            :this(schema, context, schema.Choices, true)
        {
        }

        public EnumType(SealedChoiceSchema schema, BuildContext context)
            :this(schema, context, schema.Choices, false)
        {
        }

        private EnumType(Schema schema, BuildContext context, IEnumerable<ChoiceValue> choices, bool isStringBased)
        {
            Schema = schema;
            Declaration = BuilderHelpers.CreateTypeAttributes(
                schema.CSharpName(),
                $"{context.DefaultNamespace}.Models",
                Accessibility.Public,
                context.SourceInputModel.FindForSchema(schema.Name)?.ExistingType);
            Description = BuilderHelpers.CreateDescription(schema);
            Values = choices.Select(c => new EnumTypeValue(
                c.CSharpName(),
                CreateDescription(c),
                BuilderHelpers.StringConstant(c.Value))).ToArray();
            IsStringBased = isStringBased;
            Type = new CSharpType(Declaration.Namespace, Declaration.Name, isValueType: true);
        }

        public bool IsStringBased { get; }
        public Schema Schema { get; }
        public TypeDeclarationOptions Declaration { get; }
        public string? Description { get; }
        public IList<EnumTypeValue> Values { get; }
        public CSharpType Type { get; }

        private static string CreateDescription(ChoiceValue choiceValue)
        {
            return string.IsNullOrWhiteSpace(choiceValue.Language.Default.Description) ?
                choiceValue.Value :
                BuilderHelpers.EscapeXmlDescription(choiceValue.Language.Default.Description);
        }
    }
}
