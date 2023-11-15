// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Azure;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;
using static AutoRest.CSharp.Mgmt.Decorator.ParameterMappingBuilder;
using Resource = AutoRest.CSharp.Mgmt.Output.Resource;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class ResourceWriter : MgmtClientBaseWriter
    {
        public static ResourceWriter GetWriter(Resource resource, IEnumerable<Resource> armResources) => resource switch
        {
            PartialResource partialResource => new PartialResourceWriter(partialResource, armResources),
            _ => new ResourceWriter(resource, armResources)
        };

        private Resource This { get; }

        protected ResourceWriter(Resource resource, IEnumerable<Resource> armResources) : this(new CodeWriter(), resource, armResources)
        { }

        protected ResourceWriter(CodeWriter writer, Resource resource, IEnumerable<Resource> armResources) : base(writer, resource, armResources)
        {
            This = resource;
            _customMethods.Add(nameof(WriteAddTagBody), WriteAddTagBody);
            _customMethods.Add(nameof(WriteSetTagsBody), WriteSetTagsBody);
            _customMethods.Add(nameof(WriteRemoveTagBody), WriteRemoveTagBody);
        }

        protected override void WriteStaticMethods()
        {
            WriteCreateResourceIdentifierMethods();
            _writer.Line();
        }

        private void WriteCreateResourceIdentifierMethods()
        {
            var method = This.CreateResourceIdentifierMethod;
            _writer.WriteMethodDocumentation(method.Signature);
            _writer.WriteMethod(method);
        }

        protected override void WriteProperties()
        {
            _writer.WriteXmlDocumentationSummary($"Gets the resource type for the operations");

            _writer.Line($"public static readonly {typeof(ResourceType)} ResourceType = \"{This.ResourceType}\";");
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Gets whether or not the current instance has data.");
            _writer.Line($"public virtual bool HasData {{ get; }}");
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Gets the data representing this Feature.");
            _writer.WriteXmlDocumentationException(typeof(InvalidOperationException), $"Throws if there is no data loaded in the current instance.");
            using (_writer.Scope($"public virtual {This.ResourceData.Type} Data"))
            {
                using (_writer.Scope($"get"))
                {
                    _writer.Line($"if (!HasData)");
                    _writer.Line($"throw new {typeof(InvalidOperationException)}(\"The current instance does not have data, you must call Get first.\");");
                    _writer.Line($"return _data;");
                }
            }

            _writer.Line();
            WriteStaticValidate($"ResourceType");
        }

        private void WriteAddTagBody(MgmtClientOperation clientOperation, Diagnostic diagnostic, bool isAsync)
        {
            using (_writer.WriteDiagnosticScope(diagnostic, GetDiagnosticReference(This.GetOperation.OperationMappings.Values.First())))
            {
                using (_writer.Scope(GetTagResourceCheckString(isAsync)))
                {
                    WriteGetOriginalFromTagResource(isAsync, "[key] = value");
                    WriteTaggableCommonMethod(isAsync);
                }
                using (_writer.Scope($"else"))
                {
                    WriteTaggableCommonMethodFromPutOrPatch(isAsync, "[key] = value");
                }
            }
            _writer.Line();
        }

        private void WriteSetTagsBody(MgmtClientOperation clientOperation, Diagnostic diagnostic, bool isAsync)
        {
            using (_writer.WriteDiagnosticScope(diagnostic, GetDiagnosticReference(This.GetOperation.OperationMappings.Values.First())))
            {
                using (_writer.Scope(GetTagResourceCheckString(isAsync)))
                {
                    if (isAsync)
                    {
                        _writer.Append($"await ");
                    }
                    _writer.Line($"GetTagResource().{CreateMethodName("Delete", isAsync)}({typeof(WaitUntil)}.Completed, cancellationToken: cancellationToken){GetConfigureAwait(isAsync)};");
                    WriteGetOriginalFromTagResource(isAsync, ".ReplaceWith(tags)");
                    WriteTaggableCommonMethod(isAsync);
                }
                using (_writer.Scope($"else"))
                {
                    WriteTaggableCommonMethodFromPutOrPatch(isAsync, ".ReplaceWith(tags)", true);
                }
            }
            _writer.Line();
        }

        private void WriteRemoveTagBody(MgmtClientOperation clientOperation, Diagnostic diagnostic, bool isAsync)
        {
            using (_writer.WriteDiagnosticScope(diagnostic, GetDiagnosticReference(This.GetOperation.OperationMappings.Values.First())))
            {
                using (_writer.Scope(GetTagResourceCheckString(isAsync)))
                {
                    WriteGetOriginalFromTagResource(isAsync, ".Remove(key)");
                    WriteTaggableCommonMethod(isAsync);
                }
                using (_writer.Scope($"else"))
                {
                    WriteTaggableCommonMethodFromPutOrPatch(isAsync, ".Remove(key)");
                }
            }
            _writer.Line();
        }

        private static FormattableString GetTagResourceCheckString(bool isAsync)
        {
            var awaitStr = isAsync ? "await " : String.Empty;
            var configureStr = isAsync ? ".ConfigureAwait(false)" : String.Empty;
            return $"if({awaitStr} {CreateMethodName("CanUseTagResource", isAsync)}(cancellationToken: cancellationToken){configureStr})";
        }

        private void WriteGetOriginalFromTagResource(bool isAsync, string setCode)
        {
            _writer.Append($"var originalTags = ");
            if (isAsync)
            {
                _writer.Append($"await ");
            }
            _writer.Line($"GetTagResource().{CreateMethodName("Get", isAsync)}(cancellationToken){GetConfigureAwait(isAsync)};");
            _writer.Line($"originalTags.Value.Data.TagValues{setCode};");
        }

        private void WriteTaggableCommonMethodFromPutOrPatch(bool isAsync, string setCode, bool isSetTags = false)
        {
            if (This.UpdateOperation is null && This.CreateOperation is null)
                throw new InvalidOperationException($"Unexpected null update method for resource {This.ResourceName} while its marked as taggable");
            var updateOperation = (This.UpdateOperation ?? This.CreateOperation)!;
            var getOperation = This.GetOperation;
            var updateMethodName = updateOperation.Name;

            var configureStr = isAsync ? ".ConfigureAwait(false)" : String.Empty;
            var awaitStr = isAsync ? "await " : String.Empty;
            _writer.Line($"var current = ({awaitStr}{CreateMethodName(getOperation.Name, isAsync)}(cancellationToken: cancellationToken){configureStr}).Value.Data;");

            var lroParamStr = updateOperation.IsLongRunningOperation ? "WaitUntil.Completed, " : String.Empty;

            var parameters = updateOperation.IsLongRunningOperation ? updateOperation.MethodSignature.Parameters.Skip(1) : updateOperation.MethodSignature.Parameters;
            var bodyParamType = parameters.First().Type;
            string bodyParamName = "current";
            //if we are using PATCH always minimize what we pass in the body to what we actually want to change
            if (!bodyParamType.Equals(This.ResourceData.Type) || updateOperation.OperationMappings.Values.First().Operation.HttpMethod == RequestMethod.Patch)
            {
                bodyParamName = "patch";
                if (bodyParamType.TryCast<ObjectType>(out var objectType))
                {
                    Configuration.MgmtConfiguration.PatchInitializerCustomization.TryGetValue(bodyParamType.Name, out var customizations);
                    customizations ??= new Dictionary<string, string>();
                    _writer.Append($"var patch = new {bodyParamType}(");
                    foreach (var parameter in objectType.InitializationConstructor.Signature.Parameters)
                    {
                        var varName = parameter.Name.FirstCharToUpperCase();
                        if (customizations.TryGetValue(varName, out var customization))
                        {
                            _writer.Append($"{customization}");
                        }
                        else
                        {
                            _writer.Append($"current.{varName}, ");
                        }
                    }
                    _writer.RemoveTrailingComma();
                    _writer.Line($");");
                }
                else
                {
                    _writer.Line($"var patch = new {bodyParamType}();");
                }
                if (!isSetTags)
                {
                    using (_writer.Scope($"foreach(var tag in current.Tags)"))
                    {
                        _writer.Line($"patch.Tags.Add(tag);");
                    }
                }
                Configuration.MgmtConfiguration.UpdateRequiredCopy.TryGetValue(This.ResourceName, out var properties);
                if (properties is not null)
                {
                    foreach (var property in properties.Split(','))
                    {
                        _writer.Line($"patch.{property} = current.{property};");
                    }
                }
            }

            _writer.Line($"{bodyParamName}.Tags{setCode};");
            _writer.Line($"var result = {awaitStr}{CreateMethodName(updateMethodName, isAsync)}({lroParamStr}{bodyParamName}, cancellationToken: cancellationToken){configureStr};");
            if (updateOperation.IsLongRunningOperation)
            {
                if (updateOperation.MgmtReturnType == null)
                {
                    _writer.Line($"return {awaitStr}{CreateMethodName(getOperation.Name, isAsync)}(cancellationToken: cancellationToken){configureStr};");
                }
                else
                {
                    _writer.Line($"return {Configuration.ApiTypes.ResponseType}.FromValue(result.Value, result.{Configuration.ApiTypes.GetRawResponseName}());");
                }
            }
            else
            {
                _writer.Line($"return result;");
            }
        }

        private void WriteTaggableCommonMethod(bool isAsync)
        {
            _writer.Line($"{GetAwait(isAsync)} GetTagResource().{CreateMethodName("CreateOrUpdate", isAsync)}({typeof(WaitUntil)}.Completed, originalTags.Value.Data, cancellationToken: cancellationToken){GetConfigureAwait(isAsync)};");

            var getOperation = This.GetOperation;
            // we need to write multiple branches for a normal method
            if (getOperation.OperationMappings.Count == 1)
            {
                // if we only have one branch, we would not need those if-else statements
                var branch = getOperation.OperationMappings.Keys.First();
                WriteTaggableCommonMethodBranch(getOperation.OperationMappings[branch], getOperation.ParameterMappings[branch], isAsync);
            }
            else
            {
                // branches go here
                throw new NotImplementedException("multi-branch normal method not supported yet");
            }
        }

        private void WriteTaggableCommonMethodBranch(MgmtRestOperation getOperation, IReadOnlyList<ParameterMapping> parameterMappings, bool isAsync)
        {
            var responseType = getOperation.OriginalReturnType is null ? typeof(Response) : new CSharpType(typeof(Response<>), getOperation.OriginalReturnType);
            var responseVariable = new VariableReference(responseType, "originalResponse");

            _writer
                .Append($"var {responseVariable.Declaration:D} = {GetAwait(isAsync)} ")
                .Append($"{GetRestClientName(getOperation)}.{CreateMethodName(getOperation.MethodName, isAsync)}(");

            WriteArguments(_writer, parameterMappings, true);
            _writer.Line($"){GetConfigureAwait(isAsync)};");
            if (getOperation.OriginalReturnType is null)
            {
                _writer.WriteMethodBodyStatement(Return(responseVariable));
                return;
            }

            var response = new NullableResponseExpression(responseVariable);
            var armResource = new ArmResourceExpression(response.Value);
            if (This.ResourceData.ShouldSetResourceIdentifier)
            {
                _writer.WriteMethodBodyStatement(Assign(armResource.Id, InvokeCreateResourceIdentifier(This, getOperation.RequestPath, parameterMappings, armResource)));
            }

            var convertedValue = getOperation.GetConvertedValue(new MemberExpression(null, ArmClientReference), armResource, getOperation.MgmtReturnType);
            if (convertedValue != null)
            {
                _writer.WriteMethodBodyStatement(Return(ResponseExpression.FromValue(convertedValue, response.GetRawResponse())));
            }
            else
            {
                _writer.WriteMethodBodyStatement(Return(responseVariable));
            }
        }
    }
}
