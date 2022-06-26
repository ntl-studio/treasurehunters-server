param location string = resourceGroup().location
param containerName string = 'playefields'

resource storageAccount 'Microsoft.Storage/storageAccounts@2021-09-01' = {
  name: 'treasurehuntersfieldsv1'
  location: location
  sku: {
    name: 'Standard_LRS'
  }
  kind: 'StorageV2'
  properties: {
    accessTier: 'Hot'
    supportsHttpsTrafficOnly: true
  }

  resource blobServices 'blobServices' existing = {
    name: 'default'
  }
}

resource playeFiedsContainer 'Microsoft.Storage/storageAccounts/blobServices/containers@2021-09-01' = {
  parent: storageAccount::blobServices
  name: containerName
}




