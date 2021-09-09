// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Utilities;
using YamlDotNet.Serialization;
using AutoRest.CSharp.Output.Models.Requests;
using Azure.Core;

#pragma warning disable SA1649
#pragma warning disable SA1402
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
// ReSharper disable once CheckNamespace
namespace AutoRest.CSharp.Input
{
    internal partial class Operation
    {
        // For some reason, booleans in dictionaries are deserialized as string instead of bool.
        public bool IsLongRunning => Convert.ToBoolean(Extensions.GetValue<string>("x-ms-long-running-operation") ?? "false");
        public OperationFinalStateVia LongRunningFinalStateVia
        {
            get
            {
                var finalStateVia = Extensions.GetValue<IDictionary<object, object>>("x-ms-long-running-operation-options")?.GetValue<string>("final-state-via");
                return finalStateVia switch
                {
                    "azure-async-operation" => OperationFinalStateVia.AzureAsyncOperation,
                    "location" => OperationFinalStateVia.Location,
                    "original-uri" => OperationFinalStateVia.OriginalUri,
                    null => OperationFinalStateVia.Location,
                    _ => throw new ArgumentException($"Unknown final-state-via value: {finalStateVia}"),
                };
            }
        }

        public string? Accessibility => Extensions.GetValue<string>("x-accessibility");

        public ServiceResponse LongRunningInitialResponse
        {
            get
            {
                Debug.Assert(IsLongRunning);

                foreach (var operationResponse in Responses)
                {
                    if (operationResponse.Protocol.Http is HttpResponse operationHttpResponse &&
                        !operationHttpResponse.StatusCodes.Contains(StatusCodes._200) &&
                        !operationHttpResponse.StatusCodes.Contains(StatusCodes._204))
                    {
                        return operationResponse;
                    }
                }

                return Responses.First();
            }
        }
        public ServiceResponse LongRunningFinalResponse
        {
            get
            {
                Debug.Assert(IsLongRunning);

                foreach (var operationResponse in Responses)
                {
                    if (operationResponse.Protocol.Http is HttpResponse operationHttpResponse &&
                        (operationHttpResponse.StatusCodes.Contains(StatusCodes._200) ||
                         operationHttpResponse.StatusCodes.Contains(StatusCodes._204)))
                    {
                        return operationResponse;
                    }
                }

                return Responses.First();
            }
        }


        public ServiceResponse? GetResponseByCode(StatusCodes code)
        {
            return Responses.FirstOrDefault(response => response.Protocol.Http is HttpResponse httpResponse &&
                httpResponse.StatusCodes.Any(c=> c == code));

        }
        public ServiceResponse? GetSuccessfulQueryResponse()
        {
            return GetResponseByCode(StatusCodes._200);
        }
    }

    internal partial class DictionaryOfAny // : YamlDotNet.Serialization.IYamlConvertible
    {
        private static char[] _formatSplitChar = new[] { ',', ' ' };

        public string? Accessibility => TryGetValue("x-accessibility", out object? value) ? value?.ToString() : null;
        public string? Namespace => TryGetValue("x-namespace", out object? value) ? value?.ToString() : null;
        public string? Usage => TryGetValue("x-csharp-usage", out object? value) ? value?.ToString() : null;

        public string[] Formats
        {
            get
            {
                if (TryGetValue("x-csharp-formats", out object? value) && value?.ToString() is string s)
                {
                    return s.Split(_formatSplitChar, StringSplitOptions.RemoveEmptyEntries);
                }

                return Array.Empty<string>();
            }
        }

        public string? HeaderCollectionPrefix => TryGetValue("x-ms-header-collection-prefix", out object? value) ? value?.ToString() : null;

        public bool? BufferResponse => TryGetValue("x-csharp-buffer-response", out object? value) && value != null ? (bool?)Convert.ToBoolean(value) : null;

        public bool SkipEncoding => TryGetValue("x-ms-skip-url-encoding", out var value) && Convert.ToBoolean(value);

        public bool MgmtReferenceType => TryGetValue("x-ms-mgmt-referenceType", out var value) && Convert.ToBoolean(value);

