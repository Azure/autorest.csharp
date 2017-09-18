
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

    autorest args,() =>
      instances--
      return done() if instances is 0 

defaultMappings = {
  'AcceptanceTests/ParameterFlattening': 'parameter-flattening.json',
  'AcceptanceTests/BodyArray': 'body-array.json',
  'AcceptanceTests/BodyBoolean': 'body-boolean.json',
  'AcceptanceTests/BodyByte': 'body-byte.json',
  'AcceptanceTests/BodyComplex': 'body-complex.json',
  'AcceptanceTests/BodyDate': 'body-date.json',
  'AcceptanceTests/BodyDateTime': 'body-datetime.json',
  'AcceptanceTests/BodyDateTimeRfc1123': 'body-datetime-rfc1123.json',
  'AcceptanceTests/BodyDuration': 'body-duration.json',
  'AcceptanceTests/BodyDictionary': 'body-dictionary.json',
  'AcceptanceTests/BodyFile': 'body-file.json',
  'AcceptanceTests/BodyFormData': 'body-formdata.json',
  'AcceptanceTests/BodyInteger': 'body-integer.json',
  'AcceptanceTests/BodyNumber': 'body-number.json',
  'AcceptanceTests/BodyString': 'body-string.json',
  'AcceptanceTests/Header': 'header.json',
  'AcceptanceTests/Http': 'httpInfrastructure.json',
  'AcceptanceTests/Report': 'report.json',
  'AcceptanceTests/RequiredOptional': 'required-optional.json',
  'AcceptanceTests/Url': 'url.json',
  'AcceptanceTests/Validation': 'validation.json',
  'AcceptanceTests/CustomBaseUri': 'custom-baseUrl.json',
  'AcceptanceTests/CustomBaseUriMoreOptions': 'custom-baseUrl-more-options.json',
  'AcceptanceTests/ModelFlattening': 'model-flattening.json'
}

defaultAzureMappings = {
  'AcceptanceTests/Lro': 'lro.json',
  'AcceptanceTests/Paging': 'paging.json',
  'AcceptanceTests/AzureReport': 'azure-report.json',
  'AcceptanceTests/AzureParameterGrouping': 'azure-parameter-grouping.json',
  'AcceptanceTests/AzureResource': 'azure-resource.json',
  'AcceptanceTests/Head': 'head.json',
  'AcceptanceTests/HeadExceptions': 'head-exceptions.json',
  'AcceptanceTests/SubscriptionIdApiVersion': 'subscriptionId-apiVersion.json',
  'AcceptanceTests/AzureSpecials': 'azure-special-properties.json',
  'AcceptanceTests/CustomBaseUri': 'custom-baseUrl.json'
}

compositeMappings = {
  'AcceptanceTests/CompositeBoolIntClient': 'body-boolean.json;body-integer.json'
}

azureCompositeMappings = {
  'AcceptanceTests/AzureCompositeModelClient': 'complex-model.json;body-complex.json'
}

swaggerDir = "node_modules/@microsoft.azure/autorest.testserver/swagger"

task 'regenerate-csazure', '', ['regenerate-csazurecomposite','regenerate-csazureallsync', 'regenerate-csazurenosync'], (done) ->
  mappings = Object.assign({
    'AcceptanceTests/AzureBodyDuration': 'body-duration.json'
  }, defaultAzureMappings)
  mappings['AcceptanceTests/AzureResource'] = 'azure-resource-x.json'
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
    'AcceptanceTests/AzureBodyDuration': 'body-duration.json'
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

task 'regenerate-cs', '', ['regenerate-cswithcreds', 'regenerate-cscomposite', 'regenerate-csallsync', 'regenerate-csnosync'], (done) ->
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
      'mappings': Object.assign({ 'AcceptanceTests/UrlMultiCollectionFormat': 'url-multi-collectionFormat.json' }, defaultMappings),
      'outputDir': 'Expected',
      'nsPrefix': 'Fixtures',
      'flatteningThreshold': '1'
    }, done
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
    'AcceptanceTests/AzureBodyDurationAllSync': 'body-duration.json'
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
    'AcceptanceTests/AzureBodyDurationAllSync': 'body-duration.json'
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

task 'regenerate-csazurenosync', '', (done) ->
  mappings = {
    'AcceptanceTests/AzureBodyDurationNoSync': 'body-duration.json'
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
    'AcceptanceTests/AzureBodyDurationNoSync': 'body-duration.json'
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
    'modeler' : 'CompositeSwagger',
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
    'modeler': 'CompositeSwagger',
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
    'modeler': 'CompositeSwagger',
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
