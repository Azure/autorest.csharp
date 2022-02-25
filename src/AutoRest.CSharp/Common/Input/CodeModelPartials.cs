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
                httpResponse.StatusCodes.Any(c => c == code));

        }
        public ServiceResponse? GetSuccessfulQueryResponse()
        {
            return GetResponseByCode(StatusCodes._200);
        }
    }

    internal partial class RecordOfStringAndAny
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

        /// <summary>
        /// Indicate whether the definition has property <c>x-ms-mgmt-typeReferenceType</c> defined as <c>true</c>.
        /// See: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/src/autorest.md
        /// </summary>
        public bool MgmtTypeReferenceType => TryGetValue("x-ms-mgmt-typeReferenceType", out var value) && Convert.ToBoolean(value);

        public string? Format => TryGetValue("x-ms-format", out object? value) ? value?.ToString() : null;
    }

    internal static class XMsFormat
    {
        public const string ArmId = "arm-id";
        public const string ResourceType = "resource-type";
        public const string DurationConstant = "duration-constant";
        public const string AzureLocation = "azure-location";
    }

    internal partial class ServiceResponse
    {
        public HttpResponse HttpResponse => Protocol.Http as HttpResponse ?? throw new InvalidOperationException($"Expected an HTTP response");
        public Schema? ResponseSchema => (this as SchemaResponse)?.Schema;
    }

    internal partial class RequestParameter
    {
        public bool IsResourceParameter => Convert.ToBoolean(Extensions.GetValue<string>("x-ms-resource-identifier"));

        public HttpParameterIn In => Protocol.Http is HttpParameter httpParameter ? httpParameter.In : HttpParameterIn.None;
        public bool IsFlattened => Flattened ?? false;
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
            Extensions = new RecordOfStringAndAny();
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

    internal partial class OperationGroup
    {
        public override string ToString()
        {
            return $"OperationGroup(Key: {Key})";
        }
    }

    internal partial class CodeModel
    {
        [YamlDotNet.Serialization.YamlMember(Alias = "testModel")]
        public TestModel? TestModel { get; set; }

        private IEnumerable<Schema>? _allSchemas;
        public IEnumerable<Schema> AllSchemas => _allSchemas ??= Schemas.Choices.Cast<Schema>()
                .Concat(Schemas.SealedChoices)
                .Concat(Schemas.Objects)
                .Concat(Schemas.Groups);
    }

    internal readonly struct JsonRawValue
    {
        public readonly object? RawValue;

        public JsonRawValue(object? rawValue)
        {
            RawValue = rawValue;
        }

        public bool IsNull()
        {
            return RawValue is null;
        }

        public bool IsEnumerable()
        {
            if (RawValue == null)
                return false;
            return typeof(IEnumerable<object>).IsAssignableFrom(RawValue.GetType());
        }
        public IEnumerable<object> AsEnumerable()
        {
            return RawValue is null ? new List<object>() : (IEnumerable<object>)RawValue;
        }

        public bool IsString()
        {
            if (RawValue == null)
                return false;
            return RawValue is string;
        }
        public string? AsString()
        {
            return RawValue?.ToString();
        }

        public bool IsDictionary()
        {
            if (RawValue == null)
                return false;
            Type t = RawValue.GetType();
            return t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Dictionary<,>) || t.Name == "RecordOfStringAndAny";
        }
        public Dictionary<string, object?> AsDictionary()
        {
            var ret = new Dictionary<string, object?>();
            if (RawValue is null)
                return ret;
            if (RawValue is RecordOfStringAndAny)
            {
                return (RecordOfStringAndAny)RawValue;
            }
            foreach (KeyValuePair<object, object?> entry in (IEnumerable<KeyValuePair<object, object?>>)RawValue)
            {
                ret.Add(entry.Key.ToString()!, entry.Value);
            }
            return ret;
        }
    }

    internal partial class OavVariableScope
    {
        [YamlMember(Alias = "requiredVariables")]
        public ICollection<string>? RequiredVariables;

        [YamlMember(Alias = "requiredVariablesDefault")]
        public Dictionary<string, string> RequiredVariablesDefault;

        [YamlMember(Alias = "secretVariables")]
        public ICollection<string>? SecretVariables;

        [YamlMember(Alias = "variables")]
        public Dictionary<string, object?> Variables;

        [YamlMember(Alias = "outputVariables")]
        public Dictionary<string, string>? OutputVariables;

        [YamlMember(Alias = "outputVariableNames")]
        public ICollection<string>? OutputVariableNames;

        public string GetVariableDefaultValue(string variableKey, string defaultValue = "default")
        {
            if (Variables is not null)
            {
                if (Variables.ContainsKey(variableKey))
                {
                    var rawValue = new JsonRawValue(Variables[variableKey]);
                    if (rawValue.IsString())
                    {
                        return rawValue.AsString()!;
                    }
                    else if (rawValue.IsDictionary())
                    {
                        var dict = rawValue.AsDictionary();
                        if (dict.ContainsKey("defaultValue"))
                        {
                            return dict["defaultValue"]?.ToString() ?? defaultValue;
                        }
                    }
                }
            }
            return defaultValue;
        }

        public HashSet<string> GetAllVariableNames()
        {
            HashSet<string> variableNames = new HashSet<string>();
            if (this.RequiredVariables is not null)
            {
                variableNames.UnionWith(this.RequiredVariables);
            }
            if (this.Variables is not null)
            {
                variableNames.UnionWith(this.Variables.Keys);
            }
            if (this.OutputVariables is not null)
            {
                variableNames.UnionWith(this.OutputVariables.Keys);
            }
            return variableNames;
        }
    }

    internal partial class TestDefinitionModel: OavVariableScope
    {
        public const string Scope_ResourceGroup = "ResourceGroup";

        [YamlMember(Alias = "useArmTemplate")]
        public Boolean UseArmTemplate;

        [YamlMember(Alias = "prepareSteps")]
        public ICollection<TestStep> PrepareSteps;

        [YamlMember(Alias = "cleanUpSteps")]
        public ICollection<TestStep> CleanUpSteps;

        [YamlMember(Alias = "scenarios")]
        public ICollection<Scenario> Scenarios;

        [YamlMember(Alias = "_filePath")]
        public string FilePath;

        [YamlMember(Alias = "scope")]
        public string? Scope;
    };

    internal partial class JsonPatchOp
    {
        [YamlMember(Alias = "add")]
        public string? Add;

        [YamlMember(Alias = "remove")]
        public string? Remove;

        [YamlMember(Alias = "replace")]
        public string? Replace;

        [YamlMember(Alias = "copy")]
        public string? Copy;

        [YamlMember(Alias = "move")]
        public string? Move;

        [YamlMember(Alias = "test")]
        public string? Test;

        [YamlMember(Alias = "value")]
        public object? Value;

        [YamlMember(Alias = "oldValue")]
        public object? OldValue;

        [YamlMember(Alias = "from")]
        public string? From;
    };

    internal partial class TestStep: OavVariableScope
    {
        public const string StepType_RestCall = "restCall";
        public const string StepType_ArmTemplateDeployment = "armTemplateDeployment";

        [YamlMember(Alias = "type")]
        public string Type;

        [YamlMember(Alias = "description")]
        public string? Description;

        [YamlMember(Alias = "step")]
        public string? Step;

        [YamlMember(Alias = "requestUpdate")]
        public ICollection<JsonPatchOp>? RequestUpdate;

        [YamlMember(Alias = "resourceUpdate")]
        public ICollection<JsonPatchOp>? ResourceUpdate;

        [YamlMember(Alias = "responseUpdate")]
        public ICollection<JsonPatchOp>? ResponseUpdate;

        [YamlMember(Alias = "statusCode")]
        public int? StatusCode;

        [YamlMember(Alias = "isPrepareStep")]
        public bool? IsPrepareStep;

        [YamlMember(Alias = "isCleanUpStep")]
        public bool? IsCleanUpStep;

        // for TestStepArmTemplateDeployment (type==armTemplateDeployment)
        [YamlMember(Alias = "armTemplate")]
        public String? ArmTemplate;

        [YamlMember(Alias = "armTemplatePayload")]
        public RecordOfStringAndAny? ArmTemplatePayload;

        // for TestStepRestCall (type==restCall)
        [YamlMember(Alias = "operationId")]
        public String? OperationId;

        [YamlMember(Alias = "exampleName")]
        public string? ExampleName;

        [YamlMember(Alias = "exampleFile")]
        public string? ExampleFile;

        [YamlMember(Alias = "requestParameters")]
        public RecordOfStringAndAny? RequestParameters;

        [YamlMember(Alias = "expectedResponse")]
        public object? ExpectedResponse;

        // test-modeler properties
        [YamlMember(Alias = "exampleModel")]
        public ExampleModel? ExampleModel;

        [YamlMember(Alias = "outputVariablesModel")]
        public Dictionary<string, ICollection<OutputVariableModel>>? OutputVariablesModel;
    };

    internal partial class OutputVariableModel
    {
        [YamlMember(Alias = "index")]
        public int? Index;

        [YamlMember(Alias = "key")]
        public string? Key;

        [YamlMember(Alias = "languages")]
        public Languages? Languages;

        [YamlMember(Alias = "type")]
        public string Type;
    }

    internal partial class Scenario: OavVariableScope
    {
        [YamlMember(Alias = "description")]
        public string Description;

        [YamlMember(Alias = "scenario")]
        public string ScenarioName;

        [YamlMember(Alias = "steps")]
        public ICollection<TestStep> Steps;

        [YamlMember(Alias = "_scenarioDef")]
        public TestDefinitionModel? ScenarioDef;

        [YamlMember(Alias = "_resolvedSteps")]
        public ICollection<TestStep>? ResolvedSteps;

        [YamlMember(Alias = "shareScope")]
        public bool ShareScope;
    };


    internal partial class TestModel
    {
        [YamlMember(Alias = "mockTest")]
        public MockTestDefinitionModel MockTest;

        [YamlMember(Alias = "scenarioTests")]
        public ICollection<TestDefinitionModel> ScenarioTests;
    }

    internal partial class MockTestDefinitionModel
    {
        [YamlMember(Alias = "exampleGroups")]
        public ICollection<ExampleGroup> ExampleGroups;
    }

    internal partial class ExampleGroup
    {
        [YamlMember(Alias = "operationId")]
        public string OperationId;

        [YamlMember(Alias = "examples")]
        public ICollection<ExampleModel> Examples;

        [YamlMember(Alias = "operationGroup")]
        public OperationGroup OperationGroup;

        [YamlMember(Alias = "operation")]
        public Operation Operation;
    }

    internal partial class ExampleModel
    {
        [YamlMember(Alias = "name")]
        public string Name; /** Key in x-ms-examples */

        [YamlMember(Alias = "operationGroup")]
        public OperationGroup OperationGroup;

        [YamlMember(Alias = "operation")]
        public Operation Operation;

        [YamlMember(Alias = "originalFile")]
        public string? OriginalFile;

        [YamlMember(Alias = "clientParameters")]
        public ICollection<ExampleParameter> ClientParameters;

        [YamlMember(Alias = "methodParameters")]
        public ICollection<ExampleParameter> MethodParameters;

        [YamlMember(Alias = "responses")]
        public Dictionary<string, ExampleResponse> Responses; // statusCode-->ExampleResponse

        public IEnumerable<ExampleParameter> AllParameter => this.ClientParameters.Concat(this.MethodParameters);
    }

    internal partial class ExampleResponse
    {
        [YamlMember(Alias = "body")]
        public ExampleValue? Body;

        [YamlMember(Alias = "headers")]
        public object? Headers;
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
        public ICollection<string>? FlattenedNames;

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