        public bool MgmtPropertyReferenceType => TryGetValue("x-ms-mgmt-propertyReferenceType", out var value) && Convert.ToBoolean(value);

        // public DictionaryOfExampleModel? exampleModels => TryGetValue("example-models", out var value) ? DictionaryOfExampleModel.toMe((System.Collections.Generic.Dictionary<object, object>)value) : null;

        //[YamlDotNet.Serialization.YamlMember(Alias = "example-models")]
        //public DictionaryOfExampleModel? exampleModels { get; set; }

        //public void Read(YamlDotNet.Core.IParser parser, Type type, ObjectDeserializer nestedObjectDeserializer)
        //{
        //    nestedObjectDeserializer(type);
        //    //var scalar = parser
        //    //if (scalar != null)
        //    //{
        //    //    Test = Prod = scalar.Value;
        //    //}
        //    //else
        //    //{
        //    //    var values = (SettingsBase)nestedObjectDeserializer(typeof(SettingsBase));
        //    //    this.Test = values.Test;
        //    //    this.Prod = values.Prod;
        //    //}
        //}

        //public void Write(YamlDotNet.Core.IEmitter emitter, ObjectSerializer nestedObjectSerializer)
        //{
        //    //if (Test == Prod)
        //    //{
        //    //    nestedObjectSerializer(Test);
        //    //}
        //    //else
        //    //{
        //    //    nestedObjectSerializer(new SettingsBase { Test = this.Test, Prod = this.Prod });
        //    //}
        //}
    }

    internal partial class DictionaryOfExampleModel: System.Collections.Generic.Dictionary<string, ExampleModel>
    {
        //public static DictionaryOfExampleModel toMe(System.Collections.Generic.Dictionary<object, object> value)
        //{
        //    return (DictionaryOfExampleModel)(value.ToDictionary(k => Convert.ToString(k.Key), k => (ExampleModel)k.Value));
        //    DictionaryOfExampleModel instance = new DictionaryOfExampleModel();
        //    foreach (KeyValuePair<object, object> keyValuePair in value)
        //    {
        //        instance.Add((string)keyValuePair.Key, keyValuePair.Value as ExampleModel);

        //    }
        //    return instance;
        //}
    }

    internal partial class ServiceResponse
    {
        public HttpResponse HttpResponse => Protocol.Http as HttpResponse ?? throw new InvalidOperationException($"Expected an HTTP response");
        public Schema? ResponseSchema => (this as SchemaResponse)?.Schema;
    }

    internal partial class RequestParameter
    {
        public ParameterLocation In => Protocol.Http is HttpParameter httpParameter ? httpParameter.In : ParameterLocation.None;

        public RequestParameter ShallowCopy()
        {
            return (RequestParameter)this.MemberwiseClone();
        }
    }

    internal partial class HttpResponse
    {
        public int[] IntStatusCodes => StatusCodes.Select(ToStatusCode).ToArray();

        private static int ToStatusCode(StatusCodes arg) => int.Parse(arg.ToString().Trim('_'));
    }

    internal partial class Value
    {
        public Value()
        {
            Extensions = new DictionaryOfAny();
        }

        public bool IsNullable => Nullable ?? false;
        public bool IsRequired => Required ?? false;
    }

    internal partial class SchemaResponse
    {
        public bool IsNullable => Nullable ?? false;
    }

    internal partial class Property
    {
        public bool IsReadOnly => ReadOnly ?? false;
    }

    internal partial class ObjectSchema
    {
        public ObjectSchema()
        {
            Parents = new Relations();
            Children = new Relations();
        }
    }

    // redefined manually to inherit from ObjectSchema
    internal partial class GroupSchema : ObjectSchema
    {
    }

    internal partial class Schema
    {
        public string? XmlName => Serialization?.Xml?.Name;
        public string Name => Language.Default.Name;
    }

    internal partial class HTTPSecurityScheme : Dictionary<string, object>
    {

    }

