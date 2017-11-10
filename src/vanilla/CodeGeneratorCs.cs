// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.Core;
using AutoRest.Core.Model;
using AutoRest.Core.Logging;
using AutoRest.Core.Utilities;
using AutoRest.CSharp.Model;
using AutoRest.CSharp.vanilla.Templates.Rest.Client;
using AutoRest.CSharp.vanilla.Templates.Rest.Common;
using static AutoRest.Core.Utilities.DependencyInjection;
using AutoRest.Extensions;
using Newtonsoft.Json.Linq;
using System.Text;

namespace AutoRest.CSharp
{
    public class CodeGeneratorCs : CodeGenerator
    {
        protected const string ClientRuntimePackage = "Microsoft.Rest.ClientRuntime.2.3.8";

        protected string FolderModels => Settings.Instance.ModelsName;
        protected string FolderInterfaces => "Interfaces";
        protected string FolderOperations => "Operations";

        public override bool IsSingleFileGenerationSupported => true;


        public override string UsageInstructions => string.Format(CultureInfo.InvariantCulture,
            Properties.Resources.UsageInformation, ClientRuntimePackage);

        public override string ImplementationFileExtension => ".cs";

        protected virtual async Task GenerateServerSideCode(CodeModelCs codeModel)
        {
            foreach (string methodGrp in codeModel.MethodGroupNames)
            {
                using (NewContext)
                {
                    codeModel.Name = methodGrp;
                    // Service server
                    var serviceControllerTemplate = new AutoRest.CSharp.vanilla.Templates.Rest.Server.ServiceControllerTemplate { Model = codeModel };
                    await Write(serviceControllerTemplate, $"{codeModel.Name}{ImplementationFileExtension}");
                }
            }
            // Models
            foreach (CompositeTypeCs model in codeModel.ModelTypes.Union(codeModel.HeaderTypes))
            {
                var modelTemplate = new ModelTemplate { Model = model };
                await Write(modelTemplate, $"{FolderModels}/{model.Name}{ImplementationFileExtension}");
            }
        }

        protected virtual async Task GenerateClientSideCode(CodeModelCs codeModel)
        {
            await GenerateServiceClient<ServiceClientTemplate>(codeModel);
            await GenerateOperations<MethodGroupWithHttpMessagesTemplate>(codeModel.Operations);
            await GenerateModels(codeModel.ModelTypes.Union(codeModel.HeaderTypes));
            await GenerateEnums(codeModel.EnumTypes);
            await GenerateExceptions(codeModel.ErrorTypes);
            if (codeModel.ShouldGenerateXmlSerialization)
            {
                await GenerateXmlSerialization();
            }
        }

        protected virtual async Task GenerateServiceClient<T>(CodeModelCs codeModel) where T : TemplateCs<CodeModelCs>, new()
        {
            await Write(new T { Model = codeModel }, $"{codeModel.Name}{ImplementationFileExtension}");
            await Write(new ServiceClientInterfaceTemplate { Model = codeModel }, $"{FolderInterfaces}/I{codeModel.Name}{ImplementationFileExtension}");
        }

        protected virtual async Task GenerateOperations<T>(IEnumerable<MethodGroup> modelTypes) where T : TemplateCs<MethodGroupCs>, new()
        {
            foreach (MethodGroupCs methodGroup in modelTypes)
            {
                if (!methodGroup.Name.IsNullOrEmpty())
                {
                    // Operation
                    await Write(
                        new MethodGroupTemplate { Model = methodGroup },
                        $"{FolderOperations}/{methodGroup.TypeName}{ImplementationFileExtension}");

                    // Operation interface
                    await Write(
                        new MethodGroupInterfaceTemplate { Model = methodGroup },
                        $"{FolderInterfaces}/I{methodGroup.TypeName}{ImplementationFileExtension}");
                }

                // Operation
                var operationsTemplate = new T { Model = methodGroup };
                await Write(operationsTemplate, $"{FolderOperations}/{operationsTemplate.Model.TypeName}WithHttpMessages{ImplementationFileExtension}");

                // Operation interface
                var operationsInterfaceTemplate = new MethodGroupWithHttpMessagesInterfaceTemplate { Model = methodGroup };
                await Write(operationsInterfaceTemplate, $"{FolderInterfaces}/I{operationsInterfaceTemplate.Model.TypeName}WithHttpMessages{ImplementationFileExtension}");
            }
        }

