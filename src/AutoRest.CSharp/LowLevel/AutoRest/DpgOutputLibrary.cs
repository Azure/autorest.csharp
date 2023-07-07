// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Input.Examples;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Samples.Models;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class DpgOutputLibrary : OutputLibrary
    {
        private readonly string _libraryName;
        private readonly string _rootNamespace;
        private readonly IReadOnlyDictionary<InputEnumType, EnumType> _enums;
        private readonly IReadOnlyDictionary<InputModelType, ModelTypeProvider> _models;
        private readonly bool _isTspInput;
        private readonly SourceInputModel? _sourceInputModel;

        public TypeFactory TypeFactory { get; }
        public IEnumerable<EnumType> Enums => _enums.Values;
        public IEnumerable<ModelTypeProvider> Models => _models.Values;
        public IReadOnlyList<LowLevelClient> RestClients { get; }
        public ClientOptionsTypeProvider ClientOptions { get; }
        public IEnumerable<TypeProvider> AllModels => new List<TypeProvider>(_enums.Values).Concat(_models.Values);

        public DpgOutputLibrary(string libraryName, string rootNamespace, IReadOnlyDictionary<InputEnumType, EnumType> enums, IReadOnlyDictionary<InputModelType, ModelTypeProvider> models, IReadOnlyList<LowLevelClient> restClients, IEnumerable<InputClient> inputClients, ClientOptionsTypeProvider clientOptions, bool isTspInput, SourceInputModel? sourceInputModel)
        {
            TypeFactory = new TypeFactory(this);
            _libraryName = libraryName;
            _rootNamespace = rootNamespace;
            _enums = enums;
            _models = models;
            _isTspInput = isTspInput;
            _sourceInputModel = sourceInputModel;
            RestClients = restClients;
            ClientOptions = clientOptions;

            _inputClients = inputClients;
        }

        private readonly IEnumerable<InputClient> _inputClients;

        private IEnumerable<InputClientExample>? _inputClientExamples;
        private IEnumerable<InputClientExample> InputClientExamples => _inputClientExamples ??= ExampleMockValueBuilder.Build(_inputClients);

        private IEnumerable<InputParameterExample>? _inputClientParameterExamples;
        private IEnumerable<InputParameterExample> InputClientParameterExamples => _inputClientParameterExamples ??= InputClientExamples.SelectMany(c => c.Parameters);

        private IReadOnlyDictionary<string, InputOperationExample>? _inputOperationExamples;
        private IReadOnlyDictionary<string, InputOperationExample> InputOperationExamples => _inputOperationExamples ??= InputClientExamples.SelectMany(c => c.Operations).ToDictionary(e => GetInputOperationKey(e.Operation), e => e);

        private static string GetInputOperationKey(InputOperation inputOperation)
        {
            var builder = new StringBuilder(inputOperation.CleanName);
            builder.Append("(");
            foreach (var parameter in inputOperation.Parameters)
            {
                builder.Append(parameter);
            }
            builder.Append(")");
            return builder.ToString();
        }

        private readonly Dictionary<LowLevelClientMethod, DpgOperationSample> _inputOperationSampleCache = new();
        public IEnumerable<DpgOperationSample> GetSamples(LowLevelClient client)
        {
            foreach (var method in client.ClientMethods)
            {
                if (_inputOperationSampleCache.TryGetValue(method, out var sample))
                {
                    // return the sample if we get it in the cache
                    yield return sample;
                }
                else
                {
                    // build the sample and add it into the cache then return it
                    // TODO -- should we return nothing if inputOperation is not in the dictionary?
                    var inputOperation = method.RequestMethod.Operation;
                    sample = new DpgOperationSample(client, method, InputClientParameterExamples, InputOperationExamples[GetInputOperationKey(inputOperation)]);
                    _inputOperationSampleCache.Add(method, sample);
                    yield return sample;
                }
            }
        }

        private AspDotNetExtensionTypeProvider? _aspDotNetExtension;
        public AspDotNetExtensionTypeProvider AspDotNetExtension => _aspDotNetExtension ??= new AspDotNetExtensionTypeProvider(RestClients, _rootNamespace, _sourceInputModel);

        private ModelFactoryTypeProvider? _modelFactoryProvider;
        public ModelFactoryTypeProvider? ModelFactory => _modelFactoryProvider ??= ModelFactoryTypeProvider.TryCreate(ClientBuilder.GetClientPrefix(Configuration.LibraryName, _libraryName), _rootNamespace, AllModels, _sourceInputModel);


        public override CSharpType ResolveEnum(InputEnumType enumType)
        {
            if (!_isTspInput || enumType.Usage == InputModelTypeUsage.None)
            {
                return TypeFactory.CreateType(enumType.EnumValueType);
            }

            if (_enums.TryGetValue(enumType, out var typeProvider))
            {
                return typeProvider.Type;
            }

            throw new InvalidOperationException($"No {nameof(EnumType)} has been created for `{enumType.Name}` {nameof(InputEnumType)}.");
        }

        public override CSharpType ResolveModel(InputModelType model)
            => _models.TryGetValue(model, out var modelTypeProvider) ? modelTypeProvider.Type : new CSharpType(typeof(object), model.IsNullable);

        public override CSharpType? FindTypeByName(string originalName)
        {
            foreach (var model in Models)
            {
                if (model.Declaration.Name == originalName)
                    return model.Type;
            }

            foreach (var e in Enums)
            {
                if (e.Declaration.Name == originalName)
                    return e.Type;
            }

            return null;
        }

        public override CSharpType FindTypeForSchema(Schema schema) => throw new NotImplementedException($"{nameof(FindTypeForSchema)} shouldn't be called for DPG!");

        public override TypeProvider FindTypeProviderForSchema(Schema schema) => throw new NotImplementedException($"{nameof(FindTypeForSchema)} shouldn't be called for DPG!");
    }
}