    internal partial class Paging
    {
        [YamlMember(Alias = "group")]
        public string? Group { get; set; }

        [YamlMember(Alias = "itemName")]
        public string? ItemName { get; set; }

        [YamlMember(Alias = "member")]
        public string? Member { get; set; }

        [YamlMember(Alias = "nextLinkName")]
        public string? NextLinkName { get; set; }

        [YamlMember(Alias = "nextLinkOperation")]
        public Operation? NextLinkOperation { get; set; }
    }

    /// <summary>language metadata specific to schema instances</summary>
    internal partial class Language
    {
        /// <summary>namespace of the implementation of this item</summary>
        [YamlMember(Alias = "namespace")]
        public string? Namespace { get; set; }

        /// <summary>if this is a child of a polymorphic class, this will have the value of the discriminator.</summary>
        [YamlMember(Alias = "discriminatorValue")]
        public string? DiscriminatorValue { get; set; }

        [YamlMember(Alias = "uid")]
        public string? Uid { get; set; }

        [YamlMember(Alias = "internal")]
        public bool? Internal { get; set; }

        [YamlMember(Alias = "serializedName")]
        public string? SerializedName { get; set; }

        [YamlMember(Alias = "paging")]
        public Paging? Paging { get; set; }

        [YamlMember(Alias = "header")]
        public string? Header { get; set; }

        [YamlMember(Alias = "summary")]
        public string? Summary { get; set; }
    }

    internal partial class NoAuthSecurity : SecurityScheme
    {
    }

    internal partial class Security
    {
        internal IEnumerable<SecurityScheme> GetSchemesOrAnonymous()
        {
            if (Schemes.Count == 0)
            {
                yield return new NoAuthSecurity();
            }
            else
            {
                foreach (var scheme in Schemes)
                {
                    yield return scheme;
                }
            }
        }
    }

    internal partial class OperationGroup
    {
        public override string ToString()
        {
            return $"OperationGroup(Key: {Key})";
        }
    }

    internal partial class CodeModel
    {
        [YamlDotNet.Serialization.YamlMember(Alias = "testLayout")]
        public TestLayout? TestLayout { get; set; }
    }

    internal partial class TestDefinitionModel {

        [YamlMember(Alias = "useArmTemplate")]
        public Boolean UseArmTemplate;

        [YamlMember(Alias = "requiredVariablesDefault")]
        public System.Collections.Generic.Dictionary<string, string> RequiredVariablesDefault;

        [YamlMember(Alias = "outputVariableNames")]
        public System.Collections.Generic.ICollection<string> OutputVariableNames;

        [YamlMember(Alias = "prepareSteps")]
        public System.Collections.Generic.ICollection<TestStep> PrepareSteps;

        [YamlMember(Alias = "testScenarios")]
        public System.Collections.Generic.ICollection<TestScenario> TestScenarios;

        [YamlMember(Alias = "_filePath")]
        public string FilePath;

        [YamlMember(Alias = "scope")]
        public string? scope;

        [YamlMember(Alias = "scope")]
        public System.Collections.Generic.ICollection<string>? requiredVariables;
    };

    internal partial class TestStep{

        [YamlMember(Alias = "step")]
        public string type;


        // for TestStepArmTemplateDeployment (type==armTemplateDeployment)
        [YamlMember(Alias = "step")]
        public string step;

        [YamlMember(Alias = "armTemplatePayload")]
        public DictionaryOfAny? armTemplatePayload;

        [YamlMember(Alias = "armTemplateParametersPayload")]
        public DictionaryOfAny? armTemplateParametersPayload;

        // for TestStepRestCall (type==restCall)
        [YamlMember(Alias = "operation")]
        public DictionaryOfAny? operation;

        [YamlMember(Alias = "exampleId")]
        public string? exampleId;

        [YamlMember(Alias = "exampleFilePath")]
        public string? exampleFilePath;

        [YamlMember(Alias = "requestParameters")]
        public DictionaryOfAny? requestParameters;

        [YamlMember(Alias = "responseExpected")]
        public DictionaryOfAny? responseExpected;