        protected virtual async Task GenerateModels(IEnumerable<CompositeType> modelTypes)
        {
            foreach (CompositeTypeCs model in modelTypes)
            {
                if (true == model.Extensions.Get<bool>(SwaggerExtensions.ExternalExtension))
                {
                    continue;
                }

                await Write(new ModelTemplate{ Model = model },
                    $"{FolderModels}/{model.Name}{ImplementationFileExtension}");
            }
        }

        protected virtual async Task GenerateEnums(IEnumerable<EnumType> enumTypes)
        {
            foreach (EnumTypeCs enumType in enumTypes)
            {
                await Write(new EnumTemplate { Model = enumType },
                    $"{FolderModels}/{enumType.Name}{ImplementationFileExtension}");
            }
        }

        protected virtual async Task GenerateExceptions(IEnumerable<CompositeType> errorTypes)
        {
            foreach (CompositeTypeCs exceptionType in errorTypes)
            {
                await Write(new ExceptionTemplate { Model = exceptionType },
                    $"{FolderModels}/{exceptionType.ExceptionTypeDefinitionName}{ImplementationFileExtension}");
            }
        }

        protected virtual async Task GenerateXmlSerialization()
        {
            await Write(new XmlSerializationTemplate(), 
                $"{FolderModels}/{XmlSerialization.XmlDeserializationClass}{ImplementationFileExtension}");
        }

        private async Task GenerateRestCode(CodeModelCs codeModel)
        {
            if (Settings.Instance.CodeGenerationMode.IsNullOrEmpty() || Settings.Instance.CodeGenerationMode.EqualsIgnoreCase("rest-client"))
            {
                Logger.Instance.Log(Category.Debug, "Defaulting to generate client side Code");
                await GenerateClientSideCode(codeModel);
            } 
            else if (Settings.Instance.CodeGenerationMode.EqualsIgnoreCase("rest"))
            {
                Logger.Instance.Log(Category.Debug, "Generating client side Code");
                await GenerateClientSideCode(codeModel);
                Logger.Instance.Log(Category.Debug, "Generating server side Code");
                await GenerateServerSideCode(codeModel);
            }
            else if (Settings.Instance.CodeGenerationMode.EqualsIgnoreCase("rest-server"))
            {
                Logger.Instance.Log(Category.Debug, "Generating server side Code");
                await GenerateServerSideCode(codeModel);
            }

        }

        /// <summary>
        /// Generates C# code for service client.
        /// </summary>
        /// <param name="cm"></param>
        /// <returns></returns>
        public override async Task Generate(CodeModel cm)
        {
            // get c# specific codeModel
            var codeModel = cm as CodeModelCs;
            if (codeModel == null)
            {
                throw new InvalidCastException("CodeModel is not a c# CodeModel");
            }
            if (Settings.Instance.CodeGenerationMode.IsNullOrEmpty() || Settings.Instance.CodeGenerationMode.ToLower().StartsWith("rest"))
            {
                Logger.Instance.Log(Category.Debug, "Generating Rest Code");
                await GenerateRestCode(codeModel);
            }
            else
            {
                throw new ArgumentException($"Parameter '{Settings.Instance.CodeGenerationMode}' value is not valid. Expect 'server/client'");
            }
        }

        private string CreateObjectInitializer(CompositeType type, JObject obj, int indent = 0)
        {
            if (obj == null)
            {
                return "null";
            }

            var indentString = new string(' ', 4);
            var totalIndent = string.Concat(Enumerable.Repeat(indentString, indent));

            var properties = type.Properties.ToArray();

            var result = new StringBuilder();
            var propertyInitializers = new List<string>();
            foreach (var prop in properties)
            {
                var propValue = obj.SelectToken(prop.SerializedName);
                if (propValue != null)
                {
                    propertyInitializers.Add(totalIndent + indentString + $"{prop.Name} = {CreateInitializer(prop.ModelType, propValue, indent + 1)}");
                }
                else if (prop.IsRequired)
                {
                    Logger.Instance.Log(Category.Error, $"Required property '{prop.Name}' of type '{type.ClassName}' not found.");
                }
            }
            if (propertyInitializers.Count > 0)
            {
                // special treatment for SubResource
                if (type.ClassName.Split('.').Last() == "SubResource" && properties.Length == 1 && properties[0].SerializedName == "id")
                {
                    result.Append($"new {type.ClassName}({obj.SelectToken("id").ToString(Newtonsoft.Json.Formatting.None)})");
                }
                else
                {
                    result.AppendLine($"new {type.ClassName}");
                    result.AppendLine(totalIndent + "{");
                    result.AppendLine(string.Join(",\n", propertyInitializers));
                    result.Append(totalIndent + "}");
                }
            }
            else
            {
                result.Append($"new {type.ClassName}()");
            }
            return result.ToString();
        }

