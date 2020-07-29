// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.V3.Generation.Types;
using AutoRest.CSharp.V3.Input;
using AutoRest.CSharp.V3.Output.Builders;
using AutoRest.CSharp.V3.Output.Models.Shared;
using AutoRest.CSharp.V3.Output.Models.Types;
using AutoRest.CSharp.V3.Utilities;

namespace AutoRest.CSharp.V3.Output.Models
{
    internal abstract class ClientBase: TypeProvider
    {
        private const string ClientSuffixValue = "Client";
        private const string OperationsSuffixValue = "Operations";
        protected string ClientSuffix { get; }

        private readonly BuildContext _context;
        private readonly TypeFactory _typeFactory;

        protected ClientBase(BuildContext context): base(context)
        {
            ClientSuffix = context.Configuration.AzureArm ? OperationsSuffixValue : ClientSuffixValue;
            _typeFactory = context.TypeFactory;
            _context = context;
        }

        protected Parameter BuildParameter(RequestParameter requestParameter)
        {
            var type = _typeFactory.CreateType(requestParameter.Schema, requestParameter.IsNullable || !requestParameter.IsRequired);

            var isRequired = requestParameter.Required == true;
            var defaultValue = ParseConstant(requestParameter);

            if (defaultValue != null && !TypeFactory.CanBeInitializedInline(type, defaultValue))
            {
                type = type.WithNullable(true);
            }

            if (!isRequired && defaultValue == null)
            {
                defaultValue = Constant.Default(type);
            }
            return new Parameter(
                requestParameter.CSharpName(),
                CreateDescription(requestParameter),
                TypeFactory.GetInputType(type),
                defaultValue,
                isRequired);
        }

        protected Constant ParseConstant(ConstantSchema constant) =>
            BuilderHelpers.ParseConstant(constant.Value.Value, _context.TypeFactory.CreateType(constant.ValueType, constant.Value.Value == null));

        private Constant? ParseConstant(RequestParameter parameter)
        {
            if (parameter.ClientDefaultValue != null)
            {
                CSharpType constantTypeReference = _context.TypeFactory.CreateType(parameter.Schema, parameter.IsNullable);
                return BuilderHelpers.ParseConstant(parameter.ClientDefaultValue, constantTypeReference);
            }

            if (parameter.Schema is ConstantSchema constantSchema)
            {
                return ParseConstant(constantSchema);
            }

            return null;
        }

        protected static string CreateDescription(OperationGroup operationGroup, string clientPrefix)
        {
            return string.IsNullOrWhiteSpace(operationGroup.Language.Default.Description) ?
                $"The {clientPrefix} service client." :
                BuilderHelpers.EscapeXmlDescription(operationGroup.Language.Default.Description);
        }

        private static string CreateDescription(RequestParameter requestParameter)
        {
            return string.IsNullOrWhiteSpace(requestParameter.Language.Default.Description) ?
                $"The {requestParameter.Schema.Name} to use." :
                BuilderHelpers.EscapeXmlDescription(requestParameter.Language.Default.Description);
        }

        protected string GetClientPrefix(string name)
        {
            name = string.IsNullOrEmpty(name) ? "Service" : name.ToCleanName();

            if (name.EndsWith(OperationsSuffixValue) && name.Length >= OperationsSuffixValue.Length)
            {
                name = name.Substring(0, name.Length - OperationsSuffixValue.Length);
            }

            if (name.EndsWith(ClientSuffixValue) && name.Length >= ClientSuffixValue.Length)
            {
                name = name.Substring(0, name.Length - ClientSuffixValue.Length);
            }

            return name;
        }
    }
}