        // test-modeler properties
        [YamlMember(Alias = "exampleModel")]
        public ExampleModel? exampleModel;

        [YamlMember(Alias = "outputVariableNames")]
        public System.Collections.Generic.ICollection<string>? outputVariableNames;
    };

    internal partial class TestScenario {
        [YamlMember(Alias = "requiredVariablesDefault")]
        public System.Collections.Generic.Dictionary<string, string> RequiredVariablesDefault;

        [YamlMember(Alias = "steps")]
        public System.Collections.Generic.ICollection<TestStep> Steps;

        [YamlMember(Alias = "_testDef")]
        public TestDefinitionModel? TestDef;

        [YamlMember(Alias = "_resolvedSteps")]
        public System.Collections.Generic.ICollection<TestStep>? ResolvedSteps;
    };


    internal partial class TestLayout
    {
        [YamlMember(Alias = "mockTests")]
        public System.Collections.Generic.ICollection<TestGroup> MockTests;

        [YamlMember(Alias = "scenarioTests")]
        public System.Collections.Generic.ICollection<TestDefinitionModel> ScenarioTests;
    }

    internal partial class TestGroup
    {
        [YamlMember(Alias = "name")]
        public string Name;

        [YamlMember(Alias = "exampleGroups")]
        public System.Collections.Generic.ICollection<ExampleGroup> ExampleGroups;
    }

    internal partial class ExampleGroup
    {
        [YamlMember(Alias = "name")]
        public string Name;

        [YamlMember(Alias = "examples")]
        public System.Collections.Generic.ICollection<ExampleModel> Examples;
    }

    internal partial class ExampleModel
    {
        [YamlMember(Alias = "name")]
        public string Name; /** Key in x-ms-examples */

        [YamlMember(Alias = "operationGroup")]
        public OperationGroup OperationGroup;

        [YamlMember(Alias = "operation")]
        public Operation Operation;

        [YamlMember(Alias = "clientParameters")]
        public System.Collections.Generic.ICollection<ExampleParameter> ClientParameters;

        [YamlMember(Alias = "methodParameters")]
        public System.Collections.Generic.ICollection<ExampleParameter> MethodParameters;

        [YamlMember(Alias = "responses")]
        public System.Collections.Generic.Dictionary<string, ExampleResponse> Responses; // statusCode-->ExampleResponse
    }

    internal partial class ExampleResponse
    {
        [YamlMember(Alias = "body")]
        public ExampleValue Body;

        [YamlMember(Alias = "headers")]
        public DictionaryOfAny Headers;
    }

    internal partial class ExampleParameter
    {
        /** Ref to the Parameter of operations in codeModel */
        [YamlMember(Alias = "parameter")]
        public RequestParameter Parameter;

        /** Can be object, list, primitive data, ParameterModel*/
        [YamlMember(Alias = "exampleValue")]
        public ExampleValue ExampleValue;
    }

    internal partial class ExampleValue
    {
        [YamlMember(Alias = "language")]
        public Languages Language;

        [YamlMember(Alias = "schema")]
        public Schema Schema;

        [YamlMember(Alias = "flattenedNames")]
        public System.Collections.Generic.ICollection<string>? FlattenedNames;

        /**Use elements if schema.type==Array, use properties if schema.type==Object/Dictionary, otherwise use rawValue */
        [YamlMember(Alias = "rawValue")]
        public object? RawValue;

        [YamlMember(Alias = "elements")]
        public System.Collections.Generic.ICollection<ExampleValue>? Elements;

        [YamlMember(Alias = "properties")]
        public DictionaryOfExamplValue? Properties;

        [YamlMember(Alias = "parentsValue")]
        public DictionaryOfExamplValue ParentsValue; // parent class Name--> value

        public string CSharpName() =>
            (this.Language.Default.Name == null || this.Language.Default.Name == "null") ? "NullProperty" : this.Language.Default.Name.ToCleanName();
    }

    internal partial class DictionaryOfExamplValue : System.Collections.Generic.Dictionary<string, ExampleValue>
    {

    }
}
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