        private string CreateSequenceInitializer(SequenceType type, JArray arr, int indent = 0)
        {
            if (arr == null)
            {
                return "null";
            }

            var indentString = new string(' ', 4);
            var totalIndent = string.Concat(Enumerable.Repeat(indentString, indent));

            var result = new StringBuilder();
            var itemInitializer = new List<string>();
            foreach (var item in arr)
            {
                itemInitializer.Add(totalIndent + indentString + CreateInitializer(type.ElementType, item, indent + 1));
            }
            if (itemInitializer.Count > 0)
            {
                result.AppendLine($"new List<{type.ElementType.ClassName}>");
                result.AppendLine(totalIndent + "{");
                result.AppendLine(string.Join(",\n", itemInitializer));
                result.Append(totalIndent + "}");
            }
            else
            {
                result.Append($"new List<{type.ElementType.ClassName}>()");
            }
            return result.ToString();
        }

        private string CreateInitializer(IModelType type, JToken token, int indent = 0)
            => type is CompositeType ct
            ? CreateObjectInitializer(ct, token as JObject, indent)
            : type is SequenceType st
            ? CreateSequenceInitializer(st, token as JArray, indent)
            : CodeNamer.Instance.EscapeDefaultValue(token.ToString(), type);

        public override string GenerateSample(bool isolateSnippet, CodeModel cm, MethodGroup g, Method m, string exampleName, AutoRest.Core.Model.XmsExtensions.Example example)
        {
            var clientInstanceName = "client";
            var codeModel = cm as CodeModelCs;
            var method = m as MethodCs;
            var group = g as MethodGroupCs;

            var result = new StringBuilder();
            if (isolateSnippet)
            {
                result.AppendLine("{");
                result.AppendLine("// Client: " + cm.Name);
                if (!g.Name.IsNullOrEmpty())
                {
                    result.AppendLine("// Group: " + g.Name);
                }
                result.AppendLine("// Method: " + m.Name);
                result.AppendLine("// Example: " + exampleName);
                result.AppendLine();
            }

            // parameter preparation
            var paramaters = new List<string>();
            var contiguous = false; // true;
            foreach (var formalParameter in method.LocalParameters)
            {
                // parameter found in x-ms-examples?
                if (example.Parameters.TryGetValue(formalParameter.SerializedName, out JToken token))
                {
                    var value = CreateInitializer(formalParameter.ModelType, token);
                    // initialize composite type beforehand
                    if (formalParameter.ModelType is CompositeType ct)
                    {
                        result.AppendLine($"var {formalParameter.Name} = {value};");
                        value = formalParameter.Name;
                    }
                    paramaters.Add((contiguous ? "" : formalParameter.Name + ": ") + value);
                }
                else if (formalParameter.IsRequired) // ...but it should be there!
                {
                    Logger.Instance.Log(Category.Error, $"Required parameter '{formalParameter.SerializedName}' not found.");
                    return null;
                }
                else
                {
                    contiguous = false;
                }
            }
            result.AppendLine();

            // call
            var returnTypeName = method.ReturnType.Body?.Name ?? method.ReturnType.Headers?.Name;
            returnTypeName = returnTypeName?.ToCamelCase();

            result.AppendLine($"{(returnTypeName == null ? "" : $"var {returnTypeName} = ")}await {clientInstanceName}{(g.Name.IsNullOrEmpty() ? "" : "." + g.NameForProperty)}.{m.Name}Async(" +
                $"{string.Join(", ", paramaters.Select(param => "\n    " + param))});");

            if (isolateSnippet)
            {
                result.AppendLine("}");
            }
            return result.ToString();
        }
    }
}
