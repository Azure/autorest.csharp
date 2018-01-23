
###############################################
# LEGACY 
# Instead: have bunch of configuration files sitting in a well-known spot, discover them, feed them to AutoRest, done.

regenExpected = (opts,done) ->
  outputDir = if !!opts.outputBaseDir then "#{opts.outputBaseDir}/#{opts.outputDir}" else opts.outputDir
  keys = Object.getOwnPropertyNames(opts.mappings)
  instances = keys.length

  for kkey in keys
    optsMappingsValue = opts.mappings[kkey]
    key = kkey.trim();
    
    swaggerFiles = (if optsMappingsValue instanceof Array then optsMappingsValue[0] else optsMappingsValue).split(";")
    args = [
      "--csharp",
      "--clear-output-folder",
      "--output-folder=#{outputDir}/#{key}",
      "--license-header=#{if !!opts.header then opts.header else 'MICROSOFT_MIT_NO_VERSION'}",
      "--enable-xml"
    ]

    for swaggerFile in swaggerFiles
      args.push("--input-file=#{if !!opts.inputBaseDir then "#{opts.inputBaseDir}/#{swaggerFile}" else swaggerFile}")
    
    args.push("--use=F:/artemp/rcm/autorest.modeler")
    #args.push("--version=F:/artemp/rcm/autorest/src/autorest-core")

    if (opts.addCredentials)
      args.push("--csharp.add-credentials=true")

    if (opts.azureArm)
      args.push("--csharp.azure-arm=true")

    if (opts.fluent)
      args.push("--csharp.fluent=true")
    
    if (opts.syncMethods)
      args.push("--csharp.sync-methods=#{opts.syncMethods}")
    
    if (opts.flatteningThreshold)
      args.push("--csharp.payload-flattening-threshold=#{opts.flatteningThreshold}")

    if (!!opts.nsPrefix)
      if (optsMappingsValue instanceof Array && optsMappingsValue[1] != undefined)
        args.push("--csharp.namespace=#{optsMappingsValue[1]}")
      else
        args.push("--csharp.namespace=#{[opts.nsPrefix, key.replace(/\/|\./, '')].join('.')}")

    if (opts['override-info.version'])
      args.push("--override-info.version=#{opts['override-info.version']}")
    if (opts['override-info.title'])
      args.push("--override-info.title=#{opts['override-info.title']}")
    if (opts['override-info.description'])
      args.push("--override-info.description=#{opts['override-info.description']}")

    if (argv.args)
      for arg in argv.args.split(" ")
        args.push(arg);

    autorest args,() =>
      instances--
      return done() if instances is 0

regenExpectedConfigurations = (configFiles,done) ->
  keys = Object.getOwnPropertyNames(configFiles)
  instances = keys.length
  for key in keys
    args = [
      "test/vanilla/Configurations/#{configFiles[key]}",
      "--csharp",
      # "--debug",
      # "--verbose",
      # "--output-artifact=openapi-document.yaml",
      # "--output-artifact=code-model-v1.yaml",
      "--namespace=Fixtures.#{key}",
      "--clear-output-folder"
    ]

    args.push("--output-folder=$(base-folder)/../../../test/vanilla/Expected/#{key}")

    if (argv.args)
      for arg in argv.args.split(" ")
        args.push(arg);
    
    args.push("--use=F:/artemp/rcm/autorest.modeler")
    #args.push("--version=F:/artemp/rcm/autorest/src/autorest-core")

    autorest args,(code, stdout, stderr) =>
      # console.log(stdout)
      # console.error(stderr)
      instances--
      return done() if instances is 0 

defaultMappings = {
  'ParameterFlattening': 'parameter-flattening.json',
  'BodyArray': 'body-array.json',
  'BodyBoolean': 'body-boolean.json',
  'BodyByte': 'body-byte.json',
  'BodyComplex': 'body-complex.json',
  'BodyDate': 'body-date.json',
  'BodyDateTime': 'body-datetime.json',
  'BodyDateTimeRfc1123': 'body-datetime-rfc1123.json',
  'BodyDuration': 'body-duration.json',
  'BodyDictionary': 'body-dictionary.json',
  'BodyFile': 'body-file.json',
  'BodyFormData': 'body-formdata.json',
  'BodyInteger': 'body-integer.json',
  'BodyNumber': 'body-number.json',
  'BodyString': 'body-string.json',
  'Header': 'header.json',
  'Http': 'httpInfrastructure.json',
  'Report': 'report.json',
  'RequiredOptional': 'required-optional.json',
  'Url': 'url.json',
  'Validation': 'validation.json',
  'CustomBaseUri': 'custom-baseUrl.json',
  'CustomBaseUriMoreOptions': 'custom-baseUrl-more-options.json',
  'ModelFlattening': 'model-flattening.json'
}

defaultAzureMappings = {
  'Lro': 'lro.json',
  'Paging': 'paging.json',
  'AzureReport': 'azure-report.json',
  'AzureParameterGrouping': 'azure-parameter-grouping.json',
  'AzureResource': 'azure-resource.json',
  'Head': 'head.json',
  'HeadExceptions': 'head-exceptions.json',
  'SubscriptionIdApiVersion': 'subscriptionId-apiVersion.json',
  'AzureSpecials': 'azure-special-properties.json',
  'CustomBaseUri': 'custom-baseUrl.json'
}

compositeMappings = {
  'CompositeBoolIntClient': 'body-boolean.json;body-integer.json'
}

azureCompositeMappings = {
  'AzureCompositeModelClient': 'complex-model.json;body-complex.json'
}

configurationFiles = {
  'HiddenMethods': 'hidden-methods.md',
  'Components': 'components.md',
  'ContentTypeHeader': 'content-type-header.md'
}

#swaggerDir = "node_modules/@microsoft.azure/autorest.testserver/swagger"
swaggerDir = "F:/artemp/rcm/autorest.csharp/node_modules/@microsoft.azure/autorest.testserver/swagger"

task 'regenerate-csazure', '', ['regenerate-csazurecomposite','regenerate-csazureallsync', 'regenerate-csazurenosync', 'regenerate-csextensibleenums', 'regenerate-csazure-xms-error-responses'], (done) ->
  mappings = Object.assign({
    'AzureBodyDuration': 'body-duration.json'
  }, defaultAzureMappings)
  mappings['AzureResource'] = 'azure-resource-x.json'
  regenExpected {
    'outputBaseDir': 'test/azure',
    'inputBaseDir': swaggerDir,
    'mappings': mappings,
    'outputDir': 'Expected',
    'azureArm': true,
    'nsPrefix': 'Fixtures.Azure',
    'flatteningThreshold': '1'
  },done
  return null

task 'regenerate-csazurefluent', '', ['regenerate-csazurefluentcomposite','regenerate-csazurefluentallsync', 'regenerate-csazurefluentnosync'], (done) ->
  mappings = Object.assign({
    'AzureBodyDuration': 'body-duration.json'
  }, defaultAzureMappings)
  regenExpected {
    'outputBaseDir': 'test/azurefluent',
    'inputBaseDir': swaggerDir,
    'mappings': mappings,
    'outputDir': 'Expected',
    'azureArm': true,
    'fluent': true,
    'nsPrefix': 'Fixtures.Azure.Fluent',
    'flatteningThreshold': '1'
  },done
  return null

task 'regenerate-cs', '', ['regenerate-cswithcreds', 'regenerate-cscomposite', 'regenerate-csallsync', 'regenerate-csnosync', 'regenerate-cs-config', 'regenerate-csxms-error-responses'], (done) ->
  mappings = {
    'Mirror.RecursiveTypes': 'swagger-mirror-recursive-type.json',
    'Mirror.Primitives': 'swagger-mirror-primitives.json',
    'Mirror.Sequences': 'swagger-mirror-sequences.json',
    'Mirror.Polymorphic': 'swagger-mirror-polymorphic.json',
    'Internal.Ctors': 'swagger-internal-ctors.json',
    'Additional.Properties': 'swagger-additional-properties.yaml',
    'DateTimeOffset': 'swagger-datetimeoffset.json'
  }
  regenExpected {
    'outputBaseDir': 'test/vanilla',
    'inputBaseDir': 'test/vanilla/Swagger',
    'mappings': mappings,
    'outputDir': 'Expected',
    'nsPrefix': 'Fixtures',
    'flatteningThreshold': '1'
  }, () ->
    regenExpected {
      'outputBaseDir': 'test/vanilla',
      'inputBaseDir': swaggerDir,
      'mappings': Object.assign({ 'UrlMultiCollectionFormat': 'url-multi-collectionFormat.json' }, defaultMappings),
      'outputDir': 'Expected',
      'nsPrefix': 'Fixtures',
      'flatteningThreshold': '1'
    }, done
  return null

task 'regenerate-cs-config', '', [], (done) ->
  regenExpectedConfigurations configurationFiles, done
  return null

task 'regenerate-cswithcreds', '', (done) ->
  mappings = {
    'PetstoreV2': 'test/vanilla/Swagger/swagger.2.0.example.v2.json',
  }
  regenExpected {
    'outputBaseDir': 'test/vanilla',
    'mappings': mappings,
    'outputDir': 'Expected',
    'nsPrefix': 'Fixtures',
    'flatteningThreshold': '1',
    'addCredentials': true
  },done
  return null

task 'regenerate-csallsync', '', (done) ->
  mappings = {
    'PetstoreV2AllSync': 'test/vanilla/Swagger/swagger.2.0.example.v2.json',
  }
  regenExpected {
    'outputBaseDir': 'test/vanilla',
    'mappings': mappings,
    'outputDir': 'Expected',
    'nsPrefix': 'Fixtures',
    'flatteningThreshold': '1',
    'syncMethods': 'all'
  },done
  return null

task 'regenerate-csnosync', '', (done) ->
  mappings = {
    'PetstoreV2NoSync': 'test/vanilla/Swagger/swagger.2.0.example.v2.json',
  }
  regenExpected {
    'outputBaseDir': 'test/vanilla',
    'mappings': mappings,
    'outputDir': 'Expected',
    'nsPrefix': 'Fixtures',
    'flatteningThreshold': '1',
    'syncMethods': 'none'
  },done
  return null

task 'regenerate-csazureallsync', '', (done) ->
  mappings = {
    'AzureBodyDurationAllSync': 'body-duration.json'
  }
  regenExpected {
    'outputBaseDir': 'test/azure',
    'inputBaseDir': swaggerDir,
    'mappings': mappings,
    'outputDir': 'Expected',
    'azureArm': true,
    'nsPrefix': 'Fixtures.Azure',
    'flatteningThreshold': '1',
    'syncMethods': 'all'
  },done
  return null

task 'regenerate-csazurefluentallsync', '', (done) ->
  mappings = {
    'AzureBodyDurationAllSync': 'body-duration.json'
  }
  regenExpected {
    'outputBaseDir': 'test/azurefluent',
    'inputBaseDir': swaggerDir,
    'mappings': mappings,
    'outputDir': 'Expected',
    'azureArm': true,
    'fluent': true,
    'nsPrefix': 'Fixtures.Azure.Fluent',
    'flatteningThreshold': '1',
    'syncMethods': 'all'
  },done
  return null

task 'regenerate-csextensibleenums', '', (done) ->
  regenExpected {
    'outputBaseDir': 'test/vanilla',
    'inputBaseDir': swaggerDir,
    'mappings': {'ExtensibleEnums': 'extensible-enums-swagger.json'},
    'outputDir': 'Expected',
    'nsPrefix': 'Fixtures',
    'flatteningThreshold': '1'
  },done
  return null

task 'regenerate-csazure-xms-error-responses', '', (done) ->
  regenExpected {
    'outputBaseDir': 'test/azure',
    'mappings': {'AcceptanceTests/XmsErrorResponses': 'xms-error-responses.json'},
    'inputBaseDir': swaggerDir,
    'outputDir': 'Expected',
    'azureArm': true,
    'nsPrefix': 'Fixtures.Azure',
    'flatteningThreshold': '1'
  },done
  return null

task 'regenerate-csxms-error-responses', '', (done) ->
  regenExpected {
    'outputBaseDir': 'test/vanilla',
    'mappings': {'AcceptanceTests/XmsErrorResponses': 'xms-error-responses.json'},
    'inputBaseDir': swaggerDir,
    'outputDir': 'Expected',
    'nsPrefix': 'Fixtures',
    'flatteningThreshold': '1'
  },done
  return null


task 'regenerate-csazurenosync', '', (done) ->
  mappings = {
    'AzureBodyDurationNoSync': 'body-duration.json'
  }
  regenExpected {
    'outputBaseDir': 'test/azure',
    'inputBaseDir': swaggerDir,
    'mappings': mappings,
    'outputDir': 'Expected',
    'azureArm': true,
    'nsPrefix': 'Fixtures.Azure',
    'flatteningThreshold': '1',
    'syncMethods': 'none'
  },done
  return null

task 'regenerate-csazurefluentnosync', '', (done) ->
  mappings = {
    'AzureBodyDurationNoSync': 'body-duration.json'
  }
  regenExpected {
    'outputBaseDir': 'test/azurefluent',
    'inputBaseDir': swaggerDir,
    'mappings': mappings,
    'outputDir': 'Expected',
    'azureArm': true,
    'fluent': true,
    'nsPrefix': 'Fixtures.Azure.Fluent',
    'flatteningThreshold': '1',
    'syncMethods': 'none'
  },done
  return null

task 'regenerate-cscomposite', '', (done) ->
  regenExpected {
    'outputBaseDir': 'test/vanilla',
    'inputBaseDir': swaggerDir,
    'mappings': compositeMappings,
    'outputDir': 'Expected',
    'nsPrefix': 'Fixtures',
    'flatteningThreshold': '1',
    'override-info.title': "Composite Bool Int",
    'override-info.description': "Composite Swagger Client that represents merging body boolean and body integer swagger clients"
  },done
  return null

task 'regenerate-csazurecomposite', '', (done) ->
  regenExpected {
    'outputBaseDir': 'test/azure',
    'inputBaseDir': swaggerDir,
    'mappings': azureCompositeMappings,
    'outputDir': 'Expected',
    'azureArm': true,
    'nsPrefix': 'Fixtures.Azure',
    'flatteningThreshold': '1',
    'override-info.version': "1.0.0",
    'override-info.title': "Azure Composite Model",
    'override-info.description': "Composite Swagger Client that represents merging body complex and complex model swagger clients"
  },done
  return null

task 'regenerate-csazurefluentcomposite', '', (done) ->
  regenExpected {
    'outputBaseDir': 'test/azurefluent',
    'inputBaseDir': swaggerDir,
    'mappings': azureCompositeMappings,
    'outputDir': 'Expected',
    'azureArm': true,
    'fluent': true,
    'nsPrefix': 'Fixtures.Azure.Fluent',
    'flatteningThreshold': '1',
    'override-info.version': "1.0.0",
    'override-info.title': "Azure Composite Model",
    'override-info.description': "Composite Swagger Client that represents merging body complex and complex model swagger clients"
  },done
  return null

task 'regenerate', "regenerate expected code for tests", ['regenerate-cs', 'regenerate-csazure', 'regenerate-csazurefluent'], (done) ->
  done();
