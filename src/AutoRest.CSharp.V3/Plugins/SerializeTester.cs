// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.JsonRpc;
using AutoRest.CSharp.V3.JsonRpc.MessageModels;
using AutoRest.CSharp.V3.Pipeline;
using AutoRest.CSharp.V3.Pipeline.Generated;
using AutoRest.CSharp.V3.Utilities;

namespace AutoRest.CSharp.V3.Plugins
{
    [PluginName("serialize-tester")]
    internal class SerializeTester : IPlugin
    {
        public async Task<bool> Execute(AutoRestInterface autoRest, CodeModel _1, Configuration _2)
        {
            var codeModelFile = (await autoRest.ListInputs()).FirstOrDefault();
            if (codeModelFile.IsNullOrEmpty()) throw new Exception("Generator did not receive the code model file.");

            var codeModelYaml = await autoRest.ReadFile(codeModelFile);
            var inputFile = (await autoRest.GetValue<string[]>("input-file")).FirstOrDefault();
            var fileName = $"CodeModel-{Path.GetFileNameWithoutExtension(inputFile)}-Temp.yaml";
            await autoRest.WriteFile(fileName, codeModelYaml, "source-file-csharp");

            var codeModel = Serialization.DeserializeCodeModel(codeModelYaml);
            var fileName2 = $"CodeModel-{Path.GetFileNameWithoutExtension(inputFile)}-Serial.yaml";
            var codeModelYamlSerial = codeModel.Serialize();
            await autoRest.WriteFile(fileName2, codeModelYamlSerial, "source-file-csharp");
            var codeModel2 = Serialization.DeserializeCodeModel(codeModelYamlSerial);
            var codeModelYamlDeserial = codeModel2.Serialize();
            var fileName3 = $"CodeModel-{Path.GetFileNameWithoutExtension(inputFile)}-Deserial.yaml";
            await autoRest.WriteFile(fileName3, codeModelYamlDeserial, "source-file-csharp");

            return true;
        }
    }
}
