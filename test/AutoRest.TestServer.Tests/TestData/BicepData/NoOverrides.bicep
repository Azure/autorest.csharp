{
  boolProperty: false
  locationWithCustomSerialization: 'brazilsouth'
  dateTimeProperty: '2024-03-20T00:00:00.0000000Z'
  duration: 'P1D'
  number: 4
  shellProperty: {
    name: 'shell'
  }
  properties: {
    order: 3
    conditions: {
      parameters: {
        typeName: 'DeliveryRuleQueryStringConditionParameters'
        operator: 'Any'
        matchValues: [
          '''
firstline
secondline'''
          'val2'
        ]
      }
      name: 'QueryString'
      foo: 'query'
    }
    actions: [
      {
        name: 'CacheExpiration'
        foo: 'foo1'
      }
      {
        name: 'UrlSigning'
        foo: 'foo2'
      }
    ]
    extraMappingInfo: {
      'dictionaryKey': {
        name: 'CacheExpiration'
        foo: 'foo1'
      }
    }
    pet: {
      dogKind: 'german Shepherd'
      kind: 'Dog'
      type: 'dog'
    }
    foo: '''
Foo
bar'''
  }
}
