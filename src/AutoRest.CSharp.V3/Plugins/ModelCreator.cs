using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.JsonRpc;
using AutoRest.CSharp.V3.Pipeline.Generated;

namespace AutoRest.CSharp.V3.Plugins
{
    internal class ModelCreator : IPlugin
    {
        private readonly AutoRestInterface _autoRest;
        private readonly CodeModel _codeModel;
        private readonly Configuration _configuration;
        public ModelCreator(AutoRestInterface autoRest, CodeModel codeModel, Configuration configuration)
        {
            _autoRest = autoRest;
            _codeModel = codeModel;
            _configuration = configuration;
        }

        public async Task<bool> Execute()
        {
            var objects = _codeModel.Schemas.Objects.Select(o => o.Language.Default);
            var ands = _codeModel.Schemas.Ands.Select(a => a.Language.Default);
            var ors = _codeModel.Schemas.Ors.Select(o => o.Language.Default);
            var xors = _codeModel.Schemas.Xors.Select(x => x.Language.Default);
            var all = objects.Concat(ands).Concat(ors).Concat(xors);
            foreach (var language in all)
            {
                await _autoRest.WriteFile($"models/{language.Name}.txt", language.Description, "source-file-csharp");
            }

            return true;
        }
    }
}
