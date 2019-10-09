using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.JsonRpc;
using AutoRest.CSharp.V3.Pipeline;
using AutoRest.CSharp.V3.Utilities;

namespace AutoRest.CSharp.V3.Plugins
{
    internal class SerializeTester : IPlugin
    {
        private readonly AutoRestInterface _autoRest;
        public SerializeTester(AutoRestInterface autoRest)
        {
            _autoRest = autoRest;
        }

        public async Task<bool> Execute()
        {
            var codeModelFile = (await _autoRest.ListInputs()).FirstOrDefault();
            if (codeModelFile.IsNullOrEmpty()) throw new Exception("Generator did not receive the code model file.");

            var codeModelYaml = await _autoRest.ReadFile(codeModelFile);
            var inputFile = (await _autoRest.GetValue<string[]>("input-file")).FirstOrDefault();
            var fileName = $"CodeModel-{Path.GetFileNameWithoutExtension(inputFile)}.yaml";
            await _autoRest.WriteFile(fileName, codeModelYaml, "source-file-csharp");

            var codeModel = Serialization.DeserializeCodeModel(codeModelYaml);
            var fileName2 = $"CodeModel-{Path.GetFileNameWithoutExtension(inputFile)}-Serial.yaml";
            var codeModelYamlSerial = codeModel.Serialize();
            await _autoRest.WriteFile(fileName2, codeModelYamlSerial, "source-file-csharp");
            var codeModel2 = Serialization.DeserializeCodeModel(codeModelYamlSerial);
            var codeModelYamlDeserial = codeModel2.Serialize();
            var fileName3 = $"CodeModel-{Path.GetFileNameWithoutExtension(inputFile)}-Deserial.yaml";
            await _autoRest.WriteFile(fileName3, codeModelYamlDeserial, "source-file-csharp");

            return true;
        }
    }
}
